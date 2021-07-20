using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncPlay {
    public class NetworkClient {
        private TcpClient client;
        private NetworkStream stream;
        private string ServerIP;
        private int Port;

        public NetworkClient(String server, int port) {
            ServerIP = server;
            Port = port;
        }

        public bool Connect() {
            try {
                client = new TcpClient(ServerIP, Port);
                stream = client.GetStream();
                var recievethread = new Thread(ProcessIncoming);
                recievethread.Start();
                return true;
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public void SendMessage(string Message) {
            Console.WriteLine(Message);
            var bytes = Encoding.ASCII.GetBytes(Message);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
        }

        private void ProcessIncoming() {
            while (stream != null) {
                try {
                    var msgbytes = new byte[1024];
                    var length = stream.Read(msgbytes, 0, msgbytes.Length);
                    var parts = Encoding.ASCII.GetString(msgbytes, 0, length)
                        .Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    for (int i = 0; i < parts.Length; i++) {
                        NotifySubscribersOnNewMessage(parts[i].Trim(' '));
                    }

                } catch (IOException e) {
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
            Console.WriteLine(message);
            if (OnNewMessage == null) return;
            OnNewMessage(this, message);
        }





    }
}
