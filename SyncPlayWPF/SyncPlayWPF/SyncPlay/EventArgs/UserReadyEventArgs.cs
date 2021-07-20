using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCode.SyncPlay.EventArgs {
    public class UserReadyEventArgs {
        public User User;
        public bool ManuallyInitiated;
        public bool IsReady;

        public UserReadyEventArgs(User _user, bool _manuallInitiated, bool _isReady) {
            User = _user;
            ManuallyInitiated = _manuallInitiated;
            IsReady = _isReady;
        }
    }
}
