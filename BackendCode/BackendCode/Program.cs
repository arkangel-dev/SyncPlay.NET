using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCode {
    class Program {
        static void Main(string[] args) {
            //var spclient = new SyncPlay.Client("syncplay.pl", 8996, "", "", "ck", "1.2.7");
            var spclient = new SyncPlay.Client("127.0.0.1", 5005, "Sammy", "", "ck", "1.2.7");
            while (true) {
                Console.ReadLine();
            }
        }

    }
}
