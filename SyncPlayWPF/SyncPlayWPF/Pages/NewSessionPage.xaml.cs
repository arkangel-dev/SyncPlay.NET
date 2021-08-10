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
        }

        private void JoinRoom_Clicked(object sender, RoutedEventArgs e) {

            var serverIp = ServerAddressField.Text.Split(':')[0];
            var serverPort = Int32.Parse(ServerAddressField.Text.Split(':')[1]);
            var username = UsernameField.Text;
            var password = PasswordField.ActualPassword;
            var roomName = RoomNameField.Text;

            Console.WriteLine(
                $"Server  : {serverIp}:{serverPort}\n" +
                $"Username  : {username}\n" +
                $"Password  : {password}\n" +
                $"Room Name : {roomName}");

            Common.Shared.Wrapper = new SyncPlayWrapper(
                serverIp,
                serverPort,
                username,
                password,
                roomName,
                new SyncPlay.MediaPlayers.MPVPlayer.Connector());

            Common.Shared.Wrapper.SyncPlayClient.OnConnect += SyncPlayClient_OnConnect;
            Common.Shared.Wrapper.SyncPlayClient.OnDisconnect += SyncPlayClient_OnDisconnect;

            Common.Shared.Wrapper.SyncPlayClient.ConnectAsync();
            Common.Shared.MasterOverrideTransition.ShowPage(new Pages.ApplicationPages.LoadingScreen());
            
        }

        private void SyncPlayClient_OnDisconnect(SyncPlayClient sender, SyncPlay.SPEventArgs.ServerDisconnectedEventArgs e) {
            Console.WriteLine($"Failed to connect. Reasons --> : {e.ReasonForDisconnection}");
            Dispatcher.Invoke(() => {
                Common.Shared.MasterOverrideTransition.UnloadCurrentPage();
                Common.Shared.Wrapper.SyncPlayClient.OnConnect -= SyncPlayClient_OnConnect;
                Common.Shared.Wrapper.SyncPlayClient.OnDisconnect -= SyncPlayClient_OnDisconnect;
            });
            
            Common.Shared.NotificationLayer.CreateNotification("Server Disconnected", e.ReasonForDisconnection);
            Common.Shared.Wrapper.Dispose();
        }

        private void SyncPlayClient_OnConnect(SyncPlayClient sender, SyncPlay.SPEventArgs.ServerConnectedEventArgs e) {
            Console.WriteLine("Connection established");
            Dispatcher.Invoke(() => {
                Common.Shared.MasterOverrideTransition.UnloadCurrentPage();
                Common.Shared.WindowPageTransition.ShowPage(new Pages.SessionLandingPage());
            });
        }
    }
}
