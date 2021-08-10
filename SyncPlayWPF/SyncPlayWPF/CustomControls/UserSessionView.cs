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
    ///     <MyNamespace:UserSessionView/>
    ///
    /// </summary>
    public class UserSessionView : Control {
        static UserSessionView() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UserSessionView), new FrameworkPropertyMetadata(typeof(UserSessionView)));
        }

        public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register("Username", typeof(string), typeof(UserSessionView), new PropertyMetadata(""));
        public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(UserSessionView), new PropertyMetadata(""));
        public static readonly DependencyProperty FileDurationProperty = DependencyProperty.Register("FileDuration", typeof(string), typeof(UserSessionView), new PropertyMetadata(""));
        public static readonly DependencyProperty FileSizeProperty = DependencyProperty.Register("FileSize", typeof(string), typeof(UserSessionView), new PropertyMetadata(""));
        public static readonly DependencyProperty UserProperty = DependencyProperty.Register("User", typeof(SyncPlay.User), typeof(UserSessionView), new PropertyMetadata(default(SyncPlay.User)));
        public string Username {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public string FileName {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        public string FileDuration {
            get { return (string)GetValue(FileDurationProperty); }
            set { SetValue(FileDurationProperty, value); }
        }

        public string FileSize {
            get { return (string)GetValue(FileSizeProperty); }
            set { SetValue(FileSizeProperty, value); }
        }

        public SyncPlay.User User {
            get { return (SyncPlay.User)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }


    }
}
