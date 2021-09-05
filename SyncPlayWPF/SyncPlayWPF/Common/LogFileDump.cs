using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.Common {
    public class LogFileDump {
        private string Cache;
        private string OutputFile;
        
        public LogFileDump(string output) {
            this.Cache = "";
            this.OutputFile = output;
        }

        public void Add(string Component, string Message) {
            Cache += $"[{DateTime.Now.ToString("dd/MM/yy HH:mm:ss")}] - {Component} - {Message}\n";
        }

        public void Save() {
            File.AppendAllText(this.OutputFile, Cache);
        }

    }
}
