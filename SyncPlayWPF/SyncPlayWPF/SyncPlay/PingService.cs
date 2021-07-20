using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlay {
    class PingService {
        double RTT;
        double LastTimeStamp;

        const double ForwardSet = 0.85;

        public PingService() {
            RTT = 0;
        }

        public void SetArrivalTimeStamp(double time) {
            RTT = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds() - LastTimeStamp;
        }

        public double GetDepartureTimeStamp() {
            LastTimeStamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds() + ForwardSet;
            return LastTimeStamp;
        }

        public double GetRTT() {
            return RTT;
        }

    }
}
