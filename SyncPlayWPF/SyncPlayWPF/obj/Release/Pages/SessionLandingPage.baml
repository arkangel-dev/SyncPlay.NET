   M S B A M L   `   `   `  ���� K  GSyncPlayWPF, Version=2021.267.5.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SyncPlayWPF.PagesSyncPlayWPF.Pages  G(clr-namespace:SyncPlayWPF.CustomControlsSyncPlayWPF.CustomControls  R NWpfPageTransitions, Version=2021.267.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:WpfPageTransitions;assembly=WpfPageTransitionsWpfPageTransitions *    $SyncPlayWPF.Pages.SessionLandingPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:SyncPlayWPF.Pages     ;custom(clr-namespace:SyncPlayWPF.CustomControls     Mwpft<clr-namespace:WpfPageTransitions;assembly=WpfPageTransitions       � 	Resources   �� Source�� $ ../Themes/Generic.xaml?�%    .��� .+��� ����  �� 
TargetType" ��.���  �� Property � �� �� Value ��    NewSessionBackDrop �� ImageSource# [   j� Stretch$ UniformToFill=�._��  � RowDefinitions �� $��* ��� $��30 �.+��  � ColumnDefinitions �� $
��auto ��� .+��� -   	 ��Name$	 	SidePanel��$��0��$
��auto��  DarkMode_AccentColorG#��[ ._��  �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��$��0,10,0,0q�.+��� .+�,   &SyncPlayWPF.CustomControls.ImageButton  -   
  Name$
 ChatSideButton��,   &SyncPlayWPF.CustomControls.ImageButton   Click$ SidePanelButtonClick��$
��Chat��  ChatIcon   Image# [   SidePanelButtons#��[   -   $
 MediaSideButton��$ SidePanelButtonClick��$��Media��  	MediaIcon# [ #��[   -   $
 SettingsSideButton��$ SidePanelButtonClick��$��Settings��  SettingsIcon# [ #��[   -   $
 AboutSideButton��$ SidePanelButtonClick��$��About��  	AboutIcon# [ #��[ ��  $  SignificantSecondaryActionButton#��[ $��10q�$��Download Update��$y�	Collapsed=�$��2��'  !WpfPageTransitions.PageTransition  -   $��SessionPageWindow��$��1��   TransitionType$
 Fade=��� $��1��  DarkMode_AccentColorF#��[ ._��  �� $
��auto ��� �� $
��auto �.+�  $ ToggleSidePanel��$��0�� 	 CollapseButton# [	  
 ImageSilhouette#��[
 $��5,0,0,0q�   
ImageWidth$ 20��$��35��   ImageHeight$ 20���� -    ��Name$ ReadyToggle��$��3��  GenericCheckbox#��[ $��I am ready to watch�� d� 	IsChecked$ FalseY�$��Right=�$��Center=�