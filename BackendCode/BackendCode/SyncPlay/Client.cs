
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay {
    class Client {
        private NetworkClient client;
        public string Username;
        public string Roomname;
        public string motd;

        public bool Joined;
        public bool isolateRooms;
        public bool managedRooms;
        public bool chat;

        public int MaxChatLength;
        public int MaxRoomnameLength;
        public int MaxFileNameLength;

        private string HelloMessage = "";

        private PingService pingService;

        public Client(String serverip, int port, String username, String password, String roomname, String version) {
            client = new NetworkClient(serverip, port);
            pingService = new PingService();
            client.Connect();
            HelloMessage = Packets.CraftIdentificationMessage(username, password, roomname, version);
            client.OnNewMessage += NewIncomingMessage;
            client.SendMessage(Packets.CraftTLS());
        }

        private void NewIncomingMessage(NetworkClient sender, string message) {
     
            if (String.IsNullOrWhiteSpace(message)) return;
            var jobj = JObject.Parse(message);


            if (jobj.ContainsKey("TLS")) {
                client.SendMessage(HelloMessage);
            }

            if (jobj.ContainsKey("Hello")) {
                client.SendMessage(Packets.CraftSetClientReadiness(false, false));
                client.SendMessage(Packets.CraftSendList());
            }

            if (jobj.ContainsKey("Set")) { // We're setting something...
                var setkey = jobj.Value<JObject>("Set");
                if (setkey.ContainsKey("ready")) { // Set ready message...
                    var readykey = setkey.Value<JObject>("ready");
                    var agent = readykey.Value<String>("username");
                    if (readykey.Value<Boolean?>("isReady") == null) return;
                    var readystatus = readykey.Value<Boolean>("isReady");
                    String statusmessage = readystatus ? $"The user {agent} is ready" : $"The user {agent} is not ready";
                    Common.PrintInColor(statusmessage, ConsoleColor.Green);
                    return;
                }
            }

            if (jobj.ContainsKey("State")) { // We're updating some states...
                var statekey = jobj.Value<JObject>("State");
                if (statekey.ContainsKey("ping")) { // We're doing some ping stuff...


                    var ping_key = statekey.Value<JObject>("ping");

                    pingService.SetArrivalTimeStamp(ping_key.Value<Double>("clientLatencyCalculation"));

                    
                    
                    var latencyCalculation = ping_key.Value<Double>("latencyCalculation");
                    var clientLatencyCalc = pingService.GetDepartureTimeStamp();
                    var clientRTT = pingService.GetRTT();

                    // latencyCalculation should be repeated back to the server

                    client.SendMessage(Packets.CraftPingMessage(clientRTT, clientLatencyCalc, latencyCalculation, true, 0.0f));
                }
            }
        }

        
    }
}
