using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay.SPEventArgs {
    public class NewFileLoadEventArgs {
        public string FileName;
        public string AbsoluteFilePath;

        public bool MetaDataAvailable = false;
        public float Duration = 0.0f;
        public int Size;

        public NewFileLoadEventArgs(string fname, string afilepath) {
            this.FileName = fname;
            this.AbsoluteFilePath = afilepath;
        }

        public NewFileLoadEventArgs() { }
    }
}
