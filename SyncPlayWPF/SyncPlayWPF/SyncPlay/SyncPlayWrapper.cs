using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay {
    public class SyncPlayWrapper {
        public SyncPlayClient SClient;
        public MediaPlayerInterface Player;
        public int RemoteSeekOffset = 1;

        public SyncPlayWrapper(string serverip, int port, string username, string password, string room, MediaPlayerInterface mp) {
            this.SClient = new SyncPlayClient(serverip, port, username, password, room, "1.6.8");
            Player = mp;

            mp.OnSeek += SClient.SetPlayPosition;
            mp.OnPauseStateChange += SClient.SetPause;

            SClient.OnPlayerStateChange += PlayerStateChanged;
            
            mp.StartPlayerInstance();
        }

        private void PlayerStateChanged(SyncPlayClient sender, EventArgs.RemoteStateChangeEventArgs e) {
            Player.SetPauseState(e.Paused);
            Player.SetPosition(e.Position + RemoteSeekOffset);
        }
    }
}
