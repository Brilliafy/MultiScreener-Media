using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfScreenHelper;

namespace MultiScreener_Media
{
    /// <summary>
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern bool DeleteObject(IntPtr hObject);
        public bool isConnected = false;
        public VideoView vlcPlayer;
        public LibVLCSharp.Shared.MediaPlayer _mp;

        public MediaWindow mediaWindow;

        bool inDrag = false;
        System.Windows.Point anchorPoint;


        /// <summary>
        /// Struct representing a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator System.Windows.Point(POINT point)
            {
                return new System.Windows.Point(point.X, point.Y);
            }
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static System.Windows.Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            // NOTE: If you need error handling
            // bool success = GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

        public PreviewWindow()
        {
            InitializeComponent();
        }

        private void backGrid_Loaded(object sender, RoutedEventArgs e)
        {
            vlcPlayer = new LibVLCSharp.WinForms.VideoView
            {
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 0),
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(new System.Drawing.Point((int)windowsForms.Width, (int)windowsForms.Height))
            };
            mediaWindow = Application.Current.Windows.OfType<MediaWindow>().FirstOrDefault();
            mediaWindow?.requestPreviewSync();
        }

        public bool ConnectWithScreen()
        {
            if (Screen.AllScreens.Count() != 1)
            {
                Height = Screen.AllScreens.ElementAt(1).Bounds.Height / 3;
                Width = Screen.AllScreens.ElementAt(1).Bounds.Width / 3;
                isConnected = true;
                vlcPlayer = new LibVLCSharp.WinForms.VideoView();
                _mp = new LibVLCSharp.Shared.MediaPlayer(MediaWindow._libVLC);
                vlcPlayer.MediaPlayer = _mp;
                windowsForms.Child = vlcPlayer;
                vlcPlayer.MediaPlayer.EnableMouseInput = false;
                vlcPlayer.MediaPlayer.EnableKeyInput = false;
                vlcPlayer.MediaPlayer.Volume = 0;

                if (mediaWindow.isPlaying())
                {
                    copyMedia();
                }
                return true;
            }
            return false;
        }

        public void copyMedia()
        {
            vlcPlayer.MediaPlayer.Play(mediaWindow.vlcPlayer.MediaPlayer.Media);
            vlcPlayer.MediaPlayer.Time = mediaWindow.vlcPlayer.MediaPlayer.Time;
        }

        public void syncroniseSource(string mrl)
        {
            //vlcPlayer.MediaPlayer.Stop();

            vlcPlayer.MediaPlayer.Media = new Media(MediaWindow._libVLC, mrl);
            vlcPlayer.MediaPlayer.Play();
        }

        public void syncroniseTime(long newTime)
        {
            vlcPlayer.MediaPlayer.Time = newTime;
        }

        public void syncroniseStatus(bool isPaused)
        {
            if (isPaused)
            {
                vlcPlayer.MediaPlayer.Pause();
            }
            else
            {
                vlcPlayer.MediaPlayer.Play();
            }
        }

        public void stopMedia()
        {
            vlcPlayer.MediaPlayer.EnableMouseInput = true;
            vlcPlayer.MediaPlayer.Stop();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            anchorPoint = GetCursorPosition();
            inDrag = true;
            CaptureMouse();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (inDrag)
            {
                System.Windows.Point currentPoint = GetCursorPosition();
                this.Left = this.Left + currentPoint.X - anchorPoint.X;
                this.Top = this.Top + currentPoint.Y - anchorPoint.Y;
                anchorPoint = currentPoint;
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (inDrag)
            {
                ReleaseMouseCapture();
                inDrag = false;
                e.Handled = true;
            }
        }

        override protected void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            backGrid.ContextMenu.IsOpen = true;
            e.Handled = true;
        }

        private void closeWindowContextItem(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
