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
    ///     <MyNamespace:MediaFileControl/>
    ///
    /// </summary>
    public class MediaFileControl : Control {
        static MediaFileControl() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MediaFileControl), new FrameworkPropertyMetadata(typeof(MediaFileControl)));
        }

        public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(ChatMessage), new PropertyMetadata(""));
        public static readonly DependencyProperty FileSizeProperty = DependencyProperty.Register("FileSize", typeof(string), typeof(ChatMessage), new PropertyMetadata(""));
        public static readonly DependencyProperty FileDurationProperty = DependencyProperty.Register("FileDuration", typeof(string), typeof(ChatMessage), new PropertyMetadata(""));
        public static readonly DependencyProperty UserProperty = DependencyProperty.Register("User", typeof(string), typeof(ChatMessage), new PropertyMetadata(""));
        //public static readonly DependencyProperty MediaFileProperty = DependencyProperty.Register("MediaFile", typeof(BackendCode.SyncPlay.MediaFile), typeof(ChatMessage), new PropertyMetadata(""));

        public string FileName {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }
        public string FileSize {
            get { return (string)GetValue(FileSizeProperty); }
            set { SetValue(FileSizeProperty, value); }
        }
        public string FileDuration {
            get { return (string)GetValue(FileDurationProperty); }
            set { SetValue(FileDurationProperty, value); }
        }

        public string User {
            get { return (string)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        //public BackendCode.SyncPlay.MediaFile MediaFile {
        //    get { return (BackendCode.SyncPlay.MediaFile)GetValue(MediaFileProperty); }
        //    set { SetValue(MediaFileProperty, value); }
        //}

        //public void UpdateControl() {
        //    FileName = MediaFile.FilePath;
        //    User = MediaFile.User;
        //    FileDuration = MediaFile.Duration.ToString() + " Seconds";
        //    FileSize = MediaFile.Size + " Bytes";
        //}
    }
}
