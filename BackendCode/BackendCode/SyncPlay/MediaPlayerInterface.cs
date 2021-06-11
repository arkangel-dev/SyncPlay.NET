using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay {
    public interface MediaPlayerInterface {
        event ChatPacketHandler OnNewChatMessage;
        delegate void ChatPacketHandler(EventArgs.ChatMessageEventArgs e);
    }
}
