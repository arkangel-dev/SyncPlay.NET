using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncPlay {
    public class NetworkClient {
        private TcpClient client;
        private SslStream SSL;
        private NetworkStream stream;
        private string Host;
        private int Port;

        public NetworkClient(String server, int port) {
            Host = server;
            Port = port;
        }

        public bool IsConnected() {
            if (this.client != null) {
                return this.client.Connected;
            } else {
                return false;
            }
        }           

        public bool Connect() {
            client = new TcpClient();
            var result = client.BeginConnect(Host, Port, null, null);

            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
            if (!success) {
                return false;
            }
            stream = client.GetStream();
            var recievethread = new Thread(ProcessIncoming);
            recievethread.IsBackground = true;
            recievethread.Start();
            return true;
        }


        public void Disconnect() {
            this.client.GetStream().Close();
            this.client.Close();
        }

        public void ActivateTLS() {
            this.SSL = new SslStream(stream);
            this.SSL.AuthenticateAsClient(this.Host);
        }

        public void SendMessage(string Message) {
            //Console.WriteLine(Message);
            if (SSL == null) {
                var bytes = Encoding.ASCII.GetBytes(Message);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            } else {
                var bytes = Encoding.ASCII.GetBytes(Message);
                SSL.Write(bytes, 0, bytes.Length);
                SSL.Flush();
            }
        }

        private void ProcessIncoming() {
            while (stream != null) {
                try {
                    var msgbytes = new byte[1024];

                    var length = 0;
                    if (SSL != null) {
                        length = SSL.Read(msgbytes, 0, msgbytes.Length);
                    } else {
                        length = stream.Read(msgbytes, 0, msgbytes.Length);
                    }
                    
                    var parts = Encoding.ASCII.GetString(msgbytes, 0, length)
                        .Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    for (int i = 0; i < parts.Length; i++) {
                        NotifySubscribersOnNewMessage(parts[i].Trim(' '));
                    }

                } catch (Exception e) {
                    Misc.Common.PrintInColor("Stream broken!", ConsoleColor.Red);
                    Misc.Common.PrintInColor(e.Message, ConsoleColor.Red);
                    Misc.Common.PrintInColor(e.StackTrace, ConsoleColor.Red);
                    break;
                }
            }
        }

        public delegate void IncomingMessageHandler(NetworkClient sender, String message);
        public event IncomingMessageHandler OnNewMessage;
   

        private void NotifySubscribersOnNewMessage(String message) {
            if (String.IsNullOrWhiteSpace(message)) return;
            //Misc.Common.PrintInColor(message, ConsoleColor.Yellow);
            //Console.WriteLine(message);
            if (OnNewMessage == null) return;
            OnNewMessage(this, message);
        }





    }
}
