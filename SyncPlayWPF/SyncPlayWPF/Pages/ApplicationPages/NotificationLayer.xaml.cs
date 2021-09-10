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

namespace SyncPlayWPF.Pages.ApplicationPages {
    /// <summary>
    /// Interaction logic for NotificationLayer.xaml
    /// </summary>
    public partial class NotificationLayer : UserControl {
        public NotificationLayer() {
            InitializeComponent();

            Loaded += NotificationLayer_Loaded;
        }

        private void NotificationLayer_Loaded(object sender, RoutedEventArgs e) {
            Common.Shared.NotificationLayer = this;
        }

        public void CreateNotification(String title, String message, int dur = 10000) {
            


            Dispatcher.Invoke(() => {
                var notification = new CustomControls.ToastNotification();
                notification.Message = message;
                notification.Title = title;
                notification.Duration = dur;
                NotificationStack.Children.Add(notification);
                notification.StartTimer();
            });
        }
    }
}
