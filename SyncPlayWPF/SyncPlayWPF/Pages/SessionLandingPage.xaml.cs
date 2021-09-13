using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SyncPlayWPF.Pages {
    /// <summary>
    /// Interaction logic for SessionLandingPage.xaml
    /// </summary>
    public partial class SessionLandingPage : UserControl {
        public SessionLandingPage() {
            InitializeComponent();

            this.ChatPageSingleton = new Pages.SessionPages.ChatSession();
            SessionPageWindow.ShowPage(this.ChatPageSingleton);
            this.Loaded += PageLoaded;
        }

        private UserControl ChatPageSingleton;
        private UserControl SettingsPageSingleton;

        private void PageLoaded(object sender, RoutedEventArgs e) {          
            Common.Shared.Wrapper.Player.OnPlayerClosed += delegate {
                ThreadStart ts = delegate () {
                    Dispatcher.BeginInvoke((Action)delegate () {
                        Application.Current.Shutdown();
                    });
                };
                Thread t = new Thread(ts);
                t.Start();
            };
            Common.Shared.MasterWindow.SizeChanged += MasterWindow_SizeChanged;
        }

        private void MasterWindow_SizeChanged(object sender, SizeChangedEventArgs e) {
            if (e.NewSize.Width <= 400) {
                SidePanel.Visibility = Visibility.Collapsed;
            } else {
                SidePanel.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e) {
            Common.Shared.Wrapper.SyncPlayClient.SetReadyState((bool)ReadyToggle.IsChecked);
        }

        private void ToggleSidePanel(object sender, RoutedEventArgs e) {
            Common.Shared.MasterLogDump.Save();
        }

        private void SidePanelButtonClick(object sender, RoutedEventArgs e) {
            switch (((CustomControls.ImageButton)sender).Name) {
                case "ChatSideButton":
                    SessionPageWindow.ShowPage(this.ChatPageSingleton);

                    break;

                case "SettingsSideButton":
                    if (this.SettingsPageSingleton == null) {
                        this.SettingsPageSingleton = new Pages.SettingsPage();
                        ((Pages.SettingsPage)(this.SettingsPageSingleton)).EnableNoReturn();
                    }
                    SessionPageWindow.ShowPage(this.SettingsPageSingleton);
                    break;

                case "AboutSideButton":
                    SessionPageWindow.ShowPage(new Pages.ApplicationPages.AboutPage());
                    break;

                default:
                    Console.WriteLine("Side Panel Button not Programmed...");
                    break;
            }
        }

        
    }
}
