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
        public event MediaPlayerInterface.HandlePlayerServerMessages OnPlayerMessage;
        public event MediaPlayerInterface.HandleFileLoadEvent OnNewFileLoad;
        public event MediaPlayerInterface.HandleSeek OnSeek;
        public event MediaPlayerInterface.HandlePauseState OnPauseStateChange;
        public event MediaPlayerInterface.HandlePlayerClosed OnPlayerClosed;


        public void ClosePlayer() {
            this.PlayerProcess.Kill();
        }

        public bool IsPaused() {
            var req_id = GetRequestNewID();
            this.WritePipe.WriteLine(MPVPackets.CraftGetPauseStatePacket(req_id));
            var jobj = AwaitForResponse(req_id);
            return jobj.Value<bool>("data");
        }

        public void Pause() {
            this.WriteData(MPVPackets.CraftPausePacket(GetRequestNewID()));
        }

        public void Play() {
            this.WriteData(MPVPackets.CraftPlayPacket(GetRequestNewID()));
        }

        public void SetPauseState(bool p) {
            this.WriteData(MPVPackets.CraftPauseStatePacket(p, GetRequestNewID()));
        }

        public void SetPosition(float f) {
            this.WriteData(MPVPackets.CraftSeekAbsolutePacket(f, GetRequestNewID()));
        }

        public void StartPlayerInstance() {
            StartMPVINstance();
            Thread.Sleep(500);
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
            this.PlayerProcess = Process.Start("C:\\Program Files\\mpv.net\\mpvnet.exe", "--input-ipc-server=//./pipee");
        }

        private void ConnectToMPVInstance() {
            pipe = new NamedPipeClientStream(".", "pipee", PipeDirection.InOut, PipeOptions.Asynchronous, TokenImpersonationLevel.Anonymous);
            pipe.Connect();
            ReadPipe = new StreamReader(pipe);
            WritePipe = new StreamWriter(pipe);
            WritePipe.AutoFlush = true;

            Thread.Sleep(300);

            // Send Requests to observe the stuff we want
            this.WriteData(MPVPackets.CraftObservePropertyPacket("pause", 1, GetRequestNewID()));
            this.WriteData(MPVPackets.CraftObservePropertyPacket("seeking", 2, GetRequestNewID()));
            this.WriteData(MPVPackets.CraftObservePropertyPacket("filename", 3, GetRequestNewID()));
        }

        private void ReadData() {
            for (int i = 0; i < 3; i++) {
                ReadPipe.ReadLine();
            }
            while (pipe.IsConnected) {
                ReadTask = ReadPipe.ReadLineAsync();
                Task.WaitAny(ReadTask);
                var pthread = new Thread(() => { ProcessIncomingData(ReadTask.Result); });
                pthread.IsBackground = true;
                pthread.Start();
            }
            Debug("Read Thread Closed");
            OnPlayerClosed?.Invoke();
        }


        private void ProcessIncomingData(String json) {

            Debug(" << " + json);
            try {
                var json_obj = JObject.Parse(json);

                if (json_obj.ContainsKey("event")) {
                    if (json_obj.Value<string>("event") == "property-change") {
                        switch (json_obj.Value<string>("name")) {

                            case "pause":
                                Console.WriteLine("Pause State Change");
                                var switch_state = json_obj.Value<bool>("data");
                                OnPauseStateChange?.Invoke(switch_state);
                                break;

                            case "seeking":
                                Console.WriteLine("Seeking Change");
                                GetCurrentPosAndNotify();
                                break;

                            case "filename":
                                Console.WriteLine("File change");
                                GetCurrentFileAndNotify();
                                break;

                        }
                    }
                }
            } catch (Exception e) {

            }
        } 

        private void GetCurrentPosAndNotify() {
            var req_id = GetRequestNewID();
            WriteData(MPVPackets.CraftGetCurrentPlayPositionPacket(req_id));
            var json_obj = AwaitForResponse(req_id);
            var position = json_obj.Value<float>("data");
            this.OnSeek?.Invoke(position);
        }

        private void GetCurrentFileAndNotify() {
            Thread.Sleep(500);
            var arg = new SyncPlay.SPEventArgs.NewFileLoadEventArgs();
            arg.AbsoluteFilePath = GetCurrentFilePath().Replace("\\\\", "\\");
            arg.Duration = GetCurrentFileDuration();
            arg.FileName = GetCurrentFileName();
            arg.Size = GetCurrentFileSize();

            if (!String.IsNullOrEmpty(arg.AbsoluteFilePath)) {
                this.OnNewFileLoad?.Invoke(arg);
            }
        }

        private JObject AwaitForResponse(int request_id) {
            JObject json_obj = null;
            while (true) {
                Task.WaitAll(this.ReadTask);
                json_obj = JObject.Parse(this.ReadTask.Result);
                if (json_obj.Value<int>("request_id") == request_id) break;
            }
            Debug("Request Match : " + json_obj.ToString(Newtonsoft.Json.Formatting.None));
            return json_obj;
        }

        private string GetCurrentFileName() {
            var request_id = GetRequestNewID();
            WriteData(MPVPackets.CraftGetFileNamePacket(request_id));
            var json_obj = AwaitForResponse(request_id);
            return json_obj.Value<string>("error") != "success" ? "" : json_obj.Value<string>("data");
        }

        private float GetCurrentFileDuration() {
            var request_id = GetRequestNewID();
            WriteData(MPVPackets.CraftGetFileDurationPacket(request_id));
            var json_obj = AwaitForResponse(request_id);
            return json_obj.Value<string>("error") != "success" ? 0.0f : json_obj.Value<float>("data");
        }

        private int GetCurrentFileSize() {
            var request_id = GetRequestNewID();
            WriteData(MPVPackets.CraftGetFileSizePacket(request_id));
            var json_obj = AwaitForResponse(request_id);
            return json_obj.Value<string>("error") != "success" ? 0 : json_obj.Value<int>("data");
        }

        private string GetCurrentFilePath() {
            var request_id = GetRequestNewID();
            WriteData(MPVPackets.CraftGetFilePathPacket(request_id));
            var json_obj = AwaitForResponse(request_id);
            return json_obj.Value<string>("error") != "success" ? "" : json_obj.Value<string>("data");
        }

        private void WriteData(string s) {
            Debug(" >> " + s);
            if (pipe.IsConnected) {
                this.WritePipe.WriteLine(s);
            }
        }

        private int req_counter = 0;
        private int GetRequestNewID() {
            req_counter++;
            return req_counter;
        }

        private void Debug(string s) {
            Console.WriteLine("[MPV] " + s);
        }
    }
}
