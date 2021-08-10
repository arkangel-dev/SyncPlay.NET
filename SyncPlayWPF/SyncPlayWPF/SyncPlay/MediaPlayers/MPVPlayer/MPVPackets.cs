using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay.MediaPlayers.MPVPlayer {
    public class MPVPackets {
        public static string CraftPausePacket(int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("set_property", "pause", true)),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftPlayPacket(int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("set_property", "pause", false)),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftPauseStatePacket(bool s, int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("set_property", "pause", s)),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftSeekAbsolutePacket(float pos, int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("seek", pos, "absolute")),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftGetPauseStatePacket(int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("get_property", "pause")),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftGetCurrentPlayPositionPacket(int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("get_property", "time-pos")),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftGetFileNamePacket(int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("get_property", "filename")),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftGetFilePathPacket(int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("get_property", "path")),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftGetFileSizePacket(int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("get_property", "file-size")),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftGetFileDurationPacket(int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("get_property", "duration")),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftShowMessagePacket(string message, int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("show-text", message)),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

        public static string CraftObservePropertyPacket(string property, int id, int request_id) {
            var result = new JObject(
                new JProperty("command",
                    new JArray("observe_property", id, property)),
                new JProperty("request_id", request_id));
            return result.ToString(Newtonsoft.Json.Formatting.None) + "\n";
        }

    }
}
