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
    ///     <MyNamespace:PromptingLabel/>
    ///
    /// </summary>
    public class PromptingLabel : TextBox {
        static PromptingLabel() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PromptingLabel), new FrameworkPropertyMetadata(typeof(PromptingLabel)));
        }

        public static readonly DependencyProperty PromptingTextProperty = DependencyProperty.Register("PromptingText", typeof(string), typeof(PromptingLabel), new PropertyMetadata(""));
        public static readonly DependencyProperty FocusedUnderlineBrushProperty = DependencyProperty.Register("FocusedUnderlineBrush", typeof(Brush), typeof(PromptingLabel), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty HoverUnderlineBrushProperty = DependencyProperty.Register("HoverUnderlineBrush", typeof(Brush), typeof(PromptingLabel), new PropertyMetadata(default(Brush)));

        public string PromptingText {
            get { return (string)GetValue(PromptingTextProperty); }
            set { SetValue(PromptingTextProperty, value); }
        }

        public Brush FocusedUnderlineBrush {
            get { return (Brush)GetValue(FocusedUnderlineBrushProperty); }
            set { SetValue(FocusedUnderlineBrushProperty, value); }
        }

        public Brush HoverUnderlineBrush {
            get { return (Brush)GetValue(HoverUnderlineBrushProperty); }
            set { SetValue(HoverUnderlineBrushProperty, value); }
        }

        public override void OnApplyTemplate() {
          
           
        }

        public void FocusOnControl() {
            var tempchild = GetTemplateChild("UserInputBox") as TextBox;
            tempchild.Focus();
            Keyboard.Focus(tempchild);
        }

       

        
    }
}
