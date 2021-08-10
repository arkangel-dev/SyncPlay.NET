using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay.MediaPlayers.MPVPlayer {
    public class MPVPackets {
        public static string CraftPausePacket() {
            var result = new JObject(
                new JProperty("command",
                    new JArray("set_property", "pause", true)));
            return result.ToString(Newtonsoft.Json.Formatting.None);
        }

        public static string CraftPlayPacket() {
            var result = new JObject(
                new JProperty("command",
                    new JArray("set_property", "pause", false)));
            return result.ToString(Newtonsoft.Json.Formatting.None);
        }

        public static string CraftPauseStatePacket(bool s) {
            var result = new JObject("command",
                new JArray("set_property", "pause", s));
            return result.ToString(Newtonsoft.Json.Formatting.None);
        }

        public static string CraftSeekAbsolutePacket(float pos) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("seek", pos, "absolute")));
            return result.ToString(Newtonsoft.Json.Formatting.None);
        }

        public static string CraftGetPauseState() {
            var result = new JObject(
                new JProperty("command",
                    new JArray("get_property", "pause")));
            return result.ToString(Newtonsoft.Json.Formatting.None);
        }




    }
}
