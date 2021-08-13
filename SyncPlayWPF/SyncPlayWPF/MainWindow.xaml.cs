using System;
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
            Loaded += MainWindow_Loaded;

            InitHeader();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            MiddleTransition.ShowPage(new Pages.ApplicationPages.NotificationLayer());
            Common.Shared.MasterWindow = this;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            Console.WriteLine("Exception thrown!");
            Common.Shared.ThrowException(e.Exception);
            e.Handled = true;
        }

        private void WindowDrag(object sender, MouseButtonEventArgs e) {
            if (Mouse.LeftButton == MouseButtonState.Pressed) {
                App.Current.MainWindow.DragMove();
            }
        }

        private void WindowMinimiseButton_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void WindowRestoreButton_Click(object sender, RoutedEventArgs e) {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void WindowCloseButton_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }


        private void InitHeader() {
            var border = TitleBar;
            var restoreIfMove = false;

            border.MouseLeftButtonDown += (s, e) => {
                if (e.ClickCount == 2) {
                    if ((ResizeMode == ResizeMode.CanResize) ||
                        (ResizeMode == ResizeMode.CanResizeWithGrip)) {
                        SwitchState();
                    }
                } else {
                    if (WindowState == WindowState.Maximized) {
                        restoreIfMove = true;
                    }
                    DragMove();
                }
            };
            border.MouseLeftButtonUp += (s, e) => { restoreIfMove = false; };
            border.MouseMove += (s, e) => {
                if (restoreIfMove) {
                    restoreIfMove = false;
                    var mouseX = e.GetPosition(this).X;
                    var width = RestoreBounds.Width;
                    var x = mouseX - width / 2;

                    if (x < 0) {
                        x = 0;
                    } else if (x + width > System.Windows.SystemParameters.PrimaryScreenWidth) {
                        x = SystemParameters.PrimaryScreenWidth - width;
                    }

                    WindowState = WindowState.Normal;
                    Left = x;
                    Top = 0;
                    DragMove();
                }
            };
        }

        private void SwitchState() {
            switch (WindowState) {
                case WindowState.Normal: {
                        WindowState = WindowState.Maximized;
                        break;
                    }
                case WindowState.Maximized: {
                        WindowState = WindowState.Normal;
                        break;
                    }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (Common.Shared.Wrapper != null)
                if (Common.Shared.Wrapper.Player != null)
                    Common.Shared.Wrapper.Player.ClosePlayer();
        }
    }
}
