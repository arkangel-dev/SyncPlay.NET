using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncPlay.MediaPlayers.VLCMediaPlayer  {
    class Connector : MediaPlayerInterface {


        private Process PlayerProcess;
        private List<String> MessageList = new List<string>();
        private TcpClient client;
        private NetworkStream stream;
        private bool Paused = true;


       
        private void StartVLCServer() {
            this.PlayerProcess = System.Diagnostics.Process.Start("\"C:\\Program Files\\VideoLAN\\VLC\\vlc.exe\"", "--extraintf rc --rc-host localhost:5002 --rc-quiet");
        }
        private void ConnectToVLCServer() {
            client = new TcpClient("127.0.0.1", 5002);
            stream = client.GetStream();

            var handle_msg = new Thread(() => { HandleMessages(); });
            handle_msg.IsBackground = true;
            handle_msg.Start();

            var writetonetwork = new Thread(() => { WriteToNetworkStream(); });
            writetonetwork.IsBackground = true;
            writetonetwork.Start();


            OnPlayerMessage += ParseMessages;

        }
        private void ParseMessages(string s) {
            var parts = s.Split();
            var keyword = parts[3];
  
            switch (keyword) {
                case "pause":
                    if (parts[5] != "3") return;
                    if (OnPauseStateChange == null) return;
                    OnPauseStateChange(true);
                    Paused = true;
                    break;

                case "play":
                    if (parts[5] != "3") return;
                    if (OnPauseStateChange == null) return;
                    OnPauseStateChange(false);
                    Paused = false;
                    break;

                case "time:":
                    if (OnSeek == null) return;
                    var position = Int32.Parse(String.Join("", parts[4]
                        .ToList()
                        .GetRange(0, parts[4].Length - 1)));
                    OnSeek(position); 
                    break;

                case "new":
                    Paused = true;
                    if (parts[4] == "input:") {
                        var absolute_path = new Uri(parts[5]).LocalPath;
                        var file_name = Path.GetFileName(absolute_path);
                        OnNewFileLoad?.Invoke(new EventArgs.NewFileLoadEventArgs(file_name, absolute_path));
                    }
                    break;
            }
        }
        private void WriteToNetworkStream() {
            try {
                while (stream != null) {
                    var pending_msg = String.Join("\n", MessageList.ToArray());
                    var msg_bytes = Encoding.ASCII.GetBytes(pending_msg);
                    stream.Write(msg_bytes, 0, msg_bytes.Length);
                    MessageList.Clear();
                    MessageList.Add("\n");
                    Thread.Sleep(100);
                }
            } catch (Exception e) {
                Debug("Heartbeat and Polling Loop Broken");
                OnPlayerClosed?.Invoke();
            }
        }
        private void HandleMessages() {
            try {
                while (stream != null) {
                    var msg_buffer = new Byte[256];
                    var st_len = stream.Read(msg_buffer, 0, msg_buffer.Length);
                    var ascii_msg = Encoding.ASCII.GetString(msg_buffer, 0, st_len);
                    OnPlayerMessage(ascii_msg);
                }
            } catch (Exception e) {
                Debug("Message Handler Loop Broken");
                OnPlayerClosed?.Invoke();
            }
        }
        public void Pause() {
            if (!Paused) {
                AddToPendingMessages("pause");
                Paused = true;
            }
        }
        public void Play() {
            if (Paused) {
                AddToPendingMessages("pause");
                Paused = false;
            }
        }

        public void AddToPendingMessages(string command) {
            this.MessageList.Add(command);
        }

        private void Debug(string s) {
            if (OnDebugMessage != null) {
                OnDebugMessage(s);
            }
        }

        public void StartPlayerInstance() {
            StartVLCServer();
            ConnectToVLCServer();
        }

        public void SetPosition(float f) {
            this.AddToPendingMessages($"seek {(int)f}");
        }

        public bool IsPaused() {
            return this.Paused;
        }

        public void SetPauseState(bool p) {
            if (p) {
                this.Pause(); 
            } else {
                this.Play();
            }
        }

        public void ClosePlayer() {
            if (this.PlayerProcess != null)
                this.PlayerProcess.Kill();
        }

        public event MediaPlayerInterface.HandleDebugMessages OnDebugMessage;
        public event MediaPlayerInterface.HandleVLCServerMessages OnPlayerMessage;
        public event MediaPlayerInterface.HandleFileLoadEvent OnNewFileLoad;
        public event MediaPlayerInterface.HandleSeek OnSeek;
        public event MediaPlayerInterface.HandlePauseState OnPauseStateChange;
        public event MediaPlayerInterface.HandlePlayerClosed OnPlayerClosed;
    }
}
