using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BackendCode.SyncPlay {
    public class Packets {
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
        public static string CraftIdentificationMessage(String username, String password, String roomname, String version) {
            var hashedpassword = String.IsNullOrEmpty(password) ? "" : Security.ToMD5(password);
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
        public static string CraftPingMessage(
            double clientRtt,
            double clientLatencyCalculation,
            double latencyCalculation,
            double playerPosition = -1,
            bool serverIgnoreOnFly = false,
            bool clientIgnoreOnFly = false,
            bool doSeek = false,
            bool? playerPaused = null
            

        ) {


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
        public static string CraftSendList() {
            var result = new JObject(
                new JProperty("List", null)
            );
            var sresult = result.ToString(Newtonsoft.Json.Formatting.None) + "\r\n";
            return sresult;
        }




    }  
}
