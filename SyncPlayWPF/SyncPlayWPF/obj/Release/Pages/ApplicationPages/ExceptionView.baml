   M S B A M L   `   `   `  ���� K  GSyncPlayWPF, Version=2021.267.5.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:SyncPlayWPF.Pages.ApplicationPages"SyncPlayWPF.Pages.ApplicationPages  6    0SyncPlayWPF.Pages.ApplicationPages.ExceptionView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Blocal0clr-namespace:SyncPlayWPF.Pages.ApplicationPages       � 	Resources   �� Source�� $ ../../Themes/Generic.xaml?�%    .����    DarkMode_AccentColorJ#��[  ._�� -    �Name$ ContainerGrid��$��25, 10, 25, 10q� � RowDefinitions �� $
��auto ��� $
��auto ��� $��* ��� $
��auto �.+��� $��0��$��ಠ_ಠ��$��50(�$��10,0,0,0q�  DarkMode_TextColorA#��[  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 0Q�   Opacity$ 1Q��� $��1��$����Whoops. It would seem that you have come across an excpetion. So you have two options. You can ignore the exception and continue with normal usage, or you can submit the following stack trace and help us to make SyncPlay.NET better��$��WrapWithOverflow=�$��15(�$��0,10,0,0q�  DarkMode_TextColorF#��[ ��   DarkMode_AccentColorE#��[  �� CornerRadius$ 10��$��0,15,0,0q�	 �� Padding$	 10q�$��2������ 
 �� ElementName$
 ContainerGrid�� �� Path$ ActualWidth�  PercentageConverter �� 	Converter# [  �� ConverterParameter$	 0.9��._���   FavsScrollViewer#��[ .���� -    ��Name$ ExceptionDetails��
������ $��0,0,10,0q�
���   �$��0q�$����Test Exception
         at SyncPlayWPF.Pages.SessionLandingPage.ToggleSidePanel(Object sender, RoutedEventArgs e) in D:\GitHub\SyncPlayWPF\SyncPlayWPF\SyncPlayWPF\Pages\SessionLandingPage.xaml.cs:line 37
         at System.Windows.RoutedEventHandlerInfo.InvokeHandler(Object target, RoutedEventArgs routedEventArgs)
         at System.Windows.EventRoute.InvokeHandlersImpl(Object source, RoutedEventArgs args, Boolean reRaised)
         at System.Windows.UIElement.RaiseEventImpl(DependencyObject sender, RoutedEventArgs args)
         at System.Windows.UIElement.RaiseEvent(RoutedEventArgs e)
         at System.Windows.Controls.Primitives.ButtonBase.OnClick()
         at System.Windows.Controls.Button.OnClick()
         at System.Windows.Controls.Primitives.ButtonBase.OnMouseLeftButtonUp(MouseButtonEventArgs e)
         at System.Windows.UIElement.OnMouseLeftButtonUpThunk(Object sender, MouseButtonEventArgs e)
         at System.Windows.Input.MouseButtonEventArgs.InvokeEventHandler(Delegate genericHandler, Object genericTarget)
         at System.Windows.RoutedEventArgs.InvokeHandler(Delegate handler, Object target)
         at System.Windows.RoutedEventHandlerInfo.InvokeHandler(Object target, RoutedEventArgs routedEventArgs)
         at System.Windows.EventRoute.InvokeHandlersImpl(Object source, RoutedEventArgs args, Boolean reRaised)
         at System.Windows.UIElement.ReRaiseEventAs(DependencyObject sender, RoutedEventArgs args, RoutedEvent newEvent)
         at System.Windows.UIElement.OnMouseUpThunk(Object sender, MouseButtonEventArgs e)
         at System.Windows.Input.MouseButtonEventArgs.InvokeEventHandler(Delegate genericHandler, Object genericTarget)
         at System.Windows.RoutedEventArgs.InvokeHandler(Delegate handler, Object target)
         at System.Windows.RoutedEventHandlerInfo.InvokeHandler(Object target, RoutedEventArgs routedEventArgs)
         at System.Windows.EventRoute.InvokeHandlersImpl(Object source, RoutedEventArgs args, Boolean reRaised)
         at System.Windows.UIElement.RaiseEventImpl(DependencyObject sender, RoutedEventArgs args)
         at System.Windows.UIElement.RaiseTrustedEvent(RoutedEventArgs args)
         at System.Windows.UIElement.RaiseEvent(RoutedEventArgs args, Boolean trusted)
         at System.Windows.Input.InputManager.ProcessStagingArea()
         at System.Windows.Input.InputManager.ProcessInput(InputEventArgs input)
         at System.Windows.Input.InputProviderSite.ReportInput(InputReport inputReport)
         at System.Windows.Interop.HwndMouseInputProvider.ReportInput(IntPtr hwnd, InputMode mode, Int32 timestamp, RawMouseActions actions, Int32 x, Int32 y, Int32 wheel)
         at System.Windows.Interop.HwndMouseInputProvider.FilterMessage(IntPtr hwnd, WindowMessage msg, IntPtr wParam, IntPtr lParam, Boolean handled)
         at System.Windows.Interop.HwndSource.InputFilterMessage(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, Boolean handled)
         at MS.Win32.HwndWrapper.WndProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, Boolean handled)
         at MS.Win32.HwndSubclass.DispatcherCallbackOperation(Object o)
         at System.Windows.Threading.ExceptionWrapper.InternalRealCall(Delegate callback, Object args, Int32 numArgs)
         at System.Windows.Threading.ExceptionWrapper.TryCatchWhen(Object source, Delegate callback, Object args, Int32 numArgs, Delegate catchHandler)����  �� Orientation$ 
Horizontal=�$��3��$��Center=�.+��� $��2,6,2,0q�  GenericPrimaryActionButton#��[ $	��125��$��Submit Exception���� $��2,6,2,0q�#��[ $	��125��$��Submit new Issue���� $��2,6,2,0q�#��[ $	��125��$��Close��