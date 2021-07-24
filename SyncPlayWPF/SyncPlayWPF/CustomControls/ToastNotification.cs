using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SyncPlayWPF.CustomControls {
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SyncPlayWPF.CustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SyncPlayWPF.CustomControls;assembly=SyncPlayWPF.CustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ToastNotification/>
    ///
    /// </summary>
    public class ToastNotification : Control {
        static ToastNotification() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToastNotification), new FrameworkPropertyMetadata(typeof(ToastNotification)));
        }

        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register("Duration", typeof(int), typeof(ToastNotification), new PropertyMetadata(0));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ToastNotification), new PropertyMetadata(""));
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(ToastNotification), new PropertyMetadata(""));
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(BitmapImage), typeof(ToastNotification), new PropertyMetadata(default(BitmapImage)));

        public int Duration {
            get { return (int)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Message {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public BitmapImage Icon {
            get { return (BitmapImage)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public void StartTimer() {
            if (!HasProcessStarted) {
                HasProcessStarted = true;
                var timerthread = new Thread(() => { startProcess(); });
                timerthread.IsBackground = true;
                timerthread.Start();
            }
        }

        private bool HasProcessStarted = false;
        private void startProcess() {
            Thread.Sleep(3000);
            Dispatcher.Invoke(() => {
                ((StackPanel)this.Parent).Children.Remove(this);
            });
            
        }

        public override void OnApplyTemplate() {
            var closeButton = GetTemplateChild("CloseButton") as ImageButton;
            closeButton.Click += SelfRemoveClick;
        }

        private void SelfRemoveClick(object sender, RoutedEventArgs e) {
            ((StackPanel)this.Parent).Children.Remove(this);
        }
    }
}
