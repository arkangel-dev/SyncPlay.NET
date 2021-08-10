using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay.SPEventArgs {
    public  class ChatMessageEventArgs {
        public User Sender;
        public String Message;
        public bool LocallySentMessage;

        public ChatMessageEventArgs(User _sender, String _message) {
            Sender = _sender;
            Message = _message;
        }
    }
}
