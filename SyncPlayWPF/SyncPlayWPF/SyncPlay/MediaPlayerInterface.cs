using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay {
    public interface MediaPlayerInterface {

        void StartPlayerInstance();
        void Pause();
        void Play();
        void SetPosition(float f);
        void SetPauseState(bool p);
        bool IsPaused();




        delegate void HandleDebugMessages(string s);
        event HandleDebugMessages OnDebugMessage;

        delegate void HandleVLCServerMessages(string s);
        event HandleVLCServerMessages OnPlayerMessage;

        delegate void HandleFileLoadEvent(string s);
        event HandleFileLoadEvent OnNewFileLoad;

        delegate void HandleSeek(float position);
        event HandleSeek OnSeek;

        delegate void HandlePauseState(bool paused);
        event HandlePauseState OnPauseStateChange;


    }
}
