using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay.MediaPlayers.MPVPlayer {
    public class Connector : MediaPlayerInterface {
        public event MediaPlayerInterface.HandleDebugMessages OnDebugMessage;
        public event MediaPlayerInterface.HandleVLCServerMessages OnPlayerMessage;
        public event MediaPlayerInterface.HandleFileLoadEvent OnNewFileLoad;
        public event MediaPlayerInterface.HandleSeek OnSeek;
        public event MediaPlayerInterface.HandlePauseState OnPauseStateChange;
        public event MediaPlayerInterface.HandlePlayerClosed OnPlayerClosed;


        public void ClosePlayer() {
            throw new NotImplementedException();
        }

        public bool IsPaused() {
            this.WritePipe.WriteLine(MPVPackets.CraftGetPauseState());
            Task.WaitAll(ReadTask);
            var jobj = JObject.Parse(ReadTask.Result);
            return jobj.Value<bool>("data");
        }

        public void Pause() {
            this.WritePipe.WriteLine(MPVPackets.CraftPausePacket());
        }

        public void Play() {
            this.WritePipe.WriteLine(MPVPackets.CraftPlayPacket());
        }

        public void SetPauseState(bool p) {
            this.WritePipe.WriteLine(MPVPackets.CraftPauseStatePacket(p));
        }

        public void SetPosition(float f) {
            this.WritePipe.WriteLine(MPVPackets.CraftSeekAbsolutePacket(f));
        }

        public void StartPlayerInstance() {
            StartMPVINstance();
            Thread.Sleep(100);
            ConnectToMPVInstance();
            var readThread = new Thread(() => {
                ReadData();
            });
            readThread.IsBackground = true;
            readThread.Start();
        }

        

        /// END OF INTERFACE STUFF
        private Process PlayerProcess;
        private StreamReader ReadPipe;
        private StreamWriter WritePipe;
        private NamedPipeClientStream pipe;

        private Task<string> ReadTask;
        
        private void StartMPVINstance() {
            this.PlayerProcess = Process.Start("C:\\Program Files\\mpv.net\\mpvnet.exe", "--input-ipc-server=//./empeevee --idle");
        }

        private void ConnectToMPVInstance() {
            pipe = new NamedPipeClientStream(".", "empeevee", PipeDirection.InOut, PipeOptions.Asynchronous, TokenImpersonationLevel.Anonymous);
            ReadPipe = new StreamReader(pipe);
            WritePipe = new StreamWriter(pipe);
        }

        private void ReadData() {
            while (pipe.IsConnected) {
                ReadTask = ReadPipe.ReadLineAsync();
                Task.WaitAny(ReadTask);
                ProcessIncomingData(ReadTask.Result);
            }
        }


        private void ProcessIncomingData(String json) {

        } 
    }
}
