using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay.EventArgs {
    public class UserRoomStateEventArgs {
        public string RoomName;
        public User User;
        
        public enum EventTypes {
            JOINED,
            LEFT
        }

        public EventTypes EventType;

        public void ParseType(string type) {
            switch (type) {
                case "joined":
                    EventType = EventTypes.JOINED;
                    break;

                case "left":
                    EventType = EventTypes.LEFT;
                    break;
            }
        }
    }
}
