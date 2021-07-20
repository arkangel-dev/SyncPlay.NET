using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay.EventArgs {
    public class ChatInfoMessageArgs {
        public string Message;
        public SyncPlay.User User;
        
        public ChatInfoMessageArgs(User u, string msg) {
            this.Message = msg;
            this.User = u;
        }
    }
}
