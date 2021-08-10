using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay.SPEventArgs {
    public class RemoteStateChangeEventArgs {
        public User Agent;
        public bool Seeked;
        public bool Paused;
        public float Position;


        public RemoteStateChangeEventArgs() {

        }

        public RemoteStateChangeEventArgs(bool paused, float position) {
            Paused = paused;
            Position = position;
        }
    }
}
