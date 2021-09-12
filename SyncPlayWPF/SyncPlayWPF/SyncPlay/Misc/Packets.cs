using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SyncPlayWPF.Misc.SyncPlay {
    public class Packets {

        public static string CraftCrashPacket() {
            var result = new JObject(
                new JProperty("Set",
                    new JObject(
                        new JProperty("file",
                            new JObject(
                                new JProperty("name", null),
                                new JProperty("duration", null),
                                new JProperty("size", null)
                            )
                        )
                    )
                )
            );



            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            Console.WriteLine(sresult);
            return sresult;
        }

        /// <summary>
        /// Create a set file packet. This is used to notify the server what the client is playing.
        /// </summary>
        /// <param name="filename">Filenamme of the file. Can be hashed</param>
        /// <param name="duration">Duration of the media file</param>
        /// <param name="size">Size of the media file</param>
        /// <returns>JSON Packet</returns>
        public static string CraftSetFileMessage(String filename, float duration, int size) {
            var result = new JObject(
                new JProperty("Set",
                    new JObject(
                        new JProperty("file",
                            new JObject(
                                new JProperty("name", new FileInfo(filename).Name),
                                new JProperty("duration", duration),
                                new JProperty("size", size)
                            )
                        )
                    )
                )
            );
            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            return sresult;
        }

        /// <summary>
        /// Craft a hello packet. This is used to authenicate into the server and to comminicate the version
        /// of the server
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the server</param>
        /// <param name="roomname">Room name to connect to</param>
        /// <param name="version">Version of the client</param>
        /// <returns>JSON Packet</returns>
        public static string CraftIdentificationMessage(String username, String password, String roomname, String version) {
            var hashedpassword = String.IsNullOrEmpty(password) ? "" : SyncPlayWPF.SyncPlay.Security.ToMD5(password);
            var result = new JObject(
                    new JProperty("Hello",
                        new JObject(
                            new JProperty("username", username),
                            new JProperty("password", hashedpassword),
                            new JProperty("room",
                                new JObject(
                                    new JProperty("name", roomname)
                                )
                            ),
                            new JProperty("version", version),
                            new JProperty("realversion", "1.6.7"),
                            new JProperty("features",
                                new JObject(
                                    new JProperty("sharedPlaylists", true),
                                    new JProperty("chat", true),
                                    new JProperty("featureList", true),
                                    new JProperty("readiness", true),
                                    new JProperty("managedRooms", true)
                                )
                            )
                        )
                    )
                );
            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            return sresult;
        }

        /// <summary>
        /// Craft a TLS packet. This is used to establish a secure connection with the server.
        /// </summary>
        /// <returns>JSON Packet</returns>
        public static string CraftTLS() {
            var result = new JObject(
                    new JProperty("TLS",
                        new JObject(
                            new JProperty("startTLS", "send")
                            )
                        )
                    );
            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            return sresult;
        }

        /// <summary>
        /// This is used to maintain the connection between the server the client. Its also used to communicate data to calculate latency and stuff
        /// </summary>
        /// <param name="clientRtt"></param>
        /// <param name="clientLatencyCalculation"></param>
        /// <param name="latencyCalculation"></param>
        /// <param name="playerPosition"></param>
        /// <param name="serverIgnoreOnFly"></param>
        /// <param name="clientIgnoreOnFly"></param>
        /// <param name="doSeek"></param>
        /// <param name="playerPaused"></param>
        /// <returns></returns>
        public static string CraftPingMessage(double clientRtt, double clientLatencyCalculation, double latencyCalculation, double playerPosition = -1, bool serverIgnoreOnFly = false, bool clientIgnoreOnFly = false, bool doSeek = false, bool? playerPaused = null) {
            var result = new JObject(
                new JProperty("State",
                    new JObject(
                        new JProperty("ping",
                            new JObject(
                                new JProperty("clientRtt", clientRtt),
                                new JProperty("clientLatencyCalculation", clientLatencyCalculation),
                                new JProperty("latencyCalculation", latencyCalculation)
                            )
                        )
                    )
                )
            );
            if (clientIgnoreOnFly || serverIgnoreOnFly) {
                var Container = new JObject();
                if (serverIgnoreOnFly) Container.Add(new JProperty("server", 1));
                if (clientIgnoreOnFly) Container.Add(new JProperty("client", 1));
                ((JObject)result["State"]).Add(new JProperty("ignoringOnTheFly", Container));
            }
            if (playerPosition != -1 && playerPaused != null) {
                var container = new JObject();
                container.Add(new JProperty("doSeek", doSeek));
                container.Add(new JProperty("position", playerPosition));
                container.Add(new JProperty("paused", (bool)playerPaused));
                ((JObject)result["State"]).Add(new JProperty("playstate", container));
            }
            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            return sresult;
        }

        public static string CraftSetClientReadiness(bool isReady, bool manuallyInitiated) {
            var result = new JObject(
                new JProperty("Set",
                    new JObject(
                        new JProperty("ready",
                            new JObject(
                                new JProperty("isReady", isReady),
                                new JProperty("manuallyInitiated", manuallyInitiated)
                            )
                        )
                    )
                )
            );

            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            return sresult;
        }

        public static string CraftOutgoingChatMessage(string message) {
            var result = new JObject(
                    new JProperty("Chat", message)
                );
            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            return sresult;
        }

        public static string CraftSendList() {
            var result = new JObject(
                new JProperty("List", null)
            );
            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            return sresult;
        }
    }  
}
