using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay {
    /// <summary>
    /// This class defines the user that connects to the server...
    /// </summary>
    public class User {
        public string Username;
        public string Room;
        public bool IsReady;
        public bool IsPaused;
        public float Position;
        public MediaFile File;

        /// <summary>
        /// Constructor for this class
        /// </summary>
        public User() {
            this.Username = "";
            this.Room = "";
            this.IsPaused = true;
            this.IsReady = false;
            this.Position = 0.0f;
        }

        /// <summary>
        /// Skedadle skedoodle... your class is now a string
        /// </summary>
        /// <returns>Name of the username</returns>
        public override string ToString() {
            return this.Username;
        }
    }
}
