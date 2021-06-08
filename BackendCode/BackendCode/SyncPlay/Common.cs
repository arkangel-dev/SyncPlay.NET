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

namespace BackendCode.SyncPlay {
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

        //public static Misc.MediaFileInfo GetMediaFileStats(String path) {
        //    var medfileinfo = new Misc.MediaFileInfo();

        //    var mediaDet = (IMediaDet)new MediaDet();
        //    DsError.ThrowExceptionForHR(mediaDet.put_Filename(path));

        //    // find the video stream in the file
        //    int index;
        //    var type = Guid.Empty;
        //    for (index = 0; index < 1000 && type != MediaType.Video; index++) {
        //        mediaDet.put_CurrentStream(index);
        //        mediaDet.get_StreamType(out type);
        //    }

        //    // retrieve some measurements from the video
        //    double frameRate;
        //    mediaDet.get_FrameRate(out frameRate);
        //    medfileinfo.Framerate = (int)frameRate;

        //    var mediaType = new AMMediaType();
        //    mediaDet.get_StreamMediaType(mediaType);
        //    var videoInfo = (VideoInfoHeader)Marshal.PtrToStructure(mediaType.formatPtr, typeof(VideoInfoHeader));
        //    DsUtils.FreeAMMediaType(mediaType);
        //    medfileinfo.Width = videoInfo.BmiHeader.Width;
        //    medfileinfo.Height = videoInfo.BmiHeader.Height;

            

        //    double mediaLength;
        //    mediaDet.get_StreamLength(out mediaLength);
        //    var frameCount = (int)(frameRate * mediaLength);
        //    var duration = frameCount / frameRate;
        //    medfileinfo.Duration = (float)duration;

        //    return medfileinfo;
        //}
    }
}
