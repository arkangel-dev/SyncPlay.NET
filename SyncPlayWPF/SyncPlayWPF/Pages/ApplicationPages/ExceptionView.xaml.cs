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
    /// Interaction logic for ExceptionView.xaml
    /// </summary>
    public partial class ExceptionView : UserControl {
        public ExceptionView() {
            InitializeComponent();
        }

        public void ShowDisplay(Exception e) {
            ExceptionDetails.Text = e.Message + '\n' + e.StackTrace;
        }
    }
}
