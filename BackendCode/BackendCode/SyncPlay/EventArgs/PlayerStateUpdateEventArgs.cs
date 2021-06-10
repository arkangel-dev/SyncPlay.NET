using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay.EventArgs {
    public class PlayerStateUpdateEventArgs {
        public bool Paused;
        public float Position;

        public PlayerStateUpdateEventArgs(bool paused, float position) {
            Paused = paused;
            Position = position;
        }
    }
}
