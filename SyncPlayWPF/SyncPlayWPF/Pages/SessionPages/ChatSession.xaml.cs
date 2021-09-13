using SyncPlayWPF.SyncPlay;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SyncPlayWPF.Pages.SessionPages {

    public partial class ChatSession : UserControl {
        public ChatSession() {
            InitializeComponent();
            this.Loaded += OnPageLoad;
        }

        private bool InitialPageLoaded = false;
        private bool LastAdditionWasChatInfo = false;
        private User LastSender = null;

        private void OnPageLoad(object sender, RoutedEventArgs e) {
            if (!InitialPageLoaded) {
                Common.Shared.Wrapper.SyncPlayClient.OnNewChatMessage += NewChatMessage;
                Common.Shared.Wrapper.SyncPlayClient.OnChatInfoEvent += NewChatEvent;
                Common.Shared.Wrapper.SyncPlayClient.OnFileSet += SyncPlayClient_OnFileSet;
                Common.Shared.Wrapper.SyncPlayClient.OnUserRoomEvent += SyncPlayClient_OnUserRoomEvent;
                LoadUserName();
                InitialPageLoaded = true;
            }
        }
        private void LoadUserName() {
            foreach (var u in Common.Shared.Wrapper.SyncPlayClient.UserDictionary.Values) {
                var newControl = new CustomControls.UserSessionView();
                newControl.Username = u.Username;
                newControl.FileDuration = "";
                newControl.FileName = "";
                newControl.FileSize = "";
                UserStack.Children.Add(newControl);
            }
        }

        private void ChatScrollView_PreviewMouseWheel(object sender, MouseWheelEventArgs e) {
            var isAtBottom = ChatScrollView.VerticalOffset == ChatScrollView.ScrollableHeight;
            if (isAtBottom) {
                DropDownToBottomButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AddItemToStack(UIElement c, bool isEventMsg, User u) {
            var isAtBottom = ChatScrollView.VerticalOffset == ChatScrollView.ScrollableHeight;
            if (isEventMsg) {
                if (!LastAdditionWasChatInfo) {
                    var spacer = new Border();
                    spacer.Style = (Style)this.FindResource("ChatInfoSpacer");
                    MessageStack.Children.Add(spacer);
                }
                LastAdditionWasChatInfo = true;
                MessageStack.Children.Add(c);
            } else {
                if (LastSender != u || LastAdditionWasChatInfo) {
                    var spacer = new Border();
                    spacer.Style = (Style)this.FindResource(LastAdditionWasChatInfo ? "ChatInfoSpacer" : "ThinChatInfoSpacer");
                    MessageStack.Children.Add(spacer);
                }
                LastAdditionWasChatInfo = false;
                LastSender = u;
                MessageStack.Children.Add(c);
            }
            if (isAtBottom) {
                ChatScrollView.ScrollToEnd();
            } else {
                if (!isEventMsg) {
                    DropDownToBottomButton.Visibility = Visibility.Visible;
                }
            }
        }

        private void SyncPlayClient_OnUserRoomEvent(SyncPlayClient sender, SyncPlay.SPEventArgs.UserRoomStateEventArgs e) {
            if (e.EventType == SyncPlay.SPEventArgs.UserRoomStateEventArgs.EventTypes.JOINED) {
                Dispatcher.Invoke(() => {
                    var newControl = new CustomControls.UserSessionView();
                    newControl.Username = e.User.Username;
                    newControl.FileDuration = "";
                    newControl.FileName = "";
                    newControl.FileSize = "";

                    UserStack.Children.Add(newControl);
                });
            } else {
                Dispatcher.Invoke(() => {
                    foreach (var c in UserStack.Children) {
                        if (((CustomControls.UserSessionView)c).Username == e.User.Username) {
                            UserStack.Children.Remove((CustomControls.UserSessionView)c);
                            break;
                        }
                    }
                });
            }
        }

        private void SyncPlayClient_OnFileSet(SyncPlay.SyncPlayClient sender, SyncPlay.SPEventArgs.RemoteSetFileEventArgs e) {
            Dispatcher.Invoke(() => {
                Console.WriteLine("File loaded event");
                foreach (CustomControls.UserSessionView uc in UserStack.Children) {
                    if (uc.Username == e.Agent.Username) {
                        uc.FileDuration = SyncPlay.Misc.Common.ConvertSecondsToTimeStamp((int)e.File.Duration);
                        uc.FileName = System.IO.Path.GetFileName(e.File.FilePath);
                        uc.FileSize = Common.Methods.ConvertByteSize(e.File.Size);
                        return;
                    }
                }
                Console.WriteLine("Warning : Unknown user has loaded a file!");
            });
        }

        private void NewChatEvent(SyncPlay.SyncPlayClient sender, SyncPlay.SPEventArgs.ChatInfoMessageArgs e) {
            Dispatcher.Invoke(() => {
                if (!LastAdditionWasChatInfo) {

                }
                var msgblock = new TextBlock();
                msgblock.Text = e.Message;
                msgblock.Style = (Style)this.FindResource("ChatInfo");
                AddItemToStack(msgblock, true, null);
            });
        }

        private void NewChatMessage(SyncPlay.SyncPlayClient sender, SyncPlay.SPEventArgs.ChatMessageEventArgs e) {
            Dispatcher.Invoke(() => {
                var msgballoon = new CustomControls.ChatMessage();
                msgballoon.Style = e.LocallySentMessage ? (Style)this.FindResource("OutgoingMessage") : (Style)this.FindResource("IncomingMessage");
                msgballoon.MessageSender = e.Sender.Username;
                msgballoon.MessageContent = e.Message;
                msgballoon.IsInitialMessage = LastSender == null || LastSender != e.Sender;
                msgballoon.MessageTime = DateTime.Now.ToString("hh:mm tt");
                this.AddItemToStack(msgballoon, false, e.Sender);
            });
        }

        private void SendMessageButtonClick(object sender, RoutedEventArgs e) {
            SendMessage();
        }

        private void SendMessage() {
            if (!String.IsNullOrWhiteSpace(MessageBlockField.Text)) {
                Common.Shared.Wrapper.SyncPlayClient.SendChatMessage(MessageBlockField.Text);
                if (ChatScrollView.VerticalOffset != ChatScrollView.ScrollableHeight)
                    ChatScrollView.ScrollToBottom();
            }
            MessageBlockField.Text = "";
        }

        private void SendMessageEnterClick(object sender, KeyEventArgs e) {
            if (e.Key != Key.Enter) return;
            if (String.IsNullOrWhiteSpace(MessageBlockField.Text)) {
                MessageBlockField.Text = "";
                return;
            };
            if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) {
                MessageBlockField.Text += "\n";
                MessageBlockField.MoveToEndPosition();
                return;
            }
            SendMessage();
        }
        private void SendMessageShiftEnter(object sender, KeyEventArgs e) {
            
        }

        private bool UserListExpanded = false;

        private void ToggleUserList(object sender, RoutedEventArgs e) {
            UserListBorder.BeginAnimation(Border.MaxHeightProperty, null);
            var anim = new DoubleAnimation();
            anim.Duration = new Duration(TimeSpan.FromSeconds(1));
            if (UserListExpanded) {
                anim.From = 0;
                anim.To = this.ActualHeight /2;
                Console.WriteLine("Checked");
            } else {
                anim.From = this.ActualHeight / 2;
                anim.To = 0;
                Console.WriteLine("Not Checked");
            }
            UserListExpanded = !UserListExpanded;
            UserListBorder.BeginAnimation(Border.MaxHeightProperty, anim);
        }

        private void ScrollToBottomSmoothly() {
            var anim = new DoubleAnimation();
            anim.Duration = new Duration(TimeSpan.FromSeconds(1));
            anim.To = ChatScrollView.ScrollableHeight;
            anim.From = ChatScrollView.VerticalOffset;
            ChatScrollView.BeginAnimation(ScrollViewer.VerticalOffsetProperty, anim);
        }

        private void DropDownToBottomButton_Click(object sender, RoutedEventArgs e) {
            ChatScrollView.ScrollToEnd();
            DropDownToBottomButton.Visibility = Visibility.Collapsed;
        }

        private void IgnorePlayerStateChangeClick(object sender, RoutedEventArgs e) {
            Common.Shared.IgnorePlayerStateChanges = (bool)IgnorePlayerStateChangeToggle.IsChecked;
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e) {
            MessageBlockField.Text += "\n";
        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e) {
            MessageBlockField.FocusOnControl();
        }        
    }
}
