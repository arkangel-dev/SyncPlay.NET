using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SyncPlayWPF.Pages {
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : System.Windows.Controls.UserControl {
        public SettingsPage() {
            InitializeComponent();
            this.Loaded += PageLoaded;
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            Common.Settings.WriteConfigurationToView(this);
        }

        private void CancelConfigurationButton_Click(object sender, RoutedEventArgs e) {
            Common.Shared.WindowPageTransition.ShowPage(Common.Shared.PreviousScreen);
        }

        public void EnableNoReturn() {
            CancelConfigurationButton.Visibility = Visibility.Collapsed;
        }

        private void RestoreDefault(object sender, RoutedEventArgs e) {
            Common.Settings.RestoreDefaultConfiguration();
        }

        private void SaveConfiguration(object sender, RoutedEventArgs e) {
            Common.Settings.ReadConfigurationFromView(this);
            Common.Settings.DefineSharedSettings();
            Common.Shared.WindowPageTransition.ShowPage(Common.Shared.PreviousScreen);
        }

        private void MediaPlayerBrowse_Click(object sender, RoutedEventArgs e) {
            var of_dialog = new OpenFileDialog();
            of_dialog.Filter = "Exe Files (.exe)|*.exe";
            of_dialog.Title = "Open media player";
            if (of_dialog.ShowDialog() == DialogResult.OK) {
                PathToMediaPlayer.Text = of_dialog.FileName;
            }
            
        }
    }
}
