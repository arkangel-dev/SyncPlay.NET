﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SyncPlayWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Common.Shared.WindowPageTransition = RootPageTransition;
            Common.Shared.MasterOverrideTransition = MasterOverlayTransition;

            //RootPageTransition.ShowPage(new Pages.SessionLandingPage());
            RootPageTransition.ShowPage(new Pages.NewSessionPage());

            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            Console.WriteLine("Exception thrown!");
            Common.Shared.ThrowException(e.Exception);
            e.Handled = true;
        }

        private void WindowDrag(object sender, MouseButtonEventArgs e) {
            if (System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed) {
                App.Current.MainWindow.DragMove();
            }
        }
    }
}
