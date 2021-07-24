using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay {
    public class SyncPlayWrapper {
        public SyncPlayClient SyncPlayClient;
        public MediaPlayerInterface Player;
        public int RemoteSeekOffset = 1;

        public SyncPlayWrapper(string serverip, int port, string username, string password, string room, MediaPlayerInterface mp) {
            this.SyncPlayClient = new SyncPlayClient(serverip, port, username, password, room, "1.6.8");

            this.Player = mp;

            SyncPlayClient.OnPlayerStateChange += PlayerStateChanged;
            SyncPlayClient.OnConnect += SyncPlayClient_OnConnect;

            
        }

        private void SyncPlayClient_OnConnect(SyncPlayClient sender, EventArgs.ServerConnectedEventArgs e) {
            this.Player.OnSeek += SyncPlayClient.SetPlayPosition;
            this.Player.OnPauseStateChange += SyncPlayClient.SetPause;
            this.Player.OnNewFileLoad += NewFileLoad;
            this.Player.StartPlayerInstance();
        }

        private void NewFileLoad(EventArgs.NewFileLoadEventArgs e) {
            SyncPlayClient.AddFileToPlayList(e.AbsoluteFilePath);
        }

        private void PlayerStateChanged(SyncPlayClient sender, EventArgs.RemoteStateChangeEventArgs e) {
            Player.SetPauseState(e.Paused);
            Player.SetPosition(e.Position + RemoteSeekOffset);
        }
    }
}
