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

            Common.Shared.ChatPageSingleton = new Pages.SessionPages.ChatSession();
            ShowChatWindow();
            this.Loaded += PageLoaded;
        }

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

        private void ShowChatWindow() {
            SessionPageWindow.ShowPage(Common.Shared.ChatPageSingleton);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e) {
            Common.Shared.Wrapper.SyncPlayClient.SetReadyState((bool)ReadyToggle.IsChecked);
        }

        private void ToggleSidePanel(object sender, RoutedEventArgs e) {
            throw new Exception("Test Exception");
        }
    }
}
