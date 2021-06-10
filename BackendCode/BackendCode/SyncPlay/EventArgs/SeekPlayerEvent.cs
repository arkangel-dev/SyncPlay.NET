using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay.EventArgs {
    public class SeekPlayerEvent {
        public User Agent;
        public float Position;

        public SeekPlayerEvent(User agent, float position) {
            Agent = agent;
            Position = position;
        }
    }
}
