using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BackendCode.SyncPlay {
    public class Packets {
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
                            new JProperty("version", version)
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

        public static string CraftPingMessage(double clientRtt, double clientLatencyCalculation, double latencyCalculation, bool paused, float position) {
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
                        //new JProperty("playstate",
                        //    new JObject(
                        //        new JProperty("paused", paused),
                        //        new JProperty("position", position)
                        //    )
                        //)
                    )
                )
            );
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
