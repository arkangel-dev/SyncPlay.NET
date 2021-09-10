﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml.Linq;
using WpfPageTransitions;

namespace SyncPlayWPF.Common {
    public class Shared {
        public static WpfPageTransitions.PageTransition WindowPageTransition;
        public static WpfPageTransitions.PageTransition LandingPageTransition;
        public static WpfPageTransitions.PageTransition MasterOverrideTransition;
        public static UserControl PreviousScreen;

        public static Pages.ApplicationPages.NotificationLayer NotificationLayer;
        
        public static SyncPlay.SyncPlayWrapper Wrapper;
        public static Window MasterWindow;

        public static Common.LogFileDump MasterLogDump;
        public static XDocument CurrentConfig;

        public static bool IgnorePlayerStateChanges = false;

        public static void ThrowException(Exception e) {
            MasterOverrideTransition.IsHitTestVisible = true;
            var exp_view = new Pages.ApplicationPages.ExceptionView();
            exp_view.ShowDisplay(e);
            MasterOverrideTransition.ShowPage(exp_view);
        }


   
    }

 
}
