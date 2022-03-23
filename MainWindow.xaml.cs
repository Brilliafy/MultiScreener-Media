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
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows.Controls.Primitives;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace MultiScreener_Media
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CoreAudioDevice defaultPlaybackDevice;
        //CoreAudioController audioController;
        public List<string> filePathList = new List<string>();
        public bool isTimebarBeingDragged = false;
        public byte fileDisplayState = 0;
        public static bool isMuted = false;
        public static int volume;

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

        public void setThemeColors()
        {
            try
            {
                masterVolumeSlider.Background = ThemeInfo.GetThemeBrushColor();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                foreach (string file in Directory.GetFiles(folderPickerDialog.ResultPath))
                {
                    addMediaItem(System.IO.Path.GetFullPath(file));
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
                foreach (string filename in openFileDialog.FileNames)
                {
                    addMediaItem(System.IO.Path.GetFullPath(filename));
                }
            }
        }

        public void addMediaItem(string filePath)
        {
            if (!filePathList.Contains(filePath))
            {
                filePathList.Add(filePath);

                ShellFile shellFile = ShellFile.FromFilePath(filePath);
                //MemoryStream iconStream = new MemoryStream();
                //shellFile.Thumbnail.MediumIcon.Save(iconStream);
                //iconStream.Seek(0, SeekOrigin.Begin);

                contentsListBox.Items.Add(new ContentListing(BitmapFrame.Create(shellFile.Thumbnail.MediumBitmapSource), fileDisplayState == 0 ? System.IO.Path.GetFileName(filePath) :
                                                                                            (fileDisplayState == 1 ? System.IO.Path.GetFileNameWithoutExtension(filePath) : filePath)));
            }
        }

        private void contentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contentsListBox.SelectedItem != null)
            {
                getMediaWindow().playFile(filePathList[contentsListBox.SelectedIndex]);
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
            isMuted = !isMuted;
            MediaWindow mediaWindow = getMediaWindow();
            if (mediaWindow.isPlaying())
            {
                mediaWindow.vlcPlayer.MediaPlayer.ToggleMute();
            }
            toggleMuteButton.Background = new ImageBrush(isMuted ? MainWindow.getBitmapResource("mute.png") : MainWindow.getBitmapResource("audio.png"));
        }

        private void masterVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
            {
                MediaWindow mediaWindow = getMediaWindow();
                volume = (int)e.NewValue;
                volumeLabel.Content = (int)e.NewValue + "%";
                if (mediaWindow.isPlaying())
                {
                    mediaWindow.vlcPlayer.MediaPlayer.Volume = (int)e.NewValue;
                }
            }
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
            if (Screen.AllScreens.Count() < 2)
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Single-screen presentation is not supported; Please connect a second screen.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
                return;
            }
            getMediaWindow().Show();
            isMuted = Properties.Settings.Default.isMuted;
            volume = Properties.Settings.Default.audioLevel;
            toggleMuteButton.Background = new ImageBrush(isMuted ? MainWindow.getBitmapResource("mute.png") : MainWindow.getBitmapResource("audio.png"));
            MenuItemAutomationPeer peer = new MenuItemAutomationPeer((MenuItem)viewMenu.Items[Properties.Settings.Default.fileViewOption]);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            getMediaWindow().Restart();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<AboutWindow>().Any())
            {
                new AboutWindow().Show();
            }
            else
            {
                Application.Current.Windows.OfType<AboutWindow>().First().Activate();
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

        private void clearFilesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            filePathList.Clear();
            contentsListBox.Items.Clear();
        }

        private void mainWindow_Closed(object sender, EventArgs e)
        {
            if (mainWindow != null)
            {
                Properties.Settings.Default.audioLevel = (int)masterVolumeSlider.Value;
                Properties.Settings.Default.isMuted = getMediaWindow().vlcPlayer.MediaPlayer.Mute;
                Properties.Settings.Default.fileViewOption = fileDisplayState;
                Properties.Settings.Default.Save();
                Application.Current.Shutdown(0);
            }
        }

        private void openPreviewerClick(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<PreviewWindow>().Any())
            {
                new PreviewWindow().Show();
            }
            else
            {
                Application.Current.Windows.OfType<PreviewWindow>().First().Activate();
            }
        }

        //private void timeBar_DragCompleted(object sender, DragCompletedEventArgs e)
        //{
        //    if (Application.Current.Windows.OfType<MediaWindow>().Any())
        //    {
        //        MediaWindow mediaWindow = Application.Current.Windows.OfType<MediaWindow>().First();
        //        if (mediaWindow.hasAnyMediaLoaded())
        //        {
        //            int timeToJump = (int)((timeBar.Value / 100) * mediaWindow.getMediaDuration());
        //            JumpTimeWindow.jumpAt(timeToJump);
        //        }
        //    }
        //    isTimebarBeingDragged = false;
        //}

        //private void timeBar_DragStarted(object sender, DragStartedEventArgs e)
        //{
        //    isTimebarBeingDragged = true;
        //}

        public void ResortContentViewer()
        {
            if (IsLoaded)
            {
                if (contentsListBox.Items.Count != 0)
                {
                    List<ContentListing> updatedList = new List<ContentListing>();
                    foreach (ContentListing item in contentsListBox.Items)
                    {
                        String itemPath = filePathList[contentsListBox.Items.IndexOf(item)];
                        switch (fileDisplayState)
                        {
                            case 0:
                                updatedList.Add(new ContentListing(item.Path, System.IO.Path.GetFileName(itemPath)));
                                break;
                            case 1:
                                updatedList.Add(new ContentListing(item.Path, System.IO.Path.GetFileNameWithoutExtension(itemPath)));
                                break;
                            case 2:
                                updatedList.Add(new ContentListing(item.Path, itemPath));
                                break;
                        }
                    }
                    contentsListBox.Items.Clear();
                    foreach (ContentListing updatedItem in updatedList)
                    {
                        contentsListBox.Items.Add(updatedItem);
                    }
                }
            }
        }

        private void categoriseFilename(object sender, RoutedEventArgs e)
        {
            fileDisplayState = 2;
            ResortContentViewer();
        }

        private void catergoriseFileExtension(object sender, RoutedEventArgs e)
        {
            fileDisplayState = 0;
            ResortContentViewer();
        }

        private void categoriseName(object sender, RoutedEventArgs e)
        {
            fileDisplayState = 1;
            ResortContentViewer();
        }

        private void contentsListBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    addMediaItem(file);
                }
            }
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (isTimebarBeingDragged)
            {
                if (Application.Current.Windows.OfType<MediaWindow>().Any())
                {
                    MediaWindow mediaWindow = Application.Current.Windows.OfType<MediaWindow>().First();
                    if (mediaWindow.hasAnyMediaLoaded())
                    {
                        int timeToJump = (int)((timeBar.Value / 100) * mediaWindow.getMediaDuration());
                        JumpTimeWindow.jumpAt(timeToJump);
                    }
                }
                isTimebarBeingDragged = false;
            }
        }

        private void timeBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed && timeBar.IsMouseOver)
            {
                isTimebarBeingDragged = true;
            }
        }
    }
}
