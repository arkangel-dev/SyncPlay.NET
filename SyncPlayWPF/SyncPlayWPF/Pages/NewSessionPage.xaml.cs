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

            Common.Shared.Wrapper = new SyncPlay.SyncPlayWrapper(
                serverIp,
                serverPort,
                username,
                password,
                roomName,
                new SyncPlay.MediaPlayers.VLCMediaPlayer.Connector());

            Common.Shared.WindowPageTransition.ShowPage(new Pages.SessionLandingPage());
            

        }
    }
}
