using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay {
    public interface MediaPlayerInterface {

        bool StartPlayerInstance();
        void Pause();
        void Play();
        void SetPosition(float f);
        float GetPosition();
        void SetPauseState(bool p);
        bool IsPaused();
        void ClosePlayer();
        void DisplayOSDMessage(string msg);





        delegate void HandleDebugMessages(string s);
        event HandleDebugMessages OnDebugMessage;

        delegate void HandlePlayerServerMessages(string s);
        event HandlePlayerServerMessages OnPlayerMessage;

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
