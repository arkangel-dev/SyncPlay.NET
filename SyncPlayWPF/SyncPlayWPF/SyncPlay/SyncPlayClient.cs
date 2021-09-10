using System;
using Newtonsoft.Json.Linq;
using SyncPlayWPF.SyncPlay.SPEventArgs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SyncPlayWPF.Misc.SyncPlay;

namespace SyncPlayWPF.SyncPlay {
    public class SyncPlayClient {
        private NetworkClient nclient;
        private PingService pingService;
        public Dictionary<String, User> UserDictionary;
        private List<MediaFile> Playlist;

        private string Username = "";
        private string HelloMessage = "";
        private string MOTD = "";
        private string ServerVersion = "";

        private float playPosition = 0.0f;
        
        private bool isPaused = true;
        private bool isReady = false;
        private bool Seeked = false;
        private bool clientIgnoreOnFly = false;

        
        #region Front Facing Accessors
        /// <summary>
        /// This function will get the pause state of the client
        /// </summary>
        /// <returns>Pause state</returns>
        public bool GetPause() {
            return isPaused;
        }

        /// <summary>
        /// This function set the pause state of the client
        /// </summary>
        /// <param name="state">Boolean state</param>
        public void SetPause(bool state) {
            Console.WriteLine("[SPC] Pause State Change");
            OnDebugLog?.Invoke(this, state ? "Client Paused" : "Client Resumed");
            clientIgnoreOnFly = true;
            this.isPaused = state;
        }

        /// <summary>
        /// This function will get the players supposed position
        /// </summary>
        /// <returns>Position in seconds</returns>
        public float GetPlayPosition() {
            return playPosition;
        }

        /// <summary>
        /// This function will set the players position
        /// </summary>
        /// <param name="p">Position in seconds</param>
        public void SetPlayPosition(float p) {
            if (!Seeked) {
                clientIgnoreOnFly = true;
                Seeked = true;
                playPosition = p;
            }
        }

        /// <summary>
        /// This function will set the position of the player. But only 
        /// use this function to increment the client player
        /// </summary>
        /// <param name="p">Position in seconds</param>
        public void TimerSetPosition(float p) {
            playPosition = p;
        }

        /// <summary>
        /// This function will get the ready state of the client
        /// </summary>
        /// <returns>Ready state</returns>
        public bool GetReadyState() {
            return this.isReady;
        }

        /// <summary>
        ///  This function will set the ready state of the client
        /// </summary>
        /// <param name="state">Ready state in boolean</param>
        /// <param name="manuallyset">Set this to false if the client pauses</param>
        public void SetReadyState(bool state, bool manuallyset = true) {
            this.isReady = state;
            nclient.SendMessage(Packets.CraftSetClientReadiness(state, manuallyset));
        }

        /// <summary>
        /// This function will add a file to the playlist and set it as the currently playing file
        /// </summary>
        /// <param name="path">Path to the file</param>
        public void AddFileToPlayList(string path) {
            var mfile = MediaFile.OpenFile(path);
            Playlist.Add(mfile);
            nclient.SendMessage(Packets.CraftSetFileMessage(mfile.FilePath, mfile.Duration, mfile.Size));
        }
        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="message">Message to send</param>
        public void SendChatMessage(string message) {
            nclient.SendMessage(Packets.CraftOutgoingChatMessage(message));
        }


        private string ServerIP;
        private int Port;
        private string LUsername;
        private string Password;
        private string RoomName;
        private string Version;

        /// <summary>
        /// This is the constructor to the client class
        /// </summary>
        /// <param name="serverip">IP or domain of the server</param>
        /// <param name="port">Port number to connect to</param>
        /// <param name="username">User to use</param>
        /// <param name="password">Password to use</param>
        /// <param name="roomname">Room name to use</param>
        /// <param name="version">Version of the client</param>
        public SyncPlayClient(String serverip, int port, String username, String password, String roomname, String version) {
            this.ServerIP = serverip;
            this.Port = port;
            this.LUsername = username;
            this.Password = password;
            this.RoomName = roomname;
            this.Version = version;
        }

        public void ConnectAsync() {
            var connectAsyncThread = new Thread(() => {
                Connect();
            });
            connectAsyncThread.IsBackground = true;
            connectAsyncThread.Start();
        }

        public void Dispose() {
            this.nclient.Disconnect();
        }

        public bool Connect() {
            try {
                nclient = new NetworkClient(ServerIP, Port);
                if (!nclient.Connect()) {
                    Console.WriteLine("Failed to connect to server");
                    this.OnDisconnect(this, new SPEventArgs.ServerDisconnectedEventArgs(false, "Connection Timed out"));
                    return false;
                }
                
                pingService = new PingService();
                HelloMessage = Packets.CraftIdentificationMessage(LUsername, Password, RoomName, Version);
                nclient.OnNewMessage += NewIncomingMessage;

                if (Common.Settings.GetCurrentConfigBoolValue("Security", "EnableTLS")) {
                    nclient.SendMessage(Packets.CraftTLS());
                } else {
                    nclient.SendMessage(HelloMessage);
                    AuthCompleted = true;
                }
                
                UserDictionary = new Dictionary<string, User>();
                Playlist = new List<MediaFile>();
                var incremement_pos = new Thread(() => { IncrementPosition(); });
                incremement_pos.IsBackground = true;
                incremement_pos.Start();
                return true;
            } catch (Exception e) {
                Console.WriteLine($"Connection Failed : {e.Message}");
                OnDisconnect?.Invoke(this, new SPEventArgs.ServerDisconnectedEventArgs(false, $"Connection failed : {e.Message}"));
                return false;
            }
        }
        #endregion


        // These are the events that will be accessible to external packages...
        // They contain the events that get triggered when something happens,
        // like an event from the server
        #region Front Facing Events

        /// <summary>
        /// This event will be triggered when someones ready state has been changed
        /// </summary>
        public event ReadyPacketHandler OnNewReadyPacket;
        public delegate void ReadyPacketHandler(SyncPlayClient sender, SPEventArgs.UserReadyEventArgs e);

        /// <summary>
        /// This event will be triggered when someone sends a new text message
        /// </summary>
        public event ChatPacketHandler OnNewChatMessage;
        public delegate void ChatPacketHandler(SyncPlayClient sender, SPEventArgs.ChatMessageEventArgs e);

        /// <summary>
        /// This event will be triggered when a user leaves or joins a room
        /// </summary>
        public event UserRoomStateHandler OnUserRoomEvent;
        public delegate void UserRoomStateHandler(SyncPlayClient sender, SPEventArgs.UserRoomStateEventArgs e);

        /// <summary>
        /// This event will get triggered when a user sets a file
        /// </summary>
        public event UserSetFileHandler OnFileSet;
        public delegate void UserSetFileHandler(SyncPlayClient sender, SPEventArgs.RemoteSetFileEventArgs e);

        /// <summary>
        /// This event will be triggered when a log gets sent.
        /// </summary>
        public event DebugLogHandler OnDebugLog;
        public delegate void DebugLogHandler(SyncPlayClient sender, String message);

        /// <summary>
        /// This event will be triggered when player changes are requested such as remote seeking,
        /// local syncing and pausing
        /// </summary>
        public event PlayerSeekHandler OnPlayerStateChange;
        public delegate void PlayerSeekHandler(SyncPlayClient sender, SPEventArgs.RemoteStateChangeEventArgs e);

        /// <summary>
        /// This event will be triggered when an even that is note worthy of notifying the user via chat
        /// occurs. Such as someone joining a chat, leaving a chat, seeking or switching files
        /// </summary>
        public event ChatMessageEvent OnChatInfoEvent;
        public delegate void ChatMessageEvent(SyncPlayClient sender, SPEventArgs.ChatInfoMessageArgs e);

        /// <summary>
        /// This event will be triggered when the connection from the server gets severed. This includes when
        /// the server kicks the client
        /// </summary>
        public event DisconnectEvent OnDisconnect;
        public delegate void DisconnectEvent(SyncPlayClient sender, SPEventArgs.ServerDisconnectedEventArgs e);

        /// <summary>
        /// This event will be triggered when the clients manages to make a successful connection with the server.
        /// </summary>
        public event ConnectEvent OnConnect;
        public delegate void ConnectEvent(SyncPlayClient sender, SPEventArgs.ServerConnectedEventArgs e);
        #endregion



        #region Back end methods 


        public void IncrementPosition() {
            while (true) {
                if (!GetPause()) {
                    TimerSetPosition(GetPlayPosition() + 1);
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// This function will accept username and add said user to the dictionary and return the user object
        /// It will also activate the event
        /// </summary>
        /// <param name="username">Username to add</param>
        /// <returns></returns>
        private User AddNewUser(string username) {
            User user;
            if (!this.UserDictionary.TryGetValue(username, out user)) {
                user = new User();
                user.Username = username;
                this.UserDictionary.Add(username, user);
                var eventargs = new SPEventArgs.UserRoomStateEventArgs();
                eventargs.EventType = SPEventArgs.UserRoomStateEventArgs.EventTypes.JOINED;
                eventargs.User = user;
                if (username != RoomName)
                    OnUserRoomEvent?.Invoke(this, eventargs);
            }
            return user;
        }

        /// <summary>
        /// This function will accept a username and remove them from the user dictionary. It will then activate
        /// the event
        /// </summary>
        /// <param name="username">Username to remove</param>
        private void RemoveUser(string username) {
            User u;
            this.UserDictionary.TryGetValue(username, out u);
            this.UserDictionary.Remove(username);
            var eventargs = new SPEventArgs.UserRoomStateEventArgs();
            eventargs.EventType = SPEventArgs.UserRoomStateEventArgs.EventTypes.LEFT;
            eventargs.User = u;
            OnUserRoomEvent?.Invoke(this, eventargs);
        }

        /// <summary>
        /// This function will get the user from the dictionary.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private User GetUserFromDictionary(string username) {
            User u;
            if (UserDictionary.TryGetValue(username, out u)) {
                return u;
            } else {
                return this.AddNewUser(username);      
            }
        }

        private bool AuthCompleted = false;

        private void NewIncomingMessage(NetworkClient sender, string message) {
            try {
                if (String.IsNullOrWhiteSpace(message)) return;
                var jobj = JObject.Parse(message);

                if (jobj.ContainsKey("TLS")) {
                    var tlskey = jobj.Value<JObject>("TLS");
                    if (tlskey.Value<String>("startTLS").Equals("true")) {
                        Console.WriteLine("Activating TLS...");
                        this.nclient.ActivateTLS();
                    }
                }
            

                if (!AuthCompleted) {
                    nclient.SendMessage(HelloMessage);
                    AuthCompleted = true;
                }

                // Check if the server hates us or something...
                if (jobj.ContainsKey("Error")) {
                    var ErrorMessage = jobj.Value<JObject>("Error")
                        .Value<String>("message");
                    Thread.Sleep(3000);
                    OnDisconnect?.Invoke(this, new SPEventArgs.ServerDisconnectedEventArgs(true, ErrorMessage));
                    return;
                }

                // This is a handshake packet
                if (jobj.ContainsKey("Hello")) {
                    OnConnect?.Invoke(this, new SPEventArgs.ServerConnectedEventArgs());
                    nclient.SendMessage(Packets.CraftSetClientReadiness(false, false));
                    nclient.SendMessage(Packets.CraftSendList());
                    this.Username = (String)jobj["Hello"]["username"];
                    this.MOTD = (String)jobj["Hello"]["motd"];
                    this.ServerVersion = (String)jobj["Hello"]["realVersion"];

                    var LocalUser = AddNewUser(this.Username);
                    LocalUser.IsReady = false;
                }

                // Parse through a list of all the users and what they're playing...
                if (jobj.ContainsKey("List")) {
                    foreach (var room in jobj.Children()) {
                        foreach (var user in room.Children()) {

                            var currentUser = GetUserFromDictionary(
                                ((JProperty)user.First()).Name
                            );
                            currentUser.Room = ((JProperty)room).Name;
                            currentUser.Position = user.Value<float>("position");
                            currentUser.IsReady = user.Value<bool>("isReady");

                            if (user.Value<JObject>("file") != null) {
                                currentUser.File = MediaFile.Generate(
                                    user["file"].Value<String>("name"),
                                    user["file"].Value<float>("duration"),
                                    user["file"].Value<int>("size")
                                );
                            }

                        }
                    }
                }

                // This will get triggered when someone sends a chat message
                #region Chat Packets
                if (jobj.ContainsKey("Chat")) {
                    var chatkey = jobj.Value<JObject>("Chat");
                    var username = chatkey.Value<String>("username");
                    var chatmessage = chatkey.Value<String>("message");
                    Misc.Common.PrintInColor($"The user {username} said '{chatmessage}'", ConsoleColor.Green);
                    OnDebugLog?.Invoke(this, $"The user {username} said '{chatmessage}'");
                    if (OnNewChatMessage != null) {
                        User s;
                        if (!UserDictionary.TryGetValue(username, out s)) throw new Exception($"Cannot find user {username}");
                        var args = new SPEventArgs.ChatMessageEventArgs(s, chatmessage);
                        args.LocallySentMessage = username.Equals(this.Username);
                        OnNewChatMessage(this, args);
                    }
                }
                #endregion

                // The set packets seems be in charge of making sure that the client updates
                // their properties and append new information to the client
                #region Set Packets
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
                        Misc.Common.PrintInColor(statusmessage, ConsoleColor.Green);


                        var chatinfomsg = readystatus ? $"{agent} is ready to play" : $"{agent} is not ready to play";
                        OnChatInfoEvent?.Invoke(this, new SPEventArgs.ChatInfoMessageArgs(GetUserFromDictionary(agent), chatinfomsg));
                        OnDebugLog?.Invoke(this, statusmessage);
                        OnNewReadyPacket?.Invoke(this, new SPEventArgs.UserReadyEventArgs(userobj, manuallyinitiated, readystatus));

                        return;
                    }
                    #endregion

                    // Set user events indicate that a user has left or joined the room. or the server.
                    #region User State Change Packet
                    if (setkey.ContainsKey("user")) {
                        var username = ((JProperty)setkey["user"].First()).Name;

                       

                        if (((JObject)setkey["user"][username]).ContainsKey("event")) {
                            var eventKey = (JObject)setkey["user"][username]["event"];
                            var eventName = ((JProperty)((JToken)eventKey).First()).Name;

                            switch (eventName) {
                                case "joined":
                                    OnDebugLog?.Invoke(this, $"The user {username} has joined the room");
                                    OnChatInfoEvent?.Invoke(this, new SPEventArgs.ChatInfoMessageArgs(GetUserFromDictionary(username), $"{username} has joined the party!"));
                                    AddNewUser(username);
                                    break;

                                case "left":
                                    OnDebugLog?.Invoke(this, $"The user {username} has left the room");
                                    OnChatInfoEvent?.Invoke(this, new SPEventArgs.ChatInfoMessageArgs(GetUserFromDictionary(username), $"{username} has left the party"));
                                    RemoveUser(username);
                                    break;

                                default:
                                    throw new NullReferenceException("Cannot find the correct value");
                            }
                        }

                        if (((JObject)setkey["user"][username]).ContainsKey("file")) {
                            var user = GetUserFromDictionary(username);
                            var filename = (String)setkey["user"][username]["file"]["name"];
                            var duration = (float)setkey["user"][username]["file"]["duration"];
                            var size = (int)setkey["user"][username]["file"]["size"];
                            var filesetargs = new SPEventArgs.RemoteSetFileEventArgs();
                            filesetargs.Agent = user;
                            user.File = MediaFile.Generate(filename, duration, size);
                            filesetargs.File = user.File;

                            OnFileSet?.Invoke(this, filesetargs);
                            OnDebugLog?.Invoke(this, $"The user {username} has loaded the file {filename}");
                        }
                    }
                    #endregion
                }
                #endregion

                // State packets is used to make the sure that all the clients are on the same page.
                #region State packets
                if (jobj.ContainsKey("State")) {
                    var statekey = jobj.Value<JObject>("State");


                    #region Play State Packets
                    if (statekey.ContainsKey("playstate") && !clientIgnoreOnFly) {
                        var playstatekey = statekey.Value<JObject>("playstate");
                        var serverPosition = playstatekey.Value<float>("position");
                        var setByUserString = playstatekey.Value<string>("setBy");


                        // Check if the setBy user is null. If its null that means 
                        // the state has not been set yet
                        if (setByUserString != null) {


                            var setByUser = GetUserFromDictionary(setByUserString);
                            if (playstatekey.Value<Boolean>("paused") != isPaused) {

                                isPaused = playstatekey.Value<Boolean>("paused");
                                OnDebugLog?.Invoke(this, isPaused ? "Remote pause requested" : "Remote resume requested");

                                // Create an even args object to notify the player that it needs to change its pause state
                                // because someone paused or unpaused
                                var remotepauseeventargs = new SPEventArgs.RemoteStateChangeEventArgs();
                                remotepauseeventargs.Agent = setByUser;
                                remotepauseeventargs.Paused = isPaused;
                                remotepauseeventargs.Position = (float)(serverPosition + pingService.GetSeekRTT());
                                remotepauseeventargs.Seeked = false;

                                var chtmsg = isPaused ? $"{setByUser.Username} has paused" : $"{setByUser.Username} has resumed playback";

                                this.OnChatInfoEvent?.Invoke(this, new SPEventArgs.ChatInfoMessageArgs(setByUser, chtmsg));
                                this.OnPlayerStateChange?.Invoke(this, remotepauseeventargs);
                            }

                            if (playstatekey.ContainsKey("doSeek")) {
                                try {
                                    if ((bool)playstatekey["doSeek"]) {

                                        playPosition = serverPosition;
                                        OnDebugLog?.Invoke(this, $"Seeking to {Misc.Common.ConvertSecondsToTimeStamp((int)playPosition)}");

                                        // Create an even args object to notify the player that it needs to seek because someone on the
                                        // server side seeked
                                        var remoteseekingeventargs = new SPEventArgs.RemoteStateChangeEventArgs();
                                        remoteseekingeventargs.Agent = setByUser;
                                        remoteseekingeventargs.Paused = isPaused;
                                        remoteseekingeventargs.Position = serverPosition;
                                        remoteseekingeventargs.Seeked = true;

                                        var seekinfomsg = $"{setByUser.Username} has seeked to {serverPosition} seconds";
                                        this.OnChatInfoEvent?.Invoke(this, new SPEventArgs.ChatInfoMessageArgs(setByUser, seekinfomsg));


                                        OnPlayerStateChange?.Invoke(this, remoteseekingeventargs);
                                    }
                                } catch (Exception e) {

                                }

                            } else if (Math.Abs(serverPosition - playPosition) > 5) {

                                playPosition = serverPosition;
                                OnDebugLog?.Invoke(this, $"Seeking to {Misc.Common.ConvertSecondsToTimeStamp((int)playPosition)} sync with server");

                                // Create an event args object to notify the player that it needs to seek to sync with the
                                // other users
                                var syncseekingeventargs = new SPEventArgs.RemoteStateChangeEventArgs();
                                syncseekingeventargs.Agent = setByUser;
                                syncseekingeventargs.Paused = isPaused;
                                syncseekingeventargs.Position = serverPosition;
                                syncseekingeventargs.Seeked = true;


                                OnPlayerStateChange?.Invoke(this, syncseekingeventargs);



                            }

                        }
                    }
                    #endregion

                    // Ping packets are used to make sure that the client is not dead. If the server doesn't
                    // get ping responses for more than 14 pings, it will drop the connection
                    #region Ping packets
                    if (statekey.ContainsKey("ping")) {
                        var ping_key = statekey.Value<JObject>("ping");

                        pingService.SetArrivalTimeStamp(ping_key.Value<Double>("clientLatencyCalculation"));

                        var latencyCalculation = ping_key.Value<Double>("latencyCalculation");

                        var clientLatencyCalc = pingService.GetDepartureTimeStamp();
                        var clientRTT = pingService.GetRTT();
                        var sendServerIgnoreOnFly = false;

                        if (statekey.ContainsKey("ignoringOnTheFly")) {
                            sendServerIgnoreOnFly = statekey.Value<JObject>("ignoringOnTheFly").ContainsKey("server");

                            if (statekey.Value<JObject>("ignoringOnTheFly").ContainsKey("client")) {
                                clientIgnoreOnFly = false;
                            }
                        }

                        nclient.SendMessage(
                            Packets.CraftPingMessage(
                                clientRTT,
                                clientLatencyCalc,
                                latencyCalculation,
                                serverIgnoreOnFly: sendServerIgnoreOnFly,
                                clientIgnoreOnFly: clientIgnoreOnFly,
                                playerPosition: playPosition + pingService.GetSeekRTT(),
                                playerPaused: isPaused,
                                doSeek: Seeked

                            ));


                        if (Seeked) Seeked = false;
                    }
                    #endregion

                }
                #endregion
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
