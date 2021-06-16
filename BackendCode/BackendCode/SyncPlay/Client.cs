﻿
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay {
    class Client {
        private NetworkClient nclient;
        private Misc.PingService pingService;
        private Dictionary<String, User> UserDictionary;
        private List<MediaFile> Playlist;
        private MediaPlayerInterface Player;

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
            OnDebugLog(this, state ? "Client Paused" : "Client Resumed");
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
            clientIgnoreOnFly = true;
            Seeked = true;
            playPosition = p;
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
        /// This is the constructor to the client class
        /// </summary>
        /// <param name="serverip">IP or domain of the server</param>
        /// <param name="port">Port number to connect to</param>
        /// <param name="username">User to use</param>
        /// <param name="password">Password to use</param>
        /// <param name="roomname">Room name to use</param>
        /// <param name="version">Version of the client</param>
        public Client(String serverip, int port, String username, String password, String roomname, String version, MediaPlayerInterface player) {
            nclient = new NetworkClient(serverip, port);
            pingService = new Misc.PingService();
            nclient.Connect();
            HelloMessage = Packets.CraftIdentificationMessage(username, password, roomname, version);
            nclient.OnNewMessage += NewIncomingMessage;
            nclient.SendMessage(Packets.CraftTLS());
            UserDictionary = new Dictionary<string, User>();
            Playlist = new List<MediaFile>();
            Player = player;
            new Thread(() => { IncrementPosition(); }).Start();

            player.OnPauseStateChange += SetPause;
            player.OnSeek += SetPlayPosition;
            player.StartPlayerInstance();


            

            Console.WriteLine("Hello");
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
        public delegate void ReadyPacketHandler(Client sender, EventArgs.UserReadyEventArgs e);

        /// <summary>
        /// This event will be triggered when someone sends a new text message
        /// </summary>
        public event ChatPacketHandler OnNewChatMessage;
        public delegate void ChatPacketHandler(Client sender, EventArgs.ChatMessageEventArgs e);

        /// <summary>
        /// This event will be triggered when a user leaves or joins a room
        /// </summary>
        public event UserRoomStateHandler OnUserRoomEvent;
        public delegate void UserRoomStateHandler(Client sender, EventArgs.UserRoomStateEventArgs e);

        /// <summary>
        /// This event will get triggered when a user sets a file
        /// </summary>
        public event UserSetFileHandler OnFileSet;
        public delegate void UserSetFileHandler(Client sender, EventArgs.RemoteSetFileEventArgs e);

        /// <summary>
        /// This event will be triggered when a log gets sent.
        /// </summary>
        public event DebugLogHandler OnDebugLog;
        public delegate void DebugLogHandler(Client sender, String message);

        /// <summary>
        /// This event will be triggered when player changes are requested such as remote seeking,
        /// local syncing and pausing
        /// </summary>
        public event PlayerSeekHandler OnPlayerStateChange;
        public delegate void PlayerSeekHandler(Client sender, EventArgs.RemoteStateChangeEventArgs e);
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
            var user = new User();
            user.Username = username;
            this.UserDictionary.Add(username, user);
            var eventargs = new EventArgs.UserRoomStateEventArgs();
            eventargs.EventType = EventArgs.UserRoomStateEventArgs.EventTypes.JOINED;
            eventargs.User = user;
            OnUserRoomEvent?.Invoke(this, eventargs);
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
            var eventargs = new EventArgs.UserRoomStateEventArgs();
            eventargs.EventType = EventArgs.UserRoomStateEventArgs.EventTypes.LEFT;
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
                u = new User();
                u.Username = username;
                return u;
            }
        }

        private void NewIncomingMessage(NetworkClient sender, string message) {
            if (String.IsNullOrWhiteSpace(message)) return;
            var jobj = JObject.Parse(message);


            // This the TLS negotiation packet
            if (jobj.ContainsKey("TLS")) {
                nclient.SendMessage(HelloMessage);
            }

            // This is a handshake packet
            if (jobj.ContainsKey("Hello")) {
                nclient.SendMessage(Packets.CraftSetClientReadiness(false, false));
                nclient.SendMessage(Packets.CraftSendList());
                this.Username = (String)jobj["Hello"]["username"];
                this.MOTD = (String)jobj["Hello"]["motd"];
                this.ServerVersion = (String)jobj["Hello"]["realVersion"];

                var LocalUser = AddNewUser(this.Username);
                LocalUser.IsReady = false;
            }

            if (jobj.ContainsKey("List")) {
                foreach (var room in jobj.Children()) {
                    foreach (var user in room.Children()) {

                        var currentUser = GetUserFromDictionary(
                            ((JProperty) user.First()).Name
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
                OnDebugLog(this, $"The user {username} said '{chatmessage}'");
                if (OnNewChatMessage != null) {
                    User s;
                    UserDictionary.TryGetValue(username, out s);
                    var args = new EventArgs.ChatMessageEventArgs(s, chatmessage);
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


                    OnDebugLog?.Invoke(this, statusmessage);
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
                    var username = ((JProperty)setkey["user"].First()).Name;



                    
                    if (((JObject)setkey["user"][username]).ContainsKey("event")) {
                        var eventKey = (JObject)setkey["user"][username]["event"];
                        var eventName = ((JProperty)((JToken)eventKey).First()).Name;


                        switch (eventName) {
                            case "joined":
                                OnDebugLog(this, $"The user {username} has joined the room");
                                AddNewUser(username);
                                break;

                            case "left":
                                OnDebugLog(this, $"The user {username} has left the room");
                                RemoveUser(username);
                                break;

                            default:
                                throw new NullReferenceException("Cannot find the correct value");
                        }
                    }

                    if (((JObject)setkey["user"][username]).ContainsKey("file")) { 
                        var user = GetUserFromDictionary(username);
                        var filename = (String)setkey[username]["file"]["name"];
                        var duration = (float)setkey[username]["file"]["duration"];
                        var size = (int)setkey[username]["file"]["size"];
                        var filesetargs = new EventArgs.RemoteSetFileEventArgs();
                        filesetargs.Agent = user;
                        user.File = MediaFile.Generate(filename, duration, size);
                        filesetargs.File = user.File;

                        OnFileSet(this, filesetargs);
                        OnDebugLog(this, $"The user {username} has loaded the file {filename}");
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
                            OnDebugLog?.Invoke(this, isPaused ? "Remote pause requested" : "Remove resume requested");

                            // Create an even args object to notify the player that it needs to change its pause state
                            // because someone paused or unpaused
                            var remotepauseeventargs = new EventArgs.RemoteStateChangeEventArgs();
                            remotepauseeventargs.Agent = setByUser;
                            remotepauseeventargs.Paused = isPaused;
                            remotepauseeventargs.Position = serverPosition;
                            remotepauseeventargs.Seeked = false;

                            Player.SetPauseState(isPaused);
                            OnPlayerStateChange?.Invoke(this, remotepauseeventargs);
                        }

                        if (playstatekey.ContainsKey("doSeek")) {
                            if (playstatekey["doSeek"] != null) {
                                if ((bool)playstatekey["doSeek"]) {

                                    playPosition = serverPosition;
                                    OnDebugLog(this, $"Seeking to {Misc.Common.ConvertSecondsToTimeStamp((int)playPosition)}");

                                    // Create an even args object to notify the player that it needs to seek because someone on the
                                    // server side seeked
                                    var remoteseekingeventargs = new EventArgs.RemoteStateChangeEventArgs();
                                    remoteseekingeventargs.Agent = setByUser;
                                    remoteseekingeventargs.Paused = isPaused;
                                    remoteseekingeventargs.Position = serverPosition;
                                    remoteseekingeventargs.Seeked = true;

                                    Player.SetPosition(serverPosition);
                                    OnPlayerStateChange?.Invoke(this, remoteseekingeventargs);
                                }
                            }
                        } else if (Math.Abs(serverPosition - playPosition) > 5) {

                            playPosition = serverPosition;
                            OnDebugLog?.Invoke(this, $"Seeking to {Misc.Common.ConvertSecondsToTimeStamp((int)playPosition)} sync with server");

                            // Create an event args object to notify the player that it needs to seek to sync with the
                            // other users
                            var syncseekingeventargs = new EventArgs.RemoteStateChangeEventArgs();
                            syncseekingeventargs.Agent = setByUser;
                            syncseekingeventargs.Paused = isPaused;
                            syncseekingeventargs.Position = serverPosition;
                            syncseekingeventargs.Seeked = true;

                            Player.SetPosition(serverPosition);
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
                    }

                    nclient.SendMessage(
                        Packets.CraftPingMessage(
                            clientRTT, 
                            clientLatencyCalc, 
                            latencyCalculation, 
                            serverIgnoreOnFly: sendServerIgnoreOnFly,
                            clientIgnoreOnFly: clientIgnoreOnFly, 
                            playerPosition: playPosition, 
                            playerPaused:isPaused,
                            doSeek: Seeked

                        ));

                    if (clientIgnoreOnFly) clientIgnoreOnFly = false;
                    if (Seeked) Seeked = false;
                }
                #endregion
            }
            #endregion
        }
        #endregion
    }
}
