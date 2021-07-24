using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay.EventArgs {
    public class ServerDisconnectedEventArgs {
        public bool ServerKicked;
        public string ReasonForKick;

        public ServerDisconnectedEventArgs(bool server_kick, string reason_for_kick) {
            this.ServerKicked = server_kick;
            this.ReasonForKick = reason_for_kick;
        }
    }
}
