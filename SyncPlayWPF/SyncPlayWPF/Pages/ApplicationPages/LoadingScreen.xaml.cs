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
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : UserControl {
        public LoadingScreen(String title = "Please wait", String subtitle = "Connecting to server") {
            InitializeComponent();

            actTitle = title;
            actSubtitle = subtitle;

            Loaded += LoadingScreen_Loaded;
        }

        private void LoadingScreen_Loaded(object sender, RoutedEventArgs e) {
            SetControl();
        }

        public string actTitle;
        public string actSubtitle;

        public void SetControl() {
            this.Title.Text = actTitle;
            this.Subtitle.Text = actSubtitle;
        }
    }
}
