using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay {
    public class User {
        public string Username;
        public string Room;
        public bool IsReady;
        public bool IsPaused;
        public float Position;
        public MediaFile File;

        public User() {
            this.Username = "";
            this.Room = "";
            this.IsPaused = true;
            this.IsReady = false;
            this.Position = 0.0f;
        }

        public override string ToString() {
            return this.Username;
        }
    }
}
