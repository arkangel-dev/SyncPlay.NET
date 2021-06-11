﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay {
    public class MediaFile {
        public int Size;
        public float Duration;
        public String FilePath;

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
                var mfile = new MediaFile();

                if (!File.Exists(path)) return null;
                mfile.FilePath = path;
                mfile.Size = (int)new FileInfo(path).Length;


                mfile.Duration = (float)Common.GetVideoDuration(path).TotalSeconds;
               


                return mfile;
            } catch (Exception e) {
                Common.PrintInColor("Warning failed to read file", ConsoleColor.Yellow);
                Common.PrintInColor(e.Message, ConsoleColor.Yellow);
                Common.PrintInColor(e.StackTrace, ConsoleColor.Yellow);
                return null;
            }
        }
    }
}
