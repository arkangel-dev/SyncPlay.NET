using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay {
    public interface MediaPlayerInterface {
        event PlayerStateChangeHandler OnPlayerStateChange;
        delegate void PlayerStateChangeHandler(EventArgs.LocalStateChangeEventArgs e);

        event PlayerFileChangeHandler OnPlayerFileChange;
        delegate void PlayerFileChangeHandler(EventArgs.LocalSetFileEventArgs e);

        void Pause();
        void Play();
        void SetPosition(float f);
    }
}
