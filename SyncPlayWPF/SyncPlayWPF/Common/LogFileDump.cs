using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.Common {
    /// <summary>
    /// Just a simple logo file dump class. I wrote this to debug some stuff...
    /// </summary>
    public class LogFileDump {
        private string Cache;
        private string OutputFile;
        
        /// <summary>
        /// Constructor for this class
        /// </summary>
        /// <param name="output">Output file</param>
        public LogFileDump(string output) {
            this.Cache = "";
            this.OutputFile = output;
        }

        /// <summary>
        /// Add a line to the log
        /// </summary>
        /// <param name="Component">Component of origin</param>
        /// <param name="Message">The actual message</param>
        public void Add(string Component, string Message) {
            Cache += $"[{DateTime.Now.ToString("dd/MM/yy HH:mm:ss")}] - {Component} - {Message}\n";
        }

        /// <summary>
        /// Save the dump file to the text file
        /// </summary>
        public void Save() {
            File.AppendAllText(this.OutputFile, Cache);
        }

    }
}
