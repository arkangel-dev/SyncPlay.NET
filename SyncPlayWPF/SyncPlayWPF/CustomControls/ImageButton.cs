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
    ///     <MyNamespace:ImageButton/>
    ///
    /// </summary>
    public class ImageButton : Button {
        static ImageButton() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        // Image Property
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(BitmapImage), typeof(ImageButton), new PropertyMetadata(default(BitmapImage)));
        
        // Height and Width of the image
        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(float), typeof(ImageButton), new PropertyMetadata(0.0F));
        public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register("ImageHeight", typeof(float), typeof(ImageButton), new PropertyMetadata(0.0F));
        
        // Image colors
        public static readonly DependencyProperty ImageBackgroundBrushProperty = DependencyProperty.Register("ImageBackgroundBrush", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty ImageBackgroundBrushHoverProperty = DependencyProperty.Register("ImageBackgroundHoverBrush", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty ImageBackgroundBrushClickProperty = DependencyProperty.Register("ImageBackgroundClickBrush", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));

        // Background colors
        public static readonly DependencyProperty BackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty BackgroundBrushHoverProperty = DependencyProperty.Register("BackgroundHoverBrush", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty BackgroundBrushClickProperty = DependencyProperty.Register("BackgroundClickBrush", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));

        // Text Colors
        public static readonly DependencyProperty TextForegroundBrushProperty = DependencyProperty.Register("TextForegroundBrush", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));


        public BitmapImage Image {
            get { return (BitmapImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public float ImageHeight {
            get { return (float)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public float ImageWidth {
            get { return (float)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public Brush ImageBackgroundBrush {
            get { return (Brush)GetValue(ImageBackgroundBrushProperty); }
            set { SetValue(ImageBackgroundBrushProperty, value); }
        }

        public Brush ImageBackgroundHoverBrush {
            get { return (Brush)GetValue(ImageBackgroundBrushHoverProperty); }
            set { SetValue(ImageBackgroundBrushHoverProperty, value); }
        }

        public Brush ImageBackgroundClickBrush {
            get { return (Brush)GetValue(ImageBackgroundBrushClickProperty); }
            set { SetValue(ImageBackgroundBrushClickProperty, value); }
        }

        public Brush BackgroundBrush {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }

        public Brush BackgroundHoverBrush {
            get { return (Brush)GetValue(BackgroundBrushHoverProperty); }
            set { SetValue(BackgroundBrushHoverProperty, value); }
        }

        public Brush BackgroundClickBrush {
            get { return (Brush)GetValue(BackgroundBrushClickProperty); }
            set { SetValue(BackgroundBrushClickProperty, value); }
        }

        public Brush TextForegroundBrush {
            get { return (Brush)GetValue(TextForegroundBrushProperty); }
            set { SetValue(TextForegroundBrushProperty, value); }
        }
    }
}
