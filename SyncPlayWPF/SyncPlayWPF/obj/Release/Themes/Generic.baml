   M S B A M L   `   `   `  ���� K  GSyncPlayWPF, Version=2021.267.5.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SyncPlayWPF.CustomControlsSyncPlayWPF.CustomControls  ?$clr-namespace:SyncPlayWPF.ConvertersSyncPlayWPF.Converters  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   
IBMRegular  IBMSemiBold2   ,SyncPlayWPF.Converters.TextBoxValueToBoolean  TextBoxValueToBoolean0  *SyncPlayWPF.Converters.PercentageConverter  PercentageConverter  MinimizeButton  �� 	UriSource  CloseWindowButton  RestoreWindowButton  SyncPlayLogoNew  SyncPlayLogoClassic 	 NewSessionBackDrop 
 GithubOctocat  TwitterBird  WebsiteLogo  ChatIcon  	MediaIcon  SettingsIcon  	AboutIcon  EmojiButton  
SendButton  	GifButton  CollapseButton  ToggleOn  	ToggleOff  
LoadingGif  NotificationDismiss  DropDownIcon  DefaultImage  	HourGlass  Warning  GiphyAttrib  DarkMode_AccentColorA �� Color  DarkMode_AccentColorB   DarkMode_AccentColorC ! DarkMode_AccentColorD " DarkMode_AccentColorE # DarkMode_AccentColorF $ DarkMode_AccentColorG % DarkMode_AccentColorGHover & DarkMode_AccentColorGClick ' DarkMode_AccentColorH ( DarkMode_AccentColorI ) DarkMode_AccentColorJ * DarkMode_TextColorA + DarkMode_TextColorB , DarkMode_TextColorC - DarkMode_TextColorD . DarkMode_TextColorDHover / DarkMode_TextColorE 0 DarkMode_TextColorFHover 1 DarkMode_TextColorF 2 DarkMode_TextColorG  3 DarkMode_ImageButtonImgHover  4 DarkMode_ImageButtonImgClick 5 DarkMode_ImageButtonHover 6 DarkMode_ImageButtonClick 7 WarningBrush 8 
ErrorBrush 9 DarkTransparent �� R �� G �� B �� A : DarkMode_ContrastedGradient � Color � Offset �� 	Transform	 �� Angle $;  DarkMode_ContrastedHoverGradient $<  DarkMode_ContrastedClickGradient = DarkMode_ScaleGradient  > DarkMode_ScaleGradientAccent %? !DarkMode_ScaleGradientTransparent @ DarkMode_ScaleHoverGradient "A DarkMode_ScaleDisabledGradient B DarkMode_TitleBarText
 �� 
TargetType �� Property �� Value,   &SyncPlayWPF.CustomControls.ImageButton C TitleBarButtons �� BasedOn �� RelativeSource �� Path J� OpacityMask j� Stretch �� ImageSource �� Triggers �� Binding �� Mode �� Value �� ElementName D ImageSilhouette �� 
TargetType �� BitmapScalingMode E SidePanelButtons ��Name �Name � ColumnDefinitions ��Name ��Name J� Effect3  -System.Windows.Media.Effects.DropShadowEffect    
BlurRadius!   ShadowDepth"   Opacity# � Triggers$ :� RoutedEvent% �� TargetProperty& �� From' g� Duration	( �� To F SignificantActionButton) �� CornerRadius* J� Opacity	+ W� To, W� From- J� IsHitTestVisible $G  SignificantSecondaryActionButton. P� Property/ P� Value H GenericPrimaryActionButton  I GenericSecondaryActionButton J ScrollToBottomButton+   %SyncPlayWPF.CustomControls.LinkButton K 
LinkButton/   )SyncPlayWPF.CustomControls.PromptingLabel0 � RowDefinitions1 �� 
CaretBrush2 �� 	Converter3 J� SnapsToDevicePixels4 � UseLayoutRounding L ChatPromptLabel5 � ShowGridLines6 �� ConverterParameter7 �� TextWrapping8 �� Mode9 �� UpdateSourceTrigger5   /SyncPlayWPF.CustomControls.PromptingPasswordBox 'M #GenericCheckboxWithCheckLowFidelity: F�Name; �� Padding< �� Triggers= �� 
TargetName> ]� 
Conditions? �� Property@ �� Value N GenericCheckboxLowFidelity O GenericCheckbox P DropDown Q ChatInfo,   &SyncPlayWPF.CustomControls.ChatMessage R IncomingMessageA �� TextAlignment	B t� ToC t� From S OutgoingMessage T StandardBackgroundBrush U HoverBorderBrush V SelectedBackgroundBrush W SelectedForegroundBrush X DisabledForegroundBrush Y 
GlyphBrush Z NormalBrush [ NormalBorderBrush \ HorizontalNormalBrush ] HorizontalNormalBorderBrush ^ ListBoxBackgroundBrush _ StandardBrush ` PressedBrush a ScrollBarLineButton b ScrollBarPageButton c ScrollBarThumb d VerticalScrollBarD ]� DecreaseRepeatButtonE ]� ThumbF ]� IncreaseRepeatButton e HorizontalScrollBar f FavsScrollViewerG �� VerticalOffsetH � ValueI �� ScrollableHeightJ � MaximumK �� ViewportHeightL �� ViewportSize*M �� #ComputedVerticalScrollBarVisibility g FadedScrollViewerN �� 
StartPointO �� EndPoint1   +SyncPlayWPF.CustomControls.MediaFileControl h ExpandCollapseToggleStyle i primaryBackgroundBrushP �� EdgeMode j ChatInfoSpacer k ThinChatInfoSpacer0	   *SyncPlayWPF.CustomControls.UserSessionViewQ �� Orientation2
   ,SyncPlayWPF.CustomControls.ToastNotificationR  NameS   
ImageWidthT   Image,   &SyncPlayWPF.CustomControls.StatusImageU K� IsItemsHostV K� ZIndex-  'System.Windows.Input.KeyboardNavigationW   TabIndex�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     3custom(clr-namespace:SyncPlayWPF.CustomControls  7dataconverters$clr-namespace:SyncPlayWPF.Converters  %rn  &	        &	 !     &	 K     &	 P     &	 U     &	 y     &	 �     &	 �     &	 �     &		 +    &	
 W    &	     &	 �    &	 �    &	 �    &	     &	 &    &	 E    &	 d    &	 �    &	 �    &	 �    &	 �    &	     &	 )    &	 T    &	 v    &	 �    &	 �    &	 �    &	     &	     &	  0    &	! C    &	" X    &	# m    &	$ �    &	% �    &	& �    &	' �    &	( �    &	) �    &	*      &	+     &	, (    &	- =    &	. P    &	/ c    &	0 v    &	1 �    &	2 �    &	3 �    &	4 �    &	5 �    &	6 �    &	7 �    &	8     &	9 !    &	: J    &	; �    &	< $    &	= �    &	> �    &	? k    &	@ �    &	A K	    &	B �	    7 * &	C 
    7 7  7 5 7 6 7 3 7 4 '  U    7  &	D =    7 , 7 " 7 * &	E �    7 / 7 / 7 : 7 ; 7 % 7 & 7 9 7 9 &	F T    7 : 7 < 7 ; &	G �    7 : 7 : 7 ; 7 < &	H s"    7 - 7 / 7 * &	I �%    7 / 7 / 7 / 7 * &	J �)    7 2 7 , 7 / &	K (+    7 - 7 . '  c,    7  7 " 7 1 7 + 7 , 7  7   &	L O2    7  7 " 7  7 1 7 1 7  7 , 7  7  '  �5    7  7 " 7 + 7 , 7   &	M �9    7 " 7 = 7 " 7 > 7 @ 7 A 7 " &	N >    7 " 7  7 " 7 = 7  7 A 7 @ &	O 5A    7   7  7 " 7 = 7  7 A 7 @ &	P �D    7  7  7 ! 7  &	Q �E    7 / &	R �E    7 ( 7  7 = 7 1 7 - &	S J    7 ' 7  7 = 7 1 7 - &	T KN    &	U \N    &	V lN    &	W |N    &	X �N    &	Y �N    &	Z �N    &	[ �N    &	\ �N    &	] �N    &	^ �N    &	_ O    &	` O    &	a )O    7 Z 7 [ 7 Y 7 ` 7 X &	b �P    &	c �Q    &	d tR    7 a 7 b 7 c 7 \ 7 ] 7 b 7 a &	e (T    7 a 7 b 7 c 7 Z 7 [ 7 b 7 a '�� �U    7 e 7 d &	f #W    &	g �W    '  sY    7  7 : 7 * 7 , 7 , &	h g\    &	j e^    &	k �^    '	  �^    7 ' 7 * 7 * 7 , 7 , '
  �a    7 ! 7 / 7 , 7 D 7  '  8d    7  7  '�� Se    7  '�� gf    7 1 7   7  *�../Fonts/#IBM Plex Sans)�*�$ ../Fonts/#IBM Plex Sans SemiBold)�     �� $  /ImageLib/minus-line.png?��� $  /ImageLib/close-line.png?��� $'  !/ImageLib/restore-window-line.png?��� $,  &/ImageLib/SyncplayOriginal_NewLogo.png?��� $)  #/ImageLib/SyncplayOriginal_Logo.png?��� $&   /ImageLib/NewSessionBackDrop.png?��� $"  /ImageLib/github-octocat.png?��� $   /ImageLib/twitter_logo.png?��� $  /ImageLib/url_icon.png?��� $  /ImageLib/chat.png?��� $  /ImageLib/media.png?��� $  /ImageLib/settings.png?��� $  /ImageLib/about.png?��� $  /ImageLib/emoji.png?��� $  /ImageLib/send.png?��� $  /ImageLib/gif.png?��� $  /ImageLib/collapse.png?��� $  /ImageLib/toggle_on.png?��� $  /ImageLib/toggle_off.png?��� $  /ImageLib/Loading.gif?��� $%  /ImageLib/notificationClose.png?��� $  /ImageLib/dropdown.png?��� $   /ImageLib/DefaultImage.png?��� $  /ImageLib/HourGlass.png?��� $  /ImageLib/Warning.png?��� $"  /ImageLib/PoweredByGiphy.png?��� $ #2B2B2B���� $ 	#A6878787���� $ #3B3B3B���� $ 	#9E2B2B2B���� $ 	#FF676767���� $ 	#B9282828���� $ 	#931D1D1D���� $ 	#932E2E2E���� $ 	#93434343���� $ 	#B93B3B3B���� $ 	#E7282828���� $ 	#F43E3E3E���� $ #C8C8C8���� $ 	#E1C6C6C6���� $ 	#68AAAAAA���� $ #515151���� $ #747474���� $ #747474���� $ #747474���� $ #AAAAAA���� $ #181818���� $ #CBCBCB���� $ #A3D5EC���� $ #595959���� $ #769AAB���� $ #C1AB42���� $ #9B1F27���� $ 51��$ 51��$ 51��$ 00���� .��� $ #ffc206��$ 0Q�� $ #ff5f41��$	 0.5Q�� $ #ff1e67��$ 1Q� �� $	 45Q��� .��� $ #FFCD34��$ 0Q�� $ #FF846D��$	 0.5Q�� $ #FF4F88��$ 1Q� �� $	 45Q��� .��� $ #FFDB6D��$ 0Q�� $ #FFBFB3��$	 0.5Q�� $ #FFA3C1��$ 1Q� �� $	 45Q��� .��� $ #CB9B00��$ 0Q�� $ #CE533B��$	 0.5Q�� $ #DE1C5B��$ 1Q� �� $	 45Q��� .��� $ #7D5F00��$ 0Q�� $ #8D3C2C��$	 0.5Q�� $ #9D1743��$ 1Q� �� $	 45Q��� .��� $ 	#ABFFC206��$ 0Q�� $ 	#ABff5f41��$	 0.5Q�� $ 	#ABff1e67��$ 1Q� �� $	 45Q��� .��� $ #DEAA00��$ 0Q�� $ #DE5A40��$	 0.5Q�� $ #EC2163��$ 1Q� �� $	 45Q��� .��� $ #4C3A00��$ 0Q�� $ #6D2D20��$	 0.5Q�� $ #670F2C��$ 1Q� �� $	 45Q��� "
 ��.���  � ��$ Normal"���  � ��$ Center=���  � ��8   �� "
  8   .���  �@ ImageHeight$ 15����  �@ 
ImageWidth$ 15����  �@ ImageBackgroundBrush8  ��  �@ BackgroundHoverBrush8  ��  �@ BackgroundClickBrush8  �� ! �@ ImageBackgroundHoverBrush8  �� ! �@ ImageBackgroundClickBrush8  ��  �@ BackgroundBrush
 ���� �� "
  .���  � ��8   ��  �@ ImageHeight$ 18����  �@ 
ImageWidth$ 18����  � ��$
 32.5����  � �� �� .R��� $��
MainBorder������  �� *TemplatedParent+$ Width�����  �� *TemplatedParent+$ Height�._��� $��ImageRec������  �� *TemplatedParent+$ ImageHeight�����  �� *TemplatedParent+$ 
ImageWidth� �� $ Uniform=� ��  �� *TemplatedParent+$ Image����� "
 ��.���  � �� ��  �� *TemplatedParent+$ ImageBackgroundBrush� ��  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � �� ��  �� *TemplatedParent+$ ImageBackgroundClickBrush���  �� $ 
MainBorder��$ IsMouseOver� True.a���  � �� ��  �� *TemplatedParent+$ ImageBackgroundHoverBrush����� "
 ��.���  � �� ��  �� *TemplatedParent+$ BackgroundBrush� ��  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � �� ��  �� *TemplatedParent+$ BackgroundClickBrush���  �� $ 
MainBorder��$ IsMouseOver� True.a���  � �� ��  �� *TemplatedParent+$ BackgroundHoverBrush��� "
  .���  �@ 
ImageWidth$ 25����  �@ ImageHeight$ 25����  � ��$ 5,5,5,5q���  �@ ImageBackgroundBrush8   �� ! �@ ImageBackgroundHoverBrush8  �� ! �@ ImageBackgroundClickBrush8  ��  � �� �� "  .R��� ����  �� $ TemplatedParent=�$ Margin�����  �� $ TemplatedParent=�$ ImageHeight�����  �� $ TemplatedParent=�$ 
ImageWidth� �� $ Uniform=�$ HighQuality=� ��  �� $ TemplatedParent=�$ Image����� "
 ��.���  � �� ��  �� *TemplatedParent+$ ImageBackgroundBrush� ��  �� *IsMouseOver+ �� $ TemplatedParent=� True.a���  � �� ��  �� *TemplatedParent+$ ImageBackgroundHoverBrush���  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � �� ��  �� *TemplatedParent+$ ImageBackgroundClickBrush��� "
  .���  � ��8   ��  �@ ImageBackgroundBrush8  �� ! �@ ImageBackgroundHoverBrush8  �� ! �@ ImageBackgroundClickBrush8  ��  �@ BackgroundBrush
 ���� ��  �@ BackgroundHoverBrush8  ��  �@ BackgroundClickBrush8  ��  � �� �� "  .R��� $ 
MainBorder��._�� $ ContainerGrid��$��20,12,20,12q� �� $
��auto ��� $ LabelColumn��$
��auto �.+��� $��0��$��30��$��30��$��Center=� �� $ HighQuality=� ��  �� $ TemplatedParent=�$ Image����� "
 ��.���  � �� ��  �� $ TemplatedParent=�$ ImageBackgroundBrush� ��  ��  �� $ TemplatedParent=�$ IsMouseOver� True.a���  � �� ��  �� $ TemplatedParent=�$ ImageBackgroundHoverBrush���  ��  �� $ TemplatedParent=�$ 	IsPressed� True.a���  � �� ��  �� $ TemplatedParent=�$ ImageBackgroundClickBrush��� $ ButtonLabel��$��1��$��13(�$��DemiBold"�$
��Left=�$��Center=�$��15,0,0,0q�����  �� $ TemplatedParent=�$ Content�   $  10Q�$! 0Q�$	" 0.5Q����� "
 ��.���  � �� ��  �� $ TemplatedParent=�$ ImageBackgroundBrush� ��  ��  �� $ TemplatedParent=�$ IsMouseOver� True.a���  � �� ��  �� $ TemplatedParent=�$ ImageBackgroundHoverBrush���  ��  �� $ TemplatedParent=�$ 	IsPressed� True.a���  � �� ��  �� $ TemplatedParent=�$ ImageBackgroundClickBrush����� "
 ��.���  � ��
 ����  ��  ��  �� $ TemplatedParent=�$ 	IsPressed� True.a���  � �� ��  �� $ TemplatedParent=�$ BackgroundClickBrush�# :� $$ 
MouseEnter��.[��� .���� $1% +(Border.Background).(SolidColorBrush.Color)�.���� 8&  $' 0:0:0.25D�( ��  �� $ TemplatedParent=�$  BackgroundHoverBrush.Color�:� $$ 
MouseLeave��.[��� .���� $1% +(Border.Background).(SolidColorBrush.Color)�.���� 8(  $' 0:0:0.25D�& ��  �� $ TemplatedParent=�$  BackgroundHoverBrush.Color��� "
 ��.���  � �� �� .R�� .+��� $ 
MainBorder��$) 15��$��30��   $  15Q�$! 0Q�$	" 0.5Q����� "
 ��.���  � ��8    ��  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � ��8  �� $ HoverBorder��$) 15��$��30��$* 0Q�8�� # :� $$ 
MouseEnter��.[��� .���� $% Opacity�.��W� $' 0:0:0.15D�$+ 1X�$, 0X�:� $$ 
MouseLeave��.[��� .���� $% Opacity�.��W� $' 0:0:0.15D�$+ 0X�$, 1X��� - .  $��Center=�$��Center=�$��DemiBold"�$��	10,0,10,0q�����  �� *TemplatedParent+$ Content��� "
 ��.���  � ��
 �   ���  � �� �� .R��� $��
MainBorder��$) 15��$��30��   $  6Q�$! 0Q�$" 1Q�._��� $ ButtonLabel��$��Center=�$��Center=�$��DemiBold"�����  �� *TemplatedParent+$ Content����� "
 ��.���  � ��8    ��  �� *IsMouseOver+ �� $ TemplatedParent=� True.a���  � �� ��  �� $ TemplatedParent=�$ 
Foreground���  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � �� ��  �� $ TemplatedParent=�$ 
Foreground����� "
 ��.���  � ��
 ���� ��  � ��8  ��  �@��Padding$ 	15,0,15,0q���  � ��$ 1q� P� . �@J�IsMouseOver/ . . ���  � ��8  ��  � ��$ 0q���  �@��Padding$ 	16,0,16,0q���  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � ��8  ��  � ��$ 0q���  �@��Padding$ 	16,0,16,0q��� "
 ��.���  � ��
 �   ���  � ��$ 1,2,1,2q���  � �� �� .R��� $��
MainBorder��$) 15��$��30������  �� $ TemplatedParent=�$ Margin�   $  6Q�$! 0Q�$
" 0.25Q�._��� $ ButtonLabel��$��Center=�$��Center=�$��DemiBold"�$��10(�����  �� *TemplatedParent+$ Content����� "
 ��.���  � ��
 �   � ��  �� *IsMouseOver+ �� $ TemplatedParent=� True.a���  � �� ��  �� $ TemplatedParent=�$ 
Foreground���  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � �� ��  �� $ TemplatedParent=�$ 
Foreground����� "
 ��.���  � ��8    P� . �@J�IsMouseOver/ . . ���  � ��8  ��  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � ��8  �� "
 ��.���  � ��
 �   ���  � ��$ 1,2,1,2q���  � �� �� .R��� $��
MainBorder��$) 15��$��30������  �� $ TemplatedParent=�$ Margin�   $  6Q�$! 0Q�$
" 0.25Q�._��� $ ButtonLabel��$��Center=�$��Center=�$��DemiBold"�$��10(�����  �� *TemplatedParent+$ Content����� "
 ��.���  � ��8    ��  �� *IsMouseOver+ �� $ TemplatedParent=� True.a���  � �� ��  �� $ TemplatedParent=�$ 
Foreground���  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � �� ��  �� $ TemplatedParent=�$ 
Foreground����� "
 ��.���  � ��
 ���� ��  � ��8  ��  �@��Padding$ 5,0,5,0q���  � ��$ 1q� P� . �@J�IsMouseOver/ . . ���  � ��8  ��  � ��$ 0q���  �@��Padding$ 	16,0,16,0q���  �� *	IsPressed+ �� $ TemplatedParent=� True.a���  � ��8  ��  � ��$ 0q���  �@��Padding$ 	16,0,16,0q��� "
 ��.���  � ��$	 ???����  � �� �� " ��.R��� $��20��$��12, 0, 12, 0q�$) 
5, 5, 0, 0��._��� $
��Bold"�$��10,0,0,0q�$��Center=�$��Center=�8��  ����  �� $ TemplatedParent=�$ Content����� "
 ��.���  � ��8   P� . �@J�IsMouseOver/ . . ���  � ��8  �� "
  .���  � ��$ 12(���  � �� �� "  .R��� $ ContainerBorder��._��� $��Center=�$��	Underline{�����  �� $ TemplatedParent=�$ Content����� "
 ��.���  � ��8    ��  ��  �� $ TemplatedParent=�$ IsMouseOver� True.a���  � ��8  �� "
  .���  � |� .  ��  �@ FocusedUnderlineBrush8   ��  �@ HoverUnderlineBrush8  ��  �@ InvalidDataLoaded .  ��  �@ InvalidDataBrush �#FF6767��  � �� �� "  .R�� $��3,6,3,6q�0 �� $��23 ��� $
��auto �.+��� $��UserInputBox��$��10,0,0,0q�$��0��$��0q�$��13(�
������ 81  ����  �� $ TemplatedParent=�$
 Text�.������ "
 ��.���  � ��8   ��  ��  �� $ TemplatedParent=�$ InvalidDataLoaded� True.a���  � �� ��  �� $ TemplatedParent=�$ InvalidDataBrush�.���� $��0��$��15,0,0,0q�$��13(�- .  |�.  $��Normal"�8�� ����  �� *TemplatedParent+$ PromptingText����� "
 �� ��  �� $ UserInputBox��$
 Text�82   True.a���  � y�$ Hidden=��� $��	Underline��3 . 4 . $��1��$��0q����� "
 ��.���  � ��8  ��  � ��$ 1����  � ��$ 0,1,0,0q� ��  �� $ UserInputBox��$ IsMouseOver� True.a���  � �� ��  �� *TemplatedParent+$ HoverUnderlineBrush���  ��  �� $ TemplatedParent=�$ InvalidDataLoaded� True.a���  � �� ��  �� $ TemplatedParent=�$ InvalidDataBrush���  � ��$ 2����  � ��$ 0,0,0,0q���  �� $ UserInputBox��$ 	IsFocused� True.a���  � �� ��  �� *TemplatedParent+$ FocusedUnderlineBrush���  � ��$ 2����  � ��$ 0,0,0,0q��� "
  .���  � |� .  ��  �@ FocusedUnderlineBrush8   ��  �@ HoverUnderlineBrush8  ��  � �� �� "  .R�� $ ContainerGrid��$��3,6,3,6q�5 . ���� $ ActualWidth�$ ContainerGrid��82  $	6 0.5��.+��� $��UserInputBox��$��10,0,0,0q�$��0��$��0q�$��13(�$
7 Wrap=�
������ $
��Left=�81  8�� ����  �� $ TemplatedParent=�$
 Text�$8 TwoWay=�$9 PropertyChanged=����� $ ActualWidth�$ ContainerGrid��82  $	6 0.9������ $ ActualWidth�$ ContainerGrid��.���� $��0��$��15,0,0,0q�$��13(�- .  |�.  $��Italic$�$��Normal"�$
��Left=�8�� ���� $ ActualWidth�$ ContainerGrid��82  $	6 0.9������  �� *TemplatedParent+$ PromptingText����� "
 �� ��  �� $ UserInputBox��$
 Text�82   True.a���  � y�$ Hidden=��� "
  .���  � |� .  ��  �@ FocusedUnderlineBrush8   ��  �@ HoverUnderlineBrush8  ��  � �� �� "  .R�� $��3,6,3,6q�0 �� $��23 ��� $
��auto �.+�G� $��UserInputBox��$��10,0,0,0q�$��0��$��0q�$��13(�
������ 8�� �� $��0��$��15,0,0,0q�$��13(�- .  |�.  $��Normal"�8�� ����  �� *TemplatedParent+$ PromptingText����� "
 �� ��  ��  �� $ TemplatedParent=�$ FieldCompleted� True.a���  � y�$ Hidden=��� $��	Underline��3 . $��1��$��0q����� "
 ��.���  � ��8  ��  � ��$ 1����  � ��$ 0,1,0,0q� ��  �� $ UserInputBox��$ IsMouseOver� True.a���  � �� ��  �� *TemplatedParent+$ HoverUnderlineBrush���  �� $ UserInputBox��$ 	IsFocused� True.a���  � �� ��  �� *TemplatedParent+$ FocusedUnderlineBrush���  � ��$ 2����  � ��$ 0,0,0,0q��� "
 ��.���  � �� �� " ��.R��� $��ContainerBorder��$
��auto��
������ $
��Left=�$��3q�._�� $��0,0,0,0q� �� $
��auto ��� $��* �.+�� $��0��$��23��$	��Top=�.+��� $ ToggleContainer��$��0,0,10,0q�$	��Top=�$��Center=�$��20��$��20��$) 4��$��2q�8��  F� $: 	CheckIcon��8�� $	��Top=�$
��Left=�$��2,-1,0,5q�Z����`� .͕ ��72��@�� �D�l��I @8� Ѽv@W" Q�1D��6�
@�ă ���;�����?.͕ 	�� $��1��$��0,0,0,0q�$; 0,0,0,0q�._��� $��Center=�#��z��$��12(�$
��Wrap=�8�� $��DemiBold"�< P� . �@d�	IsChecked$
/ TrueY�. ��� $= 	CheckIcon�� � y�$ Visible=��� $= ToggleContainer��8   � ��P� . �@d�	IsChecked$/ FalseY�. ��� $= 	CheckIcon�� � y�$ Hidden=�P� . �@J�IsMouseOver/ . . ��� 8  $= 	CheckIcon�� � ��]� > �� ? �@J�IsMouseOver@ . �� ? �@d�	IsChecked$
@ trueY�/��� 8  $= 	CheckIcon�� � ��]� > �� ? �@J�IsMouseOver@ . �� ? �@d�	IsChecked$@ falseY�/��� 8  $= 	CheckIcon�� � ���� $= 	CheckIcon�� � y�$ Visible=��� $= 	CheckIcon�� �@J�Opacity$
 0.50Q��� "
 ��.���  � �� �� " ��.R��� $��ContainerBorder��$
��auto��
������ $
��Left=�$��3q�._��  �� $
��auto ��� $��* �.+�� $��0��$	��Top=�.+��� $ ToggleContainer��$��0,0,10,0q�$��Center=�$��20��$��34��8��   �� $ HighQuality=�8  �� $��1��$��0,0,0,0q�$; 0,0,0,0q�._��� $��Center=�#��z��$��12(�$��WrapWithOverflow=�8�� $��DemiBold"�< P� . �@d�	IsChecked$
/ trueY�. ��� 8  $= ToggleContainer�� � ���� $= ToggleContainer�� �@J�OpacityMask �� 8  ]� > �� ? �@J�IsMouseOver@ . �� ? �@d�	IsChecked$
@ trueY�/��� 8  $= ToggleContainer�� � ��]� > �� ? �@J�IsMouseOver@ . �� ? �@d�	IsChecked$@ falseY�/��� 8  $= ToggleContainer�� � ���� "
 ��.���  � �� �� " ��.R��� $��ContainerBorder��$
��auto��
������ $
��Left=�$��	15,1,15,1q�._��  �� $��50 ��� $��* �.+�� $��0��.+��� $ ToggleContainer��$��0,0,10,0q�$��Center=�$��20��$��34��8��  $ HighQuality=�   $  10Q�$! 0Q�$	" 0.5Q� �� $ HighQuality=�8  �� $��1��$��-5,0,0,0q�$; 0,0,0,1q�._��� $��Center=�#��z��8�� $��DemiBold"�   $  10Q�$! 0Q�$	" 0.5Q�< P� . �@d�	IsChecked$
/ trueY�. ��� 8  $= ToggleContainer�� � ���� $= ToggleContainer�� �@J�OpacityMask �� 8  ]� > �� ? �@J�IsMouseOver@ . �� ? �@d�	IsChecked$
@ trueY�/��� 8  $= ToggleContainer�� � ��]� > �� ? �@J�IsMouseOver@ . �� ? �@d�	IsChecked$@ falseY�/��� 8  $= ToggleContainer�� � ���� "
 ��.���  � �� �� " ��.R��� $��30��$��50��$��0,0,0,0q�$) 	0,0,10,10��._��� $��0q�8��  $��30��$��30�� �� 8  $ Uniform=�$ HighQuality=����� "
 ��.���  � ��8   P� . �@J�IsMouseOver/ . . ���  � ��8  �� "
 ��.���  � ��$ Center=���  � ��8   �� "
  .���  �@ IsInitialMessage . ��  � �� �� "  .R��� $ 	Container��
������ - .  $��0,0,0,0q�._��� $��1��8��  $	��150��$��2q�$) 12��$; 	12,6,12,6q�$
��Left=����� $ ActualWidth�$ 	Container��82  $
6 0.75��   $  10Q�$	" 0.5Q�$! 0Q�._�� 5 .  0 �� ��  �� �� $
��auto �.+��� $��0��$��0��8�� $��DemiBold"�$
��auto��$��0,0,0,2q�����  �� $ TemplatedParent=�$ MessageSender����� "
 ��.���  � y�$ Visible=� ��  ��  �� $ TemplatedParent=�$ IsInitialMessage�	 False.a���  � y�$ 	Collapsed=��� $��1��$��0��$��0,0,10,0q�8�� $
��Wrap=�$��Bottom=�$��1��$
��auto������  �� $ TemplatedParent=�$ MessageContent��� $��2��$��1��$��10(�$��0,0,0,0q�$��Right=�$A Right=�$��Bottom=�8�� ����  �� $ TemplatedParent=�$ MessageTime�# :� $$ Border.Loaded��.[��� .���� .��t� $' 0:0:0.25D�$B 0,0,0,0X�$C 	0,0,0,-55X�$% Margin�W� $' 0:0:0.25D�$+ 1X�$, 0X�$% Opacity��� "
  .���  �@ IsInitialMessage . ��  � �� �� "  .R��� $ 	Container��
������ - .  $��0,0,0,0q�._��� $��1��8��  $	��125��$��2q�$) 10��$; 	12,6,12,6q�$��Right=����� $ ActualWidth�$ 	Container��82  $
6 0.75��   $  10Q�$	" 0.5Q�$! 0Q�._�� 5 .  0 �� ��  �� �� $
��auto �.+��� $��0��$��0��8�� $��DemiBold"�$
��auto��$y�	Collapsed=�$��0,0,0,2q�����  �� $ TemplatedParent=�$ MessageSender����� "
 ��.���  � y�$ Visible=� ��  ��  �� $ TemplatedParent=�$ IsInitialMessage�	 False.a���  � y�$ 	Collapsed=��� $��1��$��0��$��0,0,10,0q�8�� $
��Wrap=�$��Bottom=�$
��auto������  �� $ TemplatedParent=�$ MessageContent��� $��2��$��1��$��10(�$��Center=�$��Bottom=�8�� ����  �� $ TemplatedParent=�$ MessageTime�# :� $$ Border.Loaded��.[��� .���� .��t� $' 0:0:0.25D�$B 0,0,0,0X�$C 	0,0,0,-55X�$% Margin�W� $' 0:0:0.25D�$+ 1X�$, 0X�$% Opacity��� $ Black���� $
 #DDD���� $
 Gray���� $ White���� $
 #888���� $
 #444���� $
 #888���� $
 #888���� $ #383838���� $
 #888���� $ #959592���� $ #959592���� $ #959592���� "
 ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � |� .  ��  � �� �� " ��.R��� $��Border��$��1q�$) 2��8��  8�� $��1q�._�F� $��Center=�$��Center=�8�� ���� $ Content� �� *TemplatedParent+< P� . � ��/ . . ��� $= Border��8   � ��P� . � {�/ .  . ��� 8   � ���� "
 ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
���   ��� "
 n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " n�.R��� $) 4��#��z��#��z��$��0q�$��8��$��8,0,-2,0q��� " ��.R�� 0 �� $��0���� $��0.00001* ��� $��0��.+��� $��3��$) 2��
������ �� $��0��8��  $��18��$��ScrollBar.LineUpCommand��$��M 0 4 L 8 4 L 4 0 Z��]� $��
PART_Track��$��1����. D �� 8�� $��ScrollBar.PageUpCommand��E n� 8�� $��1,0,1,0q�8�� 8�� F �� 8�� $��ScrollBar.PageDownCommand���� $��3��8�� $��18��$��ScrollBar.LineDownCommand��$��M 0 0 L 4 4 L 8 0 Z���� " ��.R��  �� $��18���� $��0.00001* ��� $��18��.+��� $��3��$) 2�����#F0F0F0�� $��0��8��  $��18��$��ScrollBar.LineLeftCommand��$��M 4 0 L 4 8 L 0 4 Z��]� $��
PART_Track��$��1����.  D �� 8�� $��ScrollBar.PageLeftCommand��E n� 8�� $��0,1,0,1q�8�� 8�� F �� 8�� $ ��ScrollBar.PageRightCommand���� $��3��8�� $��18��$ ��ScrollBar.LineRightCommand��$��M 0 0 L 4 4 L 0 8 Z���� "
 ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  P� . �@��Orientation$/ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 18����  � ��8   P� . �@��Orientation$/ Vertical=�. ���  � ��$ 18����  � ��$
 Auto����  � ��8  �� "
 ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��  �� �� $
��Auto �.+��� $��0���� $��PART_VerticalScrollBar��$��1��$��0,5,5,5q�#H zG #J zI #L zK #y�zM �� "
 ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��  �� �� $
��Auto �.+��� ._��� $��0�� �� $	N 0,0&�$	O 0,1&�.��� $ Transparent��$
 0.01Q�� $ White��$	 0.1Q�� $ White��$	 0.9Q�� $ Transparent��$
 0.99Q��� $��PART_VerticalScrollBar��$��1��$��0,5,5,5q�#H zG #J zI #L zK #y�zM �� "
  .���  �@ User$ UserNameNotDefined����  �@ FileName$ FileNameNotDefined����  �@ FileDuration$ FileDurationNotDefined����  �@ FileSize$ FileSizeNotDefined����  � �� �� "  .R��� 8��  $��10,5,0,5q�$) 10��   $  12Q�$! 0Q�$	" 0.5Q�._�� $��15, 10, 10, 10q�0 �� �� ��  �� $
��auto ��� .+��� $��0��$��13(�$��0,0,0,3q�$��DemiBold"�8�� ����  �� $ TemplatedParent=�$
 User��� $��1��8�� ����  �� $ TemplatedParent=�$ FileName��� $��1��$��1��$��10,0,0,0q�8�� ����  �� $ TemplatedParent=�$ FileSize��� $��0,2,0,0q�$��2��$��0��8�� ����  �� $ TemplatedParent=�$ FileDuration��� "
 d�.���  � |� .  ��  � �� �� " d�.R�� $��14��$��14��.+��� #��� i �� $��ExpandBorder��$P Aliased=�
���   �$��2q�._�F� $��
ExpandPath��$P Aliased=�
���   �$��0q�$��2��+����@KL @B �@KL @T� �@B @KL �@T� @KL 	< P� . �@d�	IsChecked$
/ TrueY�. ��� $= 
ExpandPath�� � �� ��@B @KL �@T� @KL 	P� . � {�/ .  . ��� $= ExpandBorder�� � ��
 ������� $= 
ExpandPath�� � ��
 ������� $= 
ExpandPath�� � �� �	�� "
 ��.���  � ��$ 10���� "
 ��.���  � ��$ 5���� "
 	 .���  � �� �� " 	 .R��� 8��  $��5,0,5,5q�$) 5��._�� 5 .  $��10,5,5,5q�0 �� $
��auto ��� $
��auto � �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��$��0��$��2��$��DemiBold"�$��Center=�$��Center=�$A Center=�$
��Wrap=�$��60��$��60��$��0,0,10,0q�$��12(�8�� ����  �� $ TemplatedParent=�$ Username��� $��0��$��1��$��1��$��0,0,10,0q�8�� ����  �� $ TemplatedParent=�$ FileName�� $��1��$��1�� �� $
��auto ��� $
��auto �.+��� $��0��$��0,0,10,0q�$��12(�8�� ����  �� $ TemplatedParent=�$ FileSize��� $��2��$��12(�8�� ����  �� $ TemplatedParent=�$ FileDuration��� $Q 
Horizontal=�$��0��$��2��$��2��$��0,0,0,0q��� "
 
 .���  � �� �� " 
 .R��� $��
0,-100,0,0q�._��� 8��  $��7,2,0,2q�$) 10��$; 5q�._�� $��7q�5 .   �� $
��auto ��� 0 �� �� .+��� $��1��$��0��$��0,0,0,0q�$��15(�$��DemiBold"�8�� ����  �� $ TemplatedParent=�$ Title��� $��1��$��1��$��WrapWithOverflow=�8�� ����  �� $ TemplatedParent=�$ Message�  $R CloseButton��$��0��$��2��$��0,0,5,0q�$S 30��8�� 8T  # :� $$ Border.Loaded��.[��� .���� .��t� $' 0:0:0.5D�$C 
0,-100,0,0X�$B 0,0,0,0X�$% Margin�W� $' 0:0:0.25D�$+ 1X�$, 0X�$% Opacity��� "
  .���  �@ Image8   ��  �@ ImageBackgroundBrush8  ��  � �� �� "  .R��� $��25��$��25��$��3q�����  �� $ TemplatedParent=�$ ImageBackgroundBrush� �� $ HighQuality=� ��  �� $ TemplatedParent=�$ Image��� "
 ��.���  � �� �� " ��.R��� $; 3q�._�� 0 �� $��26 ��� $��1* �.+��� $��0��$; 10,0,0,0q�._��� $��HeaderPanel��U . $V 1��$W 1���� $��1��$) 5��$; 5q�8��  ._��� $��SelectedContent��   $  13Q�$! 0Q�$	" 0.5Q��� "
 ��.���  � ��$ 0q���  � �� �� " ��.R��� $��Border��$) 5,5,0,0��$��2,0,2,0q�$��26��._��� $ ContentSite��$��Center=�$��Center=�#��z��$
��20,2q�8��  $��Normal"�< P� . �@��
IsSelected/ . . ��� $= Border��8   � ��P� . �@��
IsSelected/ .  . ��� $= Border��8   � ��