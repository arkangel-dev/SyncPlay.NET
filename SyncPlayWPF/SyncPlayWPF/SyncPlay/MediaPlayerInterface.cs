using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay {
    public interface MediaPlayerInterface {

        void StartPlayerInstance();
        void Pause();
        void Play();
        void SetPosition(float f);
        void SetPauseState(bool p);
        bool IsPaused();
        void ClosePlayer();




        delegate void HandleDebugMessages(string s);
        event HandleDebugMessages OnDebugMessage;

        delegate void HandleVLCServerMessages(string s);
        event HandleVLCServerMessages OnPlayerMessage;

        delegate void HandleFileLoadEvent(SPEventArgs.NewFileLoadEventArgs e);
        event HandleFileLoadEvent OnNewFileLoad;

        delegate void HandleSeek(float position);
        event HandleSeek OnSeek;

        delegate void HandlePauseState(bool paused);
        event HandlePauseState OnPauseStateChange;

        delegate void HandlePlayerClosed();
        event HandlePlayerClosed OnPlayerClosed;

    }
}
