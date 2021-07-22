using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay.EventArgs {
    public class NewFileLoadEventArgs {
        public string FileName;
        public string AbsoluteFilePath;

        public NewFileLoadEventArgs(string fname, string afilepath) {
            this.FileName = fname;
            this.AbsoluteFilePath = afilepath;
        }
    }
}
