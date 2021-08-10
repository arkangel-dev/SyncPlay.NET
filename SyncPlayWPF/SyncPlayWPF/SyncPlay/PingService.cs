using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay {
    class PingService {
        double RTT;
        double LastTimeStamp;

        const double ForwardSet = 1.0;

        public PingService() {
            RTT = 0;
        }

        public void SetArrivalTimeStamp(double time) {
            RTT = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds() - time;
        }

        public double GetDepartureTimeStamp() {
            LastTimeStamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            return LastTimeStamp;
        }

        public double GetRTT() {
            return RTT;
        }

        public double GetSeekRTT() {
            return RTT;
        }

    }
}
