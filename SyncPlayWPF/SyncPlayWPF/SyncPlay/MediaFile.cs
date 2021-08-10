using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay {
    public class MediaFile {
        public int Size;
        public float Duration;
        public String FilePath;
        public String User = "USER_NOT_IMPLEMENTED";

        private MediaFile() {

        }

        public static MediaFile Generate(String FilePath, float Duration, int Size) {
            var mFile = new MediaFile();
            mFile.Duration = Duration;
            mFile.Size = Size;
            mFile.FilePath = FilePath;
            return mFile;
        }

        public static MediaFile OpenFile(String path) {
            try {
                if (!File.Exists(path)) return null;
                var mfile = new MediaFile();
                mfile.FilePath = path;
                mfile.Size = (int)new FileInfo(path).Length;
                mfile.Duration = (float)SyncPlay.Misc.Common.GetVideoDuration(path).TotalSeconds;
                return mfile;

            } catch (Exception e) {
                Misc.Common.PrintInColor("Warning failed to read file", ConsoleColor.Yellow);
                Misc.Common.PrintInColor(e.Message, ConsoleColor.Yellow);
                Misc.Common.PrintInColor(e.StackTrace, ConsoleColor.Yellow);
                return null;
            }
        }
    }
}
