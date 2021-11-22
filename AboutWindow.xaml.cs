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
using System.Windows.Shapes;

namespace MultiScreener_Media
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void visitWebsite_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Brilliafy/MultiScreener-Media");
        }

        private void aboutWindow_Loaded(object sender, RoutedEventArgs e)
        {
            versionLabel.Text = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            System.Media.SystemSounds.Beep.Play();
        }
    }
}
