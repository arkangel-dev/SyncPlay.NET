using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectShowLib;
using DirectShowLib.DES;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace SyncPlayWPF.SyncPlay.Misc {
    public static class Common {

        public static void PrintInColor(String message, ConsoleColor c) {
            var og = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.WriteLine(message);
            Console.ForegroundColor = og;
        }

        public static TimeSpan GetVideoDuration(string filePath) {
            using (var shell = ShellObject.FromParsingName(filePath)) {
                IShellProperty prop = shell.Properties.System.Media.Duration;
                var t = (ulong)prop.ValueAsObject;
                return TimeSpan.FromTicks((long)t);
            }
        }

        public static string ConvertSecondsToTimeStamp(int s) {
            var ts = TimeSpan.FromSeconds(s);
            var hours = ts.Hours.ToString().PadLeft(2, '0');
            var minutes = ts.Minutes.ToString().PadLeft(2, '0');
            var seconds = ts.Seconds.ToString().PadLeft(2,'0');
            return $"{hours}:{minutes}:{seconds}";
        }
    }
}
