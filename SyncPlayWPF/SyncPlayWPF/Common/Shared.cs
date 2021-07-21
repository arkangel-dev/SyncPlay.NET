using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPageTransitions;

namespace SyncPlayWPF.Common {
    public class Shared {
        public static WpfPageTransitions.PageTransition WindowPageTransition;
        public static WpfPageTransitions.PageTransition LandingPageTransition;
        public static WpfPageTransitions.PageTransition MasterOverrideTransition;
        public static Pages.SessionPages.ChatSession ChatPageSingleton;
        public static SyncPlay.SyncPlayWrapper Wrapper;

        public static void ThrowException(Exception e) {
            MasterOverrideTransition.IsHitTestVisible = true;
            var exp_view = new Pages.ApplicationPages.ExceptionView();
            exp_view.ShowDisplay(e);
            MasterOverrideTransition.ShowPage(exp_view);
        }
    }

 
}
