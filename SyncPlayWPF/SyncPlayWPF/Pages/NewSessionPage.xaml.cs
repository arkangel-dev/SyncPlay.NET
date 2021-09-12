using SyncPlayWPF.SyncPlay;
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

namespace SyncPlayWPF.Pages {
    /// <summary>
    /// Interaction logic for NewSessionPage.xaml
    /// </summary>
    public partial class NewSessionPage : UserControl {
        public NewSessionPage() {
            InitializeComponent();
            this.Loaded += PageLoaded;
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            ServerAddressField.Text = Common.Shared.CurrentConfig.Element("Config").Element("Basics").Element("Address").Value;
            UsernameField.Text = Common.Shared.CurrentConfig.Element("Config").Element("Basics").Element("Username").Value;
            RoomNameField.Text = Common.Shared.CurrentConfig.Element("Config").Element("Basics").Element("RoomName").Value;
        }

        Pages.ApplicationPages.LoadingScreen LoadingPage = null;

        private void JoinRoom_Clicked(object sender, RoutedEventArgs e) {
            var serverIp = ServerAddressField.Text.Split(':')[0];
            var serverPort = Int32.Parse(ServerAddressField.Text.Split(':')[1]);
            var username = UsernameField.Text;
            var password = PasswordField.ActualPassword;
            var roomName = RoomNameField.Text;
            var connector = GetPlayerType(Common.Settings.GetCurrentConfigStringValue("Basics", "PathToMediaPlayer"));
            if (connector == null) {
                Common.Shared.NotificationLayer.CreateNotification("Incompatible Player", "The player you selected is not compatible with this version of SyncPlay.NET");
                return;
            }

            Common.Shared.Wrapper = new SyncPlayWrapper(serverIp, serverPort, username, password, roomName, connector);
            Common.Shared.Wrapper.SyncPlayClient.OnDisconnect += SyncPlayClient_OnDisconnect;
            Common.Shared.Wrapper.SyncPlayClient.ConnectAsync();
            Common.Shared.Wrapper.OnConnectonFailure += Wrapper_OnConnectonFailure;
            Common.Shared.Wrapper.OnConnectionSuccess += Wrapper_OnConnectionSuccess;
            LoadingPage = new Pages.ApplicationPages.LoadingScreen();
            Common.Shared.MasterOverrideTransition.ShowPage(LoadingPage);
        }

        private void Wrapper_OnConnectionSuccess(SyncPlayWrapper sender) {
            Dispatcher.Invoke(() => {
                Console.WriteLine("Connection established at connector");
                LoadingPage = null;
                Common.Shared.MasterOverrideTransition.UnloadCurrentPage();
                Common.Shared.MasterOverrideTransition.ShowPage(new ApplicationPages.Blank());
                Common.Shared.WindowPageTransition.ShowPage(new Pages.SessionLandingPage());

                Common.Shared.CurrentConfig.Element("Config").Element("Basics").Element("Address").Value = ServerAddressField.Text;
                Common.Shared.CurrentConfig.Element("Config").Element("Basics").Element("Username").Value = UsernameField.Text;
                Common.Shared.CurrentConfig.Element("Config").Element("Basics").Element("RoomName").Value = RoomNameField.Text;
                Common.Settings.WriteConfigurationToFile();
            });
        }

        private void Wrapper_OnConnectonFailure(SyncPlayWrapper sender) {
            Dispatcher.Invoke(() => {
                LoadingPage = null;
                Common.Shared.MasterOverrideTransition.UnloadCurrentPage();
                Common.Shared.MasterOverrideTransition.ShowPage(new ApplicationPages.Blank());
                Common.Shared.Wrapper.SyncPlayClient.OnDisconnect -= SyncPlayClient_OnDisconnect;
            });
            Common.Shared.Wrapper.Dispose();
        }

        private MediaPlayerInterface GetPlayerType(string path) {
            var exename = System.IO.Path.GetFileName(path);

            switch (exename) {
                case "mpvnet.exe":
                    return new SyncPlay.MediaPlayers.MPVPlayer.Connector();

                case "vlc.exe":
                    return new SyncPlay.MediaPlayers.VLCMediaPlayer.Connector();

                default:
                    return null;
            }
        }

        private void SyncPlayClient_OnDisconnect(SyncPlayClient sender, SyncPlay.SPEventArgs.ServerDisconnectedEventArgs e) {
            Console.WriteLine($"Failed to connect. Reasons --> : {e.ReasonForDisconnection}");
            Dispatcher.Invoke(() => {
                LoadingPage = null;
                Common.Shared.MasterOverrideTransition.UnloadCurrentPage();
                Common.Shared.MasterOverrideTransition.ShowPage(new ApplicationPages.Blank());
                Common.Shared.Wrapper.SyncPlayClient.OnDisconnect -= SyncPlayClient_OnDisconnect;
            });
            
            Common.Shared.NotificationLayer.CreateNotification("Server Disconnected", e.ReasonForDisconnection);
            Common.Shared.Wrapper.Dispose();
        }

       

        private void ShowMoreSettings_Clicked(object sender, RoutedEventArgs e) {
            Common.Shared.PreviousScreen = this;
            Common.Shared.WindowPageTransition.ShowPage(new Pages.SettingsPage());

            
        }
    }
}
