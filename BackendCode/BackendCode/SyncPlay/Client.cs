
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
        private string HelloMessage = "";
        private PingService pingService;

        private float playPosition;
        
        private Dictionary<String, User> UserDictionary;
        private List<MediaFile> Playlist;
        
        private bool isPaused;
        private bool isReady;

        #region Front Facing Accessors

        public bool GetPause() {
            return isPaused;
        }

        public void SetPause(bool state) {
            this.isPaused = state;
            // TODO : Implement Send Pause Code Here
        }

        public float GetPlayPosition() {
            return playPosition;
        }

        public void SetPlayPosition(float p) {
            playPosition = p;
        }


        public bool GetReadyState() {
            return this.isReady;
        }

        public void SetReadyState(bool state, bool manuallyset = true) {
            this.isReady = state;
            client.SendMessage(Packets.CraftSetClientReadiness(state, manuallyset));
        }
        public void AddFileToPlayList(string path) {
            var mfile = MediaFile.OpenFile(path);
            Playlist.Add(mfile);
            client.SendMessage(Packets.CraftSetFileMessage(mfile.FilePath, mfile.Duration, mfile.Size));
        }

        public Client(String serverip, int port, String username, String password, String roomname, String version) {
            client = new NetworkClient(serverip, port);
            pingService = new PingService();
            client.Connect();
            HelloMessage = Packets.CraftIdentificationMessage(username, password, roomname, version);
            client.OnNewMessage += NewIncomingMessage;
            client.SendMessage(Packets.CraftTLS());
            UserDictionary = new Dictionary<string, User>();
            Playlist = new List<MediaFile>();
        }

        #endregion


        #region Front Facing Events
        public delegate void ReadyPacketHandler(Client sender, EventArgs.UserReadyEventArgs e);
        public event ReadyPacketHandler OnNewReadyPacket;

        public delegate void ChatPacketHandler(Client sender, EventArgs.ChatMessageEventArgs e);
        public event ChatPacketHandler OnNewChatMessage;
        #endregion






        #region Back end methods 
        private void NewIncomingMessage(NetworkClient sender, string message) {
     
            if (String.IsNullOrWhiteSpace(message)) return;
            var jobj = JObject.Parse(message);


            // This the TLS negotiation packet
            if (jobj.ContainsKey("TLS")) {
                client.SendMessage(HelloMessage);
            }

            // This is the handshake packet
            if (jobj.ContainsKey("Hello")) {
                client.SendMessage(Packets.CraftSetClientReadiness(false, false));
                client.SendMessage(Packets.CraftSendList());
            }

            // This will get triggered when someone sends a chat message
            #region Chat Packets
            if (jobj.ContainsKey("Chat")) {
                var chatkey = jobj.Value<JObject>("Chat");
                var username = chatkey.Value<String>("username");
                var chatmessage = chatkey.Value<String>("message");
                Common.PrintInColor($"The user {username} said '{chatmessage}'", ConsoleColor.Green);

                if (OnNewChatMessage != null) {
                    User s;
                    UserDictionary.TryGetValue(username, out s);
                    var args = new EventArgs.ChatMessageEventArgs(s, chatmessage);
                    OnNewChatMessage(this, args);
                }
            }
            #endregion

            #region Set Packets
            // The set packets seems be in charge of making sure that the client updates
            // their properties and append new information to the client
            if (jobj.ContainsKey("Set")) {
                var setkey = jobj.Value<JObject>("Set");

                // If it has a ready key that means the server just got word that someone is
                // not ready or that someone is ready
                #region Ready Packet
                if (setkey.ContainsKey("ready")) { 
                    var readykey = setkey.Value<JObject>("ready");
                    var agent = readykey.Value<String>("username");
                    if (readykey.Value<Boolean?>("isReady") == null) return;
                    var readystatus = readykey.Value<Boolean>("isReady");
                    var manuallyinitiated = readykey.Value<Boolean>("manuallyInitiated");
                    User userobj;
                    UserDictionary.TryGetValue(agent, out userobj);
                    String statusmessage = readystatus ? $"The user {agent} is ready" : $"The user {agent} is not ready";
                    Common.PrintInColor(statusmessage, ConsoleColor.Green);
                    if (OnNewReadyPacket != null) {
                        var EventArgs = new EventArgs.UserReadyEventArgs(userobj, manuallyinitiated, readystatus);
                        OnNewReadyPacket(this, EventArgs);
                    }
                    return;
                }
                #endregion

                // Set user events indicate that a user has left or joined the room. or the server.
                #region User State Change Packet
                if (setkey.ContainsKey("user")) {
                    var UserInQuestion = (JProperty)setkey["user"].First();



                    // This will get triggered if the user has set a new file
                    if (UserInQuestion.Contains("file")) {  
                        var Event = ((JProperty)((JObject)UserInQuestion.Value<JProperty>().Value)
                                ["event"].First())
                                .Name;
                        Common.PrintInColor("The user " + UserInQuestion.Name + " has " + Event, ConsoleColor.Green);
                    }

                    if (UserInQuestion.Contains("file")) {
                        // TODO : Use has set file!
                    }
                }
                #endregion
            }
            #endregion

            // State packets is used to make the sure that all the clients are on the same page.
            #region State packets
            if (jobj.ContainsKey("State")) {
                var statekey = jobj.Value<JObject>("State");

                // Ping packets are used to make sure that the client is not dead. If the server doesn't
                // get ping responses for more than 14 pings, it will drop the connection
                #region Ping packets
                if (statekey.ContainsKey("ping")) {
                    var ping_key = statekey.Value<JObject>("ping");
                    pingService.SetArrivalTimeStamp(ping_key.Value<Double>("clientLatencyCalculation"));
                    var latencyCalculation = ping_key.Value<Double>("latencyCalculation");
                    var clientLatencyCalc = pingService.GetDepartureTimeStamp();
                    var clientRTT = pingService.GetRTT();

                    var sendIgnoreState = false;

                    if (statekey.ContainsKey("ignoringOnTheFly")) {
                        sendIgnoreState = statekey.Value<JObject>("ignoringOnTheFly").ContainsKey("server");

                    }
                    




                    client.SendMessage(Packets.CraftPingMessage(clientRTT, clientLatencyCalc, latencyCalculation, serverIgnoreOnFly: sendIgnoreState, clientIgnoreOnFly:false, playerPosition:playPosition, playerPaused:isPaused));
                }
                #endregion

                
            }
            #endregion
        }



        #endregion






    }
}
