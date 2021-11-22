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
        public LibVLC _libVLC;
        public VideoView vlcPlayer;
        public LibVLCSharp.Shared.MediaPlayer _mp;
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
                    vlcPlayer.MediaPlayer.Stop();
                    vlcPlayer.MediaPlayer.Media = new Media(_libVLC, filename);
                    vlcPlayer.MediaPlayer.Play();
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not play media file!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
        }

        public void playFile()
        {
            vlcPlayer.MediaPlayer.Stop();
            vlcPlayer.MediaPlayer.Play();
        }


        public void jumpAt(long timeUs)
        {
            vlcPlayer.MediaPlayer.Time = timeUs;
        }

        public bool isPlaying()
        {
            return vlcPlayer.MediaPlayer.IsPlaying;
        }
        private void mediaWindow_Loaded(object sender, RoutedEventArgs e)
        {
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
        }

        private void MediaPlayer_Paused(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Application.Current.Windows.OfType<MainWindow>().First().
                playButton.Background = new ImageBrush(MainWindow.getBitmapResource("play.png"));
            });
        }

        private void MediaPlayer_Stopped(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                MainWindow window = Application.Current.Windows.OfType<MainWindow>().First();

                window.currentTimeLabel.Content = "00:00";
                window.timeBar.Value = 0;
                window.maxDurationLabel.Content = "00:00";
                window.playButton.Background = new ImageBrush(MainWindow.getBitmapResource("play.png"));
                window.masterVolumeSlider.IsEnabled = false;
            });
        }

        private void MediaPlayer_Playing(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                MainWindow window = Application.Current.Windows.OfType<MainWindow>().First();

                window.currentTimeLabel.Content = "00:00";
                window.timeBar.Value = 0;
                window.maxDurationLabel.Content = TimeSpan.FromMilliseconds(vlcPlayer.MediaPlayer.Media.Duration).ToString(@"mm\:ss");
                window.playButton.Background = new ImageBrush(MainWindow.getBitmapResource("pause.png"));
                window.masterVolumeSlider.IsEnabled = true;
            });
        }

        private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            int progress = (int)((e.Time * 100) / vlcPlayer.MediaPlayer.Media.Duration);
            string currentTime = TimeSpan.FromMilliseconds(e.Time).ToString(@"mm\:ss");
            this.Dispatcher.Invoke(() =>
            {
                MainWindow window = Application.Current.Windows.OfType<MainWindow>().First();

                window.timeBar.Value = progress;
                window.currentTimeLabel.Content = currentTime;
            });
        }

    }
}
