using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfScreenHelper;

namespace MultiScreener_Media
{
    /// <summary>
    /// Interaction logic for MediaWindow.xaml
    /// </summary>
    public partial class MediaWindow : Window
    {
        public static LibVLC _libVLC;
        public VideoView vlcPlayer;
        public LibVLCSharp.Shared.MediaPlayer _mp;
        public MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        public PreviewWindow previewWindow = null;
        public MediaWindow()
        {
            InitializeComponent();
        }

        public void playFile(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    //vlcPlayer.MediaPlayer.Stop();
                    vlcPlayer.MediaPlayer.Media = new Media(_libVLC, filename);
                    vlcPlayer.MediaPlayer.Play();
                    previewWindow?.syncroniseSource(filename);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    MessageBox.Show("Could not play media file!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
        }

        public void requestPreviewSync()
        {
            previewWindow = Application.Current.Windows.OfType<PreviewWindow>().FirstOrDefault();
            previewWindow.ConnectWithScreen();
        }

        public void play()
        {
            //vlcPlayer.MediaPlayer.Stop();
            vlcPlayer.MediaPlayer.Play();
            previewWindow?.syncroniseStatus(false);
        }

        public void Pause()
        {
            vlcPlayer.MediaPlayer.Pause();
            previewWindow?.syncroniseStatus(true);
        }

        public void Restart()
        {
            if (isPlaying())
            {
                jumpAt(0);
            }
            else
            {
                vlcPlayer.MediaPlayer.Stop();
                play();
            }
        }

        public long getMediaDuration()
        {
            return vlcPlayer.MediaPlayer.Media.Duration;
        }

        public void jumpAt(long timeUs)
        {
            vlcPlayer.MediaPlayer.Time = timeUs;
            previewWindow?.syncroniseTime(timeUs);
        }

        public bool isPlaying()
        {
            return vlcPlayer.MediaPlayer.IsPlaying;
        }

        public bool hasAnyMediaLoaded()
        {
            VLCState VLCState = vlcPlayer.MediaPlayer.State;
            return VLCState != VLCState.NothingSpecial ^ VLCState != VLCState.Opening ^ VLCState != VLCState.Error;
        }
        private void mediaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            previewWindow = Application.Current.Windows.OfType<PreviewWindow>().FirstOrDefault();
            Screen targetScreen = (Screen.AllScreens.Count() > 1) ? Screen.AllScreens.ElementAt(1) : Screen.AllScreens.ElementAt(0);
            this.Left = (Screen.AllScreens.Count() > 1) ? Screen.AllScreens.ElementAt(0).Bounds.Width : 0;
            this.Top = 0;
            this.Width = targetScreen.Bounds.Width;
            this.Height = targetScreen.Bounds.Height;

            LibVLCSharp.Shared.Core.Initialize();
            vlcPlayer = new LibVLCSharp.WinForms.VideoView();
            _libVLC = new LibVLC();
            _mp = new LibVLCSharp.Shared.MediaPlayer(_libVLC);
            vlcPlayer.MediaPlayer = _mp;

            windowsForms.Child = vlcPlayer;
            vlcPlayer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            vlcPlayer.Location = new System.Drawing.Point(0, 0);
            vlcPlayer.Size = new System.Drawing.Size(new System.Drawing.Point((int)windowsForms.Width, (int)windowsForms.Height));
            vlcPlayer.MediaPlayer.TimeChanged += MediaPlayer_TimeChanged;
            vlcPlayer.MediaPlayer.Playing += MediaPlayer_Playing;
            vlcPlayer.MediaPlayer.Stopped += MediaPlayer_Stopped;
            vlcPlayer.MediaPlayer.Paused += MediaPlayer_Paused;
            vlcPlayer.MediaPlayer.Opening += MediaPlayer_Opening;

            vlcPlayer.MediaPlayer.Mute = Properties.Settings.Default.isMuted;
            mainWindow.masterVolumeSlider.Value = Properties.Settings.Default.audioLevel;
        }

        private void MediaPlayer_Opening(object sender, EventArgs e)
        {
            mainWindow.Dispatcher.Invoke(new Action(() =>
            {
                mainWindow.currentTimeLabel.Content = "00:00";
            }));
            vlcPlayer.MediaPlayer.Mute = MainWindow.isMuted;
            vlcPlayer.MediaPlayer.Volume = MainWindow.volume;

        }

        private void MediaPlayer_Paused(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() => mainWindow.playButton.Background = new ImageBrush(MainWindow.getBitmapResource("play.png")));
            previewWindow?.syncroniseStatus(true);
        }

        private void MediaPlayer_Stopped(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                previewWindow?.stopMedia();
                mainWindow.currentTimeLabel.Content = "00:00";
                mainWindow.timeBar.Value = 0;
                mainWindow.timeBar.IsEnabled = false;
                mainWindow.maxDurationLabel.Content = "00:00";
                mainWindow.playButton.Background = new ImageBrush(MainWindow.getBitmapResource("play.png"));
            });
        }

        private void MediaPlayer_Playing(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                previewWindow?.syncroniseStatus(false);
                mainWindow.timeBar.Value = 0;
                mainWindow.timeBar.IsEnabled = true;
                mainWindow.maxDurationLabel.Content = TimeSpan.FromMilliseconds(vlcPlayer.MediaPlayer.Media.Duration).ToString(@"mm\:ss");
                mainWindow.playButton.Background = new ImageBrush(MainWindow.getBitmapResource("pause.png"));
            });
        }

        private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            if (!mainWindow.isTimebarBeingDragged)
            {
                int progress = (int)((e.Time * 100) / vlcPlayer.MediaPlayer.Media.Duration);
                string currentTime = TimeSpan.FromMilliseconds(e.Time).ToString(@"mm\:ss");
                Dispatcher.Invoke(() =>
                {
                    mainWindow.timeBar.Value = progress;
                    mainWindow.currentTimeLabel.Content = currentTime;
                });
            }
        }
    }
}
