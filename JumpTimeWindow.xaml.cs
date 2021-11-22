using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MultiScreener_Media
{
    /// <summary>
    /// Interaction logic for JumpTimeWindow.xaml
    /// </summary>
    public partial class JumpTimeWindow : Window
    {
        public JumpTimeWindow()
        {
            InitializeComponent();
        }

        private void timeTextbox_KeyUp(object sender, KeyEventArgs e)
        {       
            if(e.Key == Key.Enter)
            {
                string[] timeformats = { @"m\:ss", @"mm\:ss", @"h\:mm\:ss" };
                if (!TimeSpan.TryParseExact(timeTextbox.Text, timeformats, CultureInfo.InvariantCulture, out TimeSpan result))
                {
                    MessageBox.Show("Invalid time!", "Jump at...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                if (Application.Current.Windows.OfType<MediaWindow>().Count() != 0)
                {
                    MediaWindow mediaWindow = Application.Current.Windows.OfType<MediaWindow>().First();
                    if(mediaWindow.isPlaying())
                    {
                        mediaWindow.jumpAt((long)result.TotalMilliseconds);
                    }
                }
                this.Close();
            }
        }

        private void timeTextbox_Loaded(object sender, RoutedEventArgs e)
        {
            timeTextbox.Focus();
        }
    }
}
