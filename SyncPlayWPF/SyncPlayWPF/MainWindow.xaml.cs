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

            //RootPageTransition.ShowPage(new Pages.SessionLandingPage());
            RootPageTransition.ShowPage(new Pages.NewSessionPage());
        }

        private void WindowDrag(object sender, MouseButtonEventArgs e) {
            if (System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed) {
                App.Current.MainWindow.DragMove();
            }
        }
    }
}
