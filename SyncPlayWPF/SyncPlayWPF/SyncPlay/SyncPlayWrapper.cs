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
            Player = mp;

            mp.OnSeek += SyncPlayClient.SetPlayPosition;
            mp.OnPauseStateChange += SyncPlayClient.SetPause;
            mp.OnNewFileLoad += NewFileLoad;

            SyncPlayClient.OnPlayerStateChange += PlayerStateChanged;
            
            
            mp.StartPlayerInstance();
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
