using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay.EventArgs {
    public class LocalStateChangeEventArgs {
        public float Positon;
        public bool isPaused;
        public bool Seeked;
    }
}
