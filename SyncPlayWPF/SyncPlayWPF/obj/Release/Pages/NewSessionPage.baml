   M S B A M L   `   `   `  ���� K  GSyncPlayWPF, Version=2021.267.5.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SyncPlayWPF.PagesSyncPlayWPF.Pages  G(clr-namespace:SyncPlayWPF.CustomControlsSyncPlayWPF.CustomControls  &     SyncPlayWPF.Pages.NewSessionPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:SyncPlayWPF.Pages     ;custom(clr-namespace:SyncPlayWPF.CustomControls       � 	Resources   �� Source�� $ ../Themes/Generic.xaml?�%    .��� ����  �� 
TargetType" �.���  �� Property � �� �� Value ��  �� Opacity$ 1Q�   NewSessionBackDrop �� ImageSource# [   j� Stretch$ UniformToFill=� � RowDefinitions �� $��* ��� $
��auto �.+��� $	��350��$	��450��	 �� CornerRadius$	 15��  DarkMode_AccentColorD#��[ 
 J� Effect
 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 1Q�._�� $��20q� �� $	��100 ��� $
��auto ��� $��* ��� $
��auto �.+���  �� BitmapScalingMode$ HighQuality=�  SyncPlayLogoClassic#��[ $��90��
   $ 15Q�$ 0Q�   Opacity$	 0.5Q��� $��1�� �� Orientation$ 
Horizontal=�$��Center=�.+���  J� SnapsToDevicePixels .  � UseLayoutRounding . $��	Open Sans)�$��SemiBold"�$��Bottom=�  DarkMode_TextColorA#��[ $��25(�.��
SyncPlay��  .  . $��1��$��25(�$��Bottom=�$��SemiBold"�$��	Open Sans)�$��	-10,0,0,0q�  DarkMode_ScaleGradient#��[ .��.NET� $��2��$��30, 30, 30, 0q� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�/   )SyncPlayWPF.CustomControls.PromptingLabel  -     Name$ ServerAddressField��$��0��   PromptingText$ Server Address��  DarkMode_ContrastedGradient   FocusedUnderlineBrush# [   -   $ UsernameField��$��1��$ Username��# [ 5   /SyncPlayWPF.CustomControls.PromptingPasswordBox  -     Name$ PasswordField��$��2��   PromptingText$ Password��   FocusedUnderlineBrush# [   -   $ RoomNameField��$��3��$ 	Room Name��# [ � $��3��$��0,0,0,0q�$��Bottom=� �� $
��auto ��� $
��auto �.+��� -   $��0��$��	Join Room��$	��150��  SignificantActionButton#��[ $��0,0,0,10q�+   %SyncPlayWPF.CustomControls.LinkButton  +   %SyncPlayWPF.CustomControls.LinkButton   Click$ ShowMoreSettings_Clicked��$��1��$��Show More Settings��$	��150��  
LinkButton#��[ � $��1��$��	0,-25,0,0q�$��Center=� � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto �