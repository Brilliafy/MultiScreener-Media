using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfScreenHelper;
using System.IO;
using System.Reflection;
using System.Resources;
using Microsoft.Win32;

namespace MultiScreener_Media
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CoreAudioDevice defaultPlaybackDevice;
        //CoreAudioController audioController;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void jumpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<JumpTimeWindow>().Any())
            {
                System.Media.SystemSounds.Beep.Play();
                Application.Current.Windows.OfType<JumpTimeWindow>().First().Activate();                
            }
            else
            {
                new JumpTimeWindow().Show();                
            }
        }

        private void openFolderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPickerDialog = new FolderPicker
            {
                InputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (folderPickerDialog.ShowDialog() == true)
            {
                contentsListBox.Items.Clear();

                string[] folderFiles = Directory.GetFiles(folderPickerDialog.ResultPath);
                foreach (string file in folderFiles)
                {
                    contentsListBox.Items.Add(file.ToString());
                }
            }
        }

        private void openFilesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                contentsListBox.Items.Clear();
                foreach (string filename in openFileDialog.FileNames)
                {
                    contentsListBox.Items.Add(System.IO.Path.GetFullPath(filename));
                }
            }
        }

        private void contentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contentsListBox.SelectedItem != null)
            {
                string selectedItem = contentsListBox.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(selectedItem))
                {
                    getMediaWindow().playFile(selectedItem);                    
                }
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            getMediaWindow().vlcPlayer.MediaPlayer.Stop();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            MediaWindow mediaWindow = getMediaWindow();
            if (mediaWindow.vlcPlayer.MediaPlayer.Media != null)
            {
                if (mediaWindow.vlcPlayer.MediaPlayer.IsPlaying)
                {
                    mediaWindow.vlcPlayer.MediaPlayer.Pause();
                }
                else
                {
                    mediaWindow.vlcPlayer.MediaPlayer.Play();
                }
            }
        }

        public static BitmapImage getBitmapResource(string name)
        {            
            return new BitmapImage(new Uri("pack://application:,,,/resources/" + name));
        }

        private void muteButton_Click(object sender, RoutedEventArgs e)
        {
            MediaWindow mediaWindow = getMediaWindow();
            if (mediaWindow.vlcPlayer.MediaPlayer.IsPlaying)
            {
                mediaWindow.vlcPlayer.MediaPlayer.ToggleMute();
                toggleMuteButton.Background = new ImageBrush(mediaWindow.vlcPlayer.MediaPlayer.Mute ? MainWindow.getBitmapResource("audio.png") : MainWindow.getBitmapResource("mute.png"));
                Properties.Settings.Default.isMuted = mediaWindow.vlcPlayer.MediaPlayer.Mute;
                Properties.Settings.Default.Save();
            }
        }

        private void masterVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (getMediaWindow().vlcPlayer.MediaPlayer.IsPlaying && mainWindow.IsLoaded)
            {
                getMediaWindow().vlcPlayer.MediaPlayer.Volume = (int)e.NewValue;
                Properties.Settings.Default.audioLevel = (int)e.NewValue;
                Properties.Settings.Default.Save();
            }            
        }
      

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
            if (WpfScreenHelper.Screen.AllScreens.Count() < 2)
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Single-screen presentation is not supported; Please connect a second screen.", "Error",MessageBoxButton.OK,MessageBoxImage.Error, MessageBoxResult.OK,MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
                return;
            }
            getMediaWindow().Show();
            toggleMuteButton.Background = new ImageBrush(Properties.Settings.Default.isMuted ? MainWindow.getBitmapResource("audio.png") : MainWindow.getBitmapResource("mute.png"));
            masterVolumeSlider.Value = Properties.Settings.Default.audioLevel;
        }

        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            getMediaWindow().playFile();                     
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(!Application.Current.Windows.OfType<AboutWindow>().Any())
            {
                new AboutWindow().Show();
            }
        }
        public MediaWindow getMediaWindow()
        {
            if (Application.Current.Windows.OfType<MediaWindow>().Any())
            {
                return Application.Current.Windows.OfType<MediaWindow>().First();
            }
            else
            {
                MediaWindow window = new MediaWindow();
                window.Show();
                return window;
            }
        }

        private void mainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown(0);
        }
    }
}
