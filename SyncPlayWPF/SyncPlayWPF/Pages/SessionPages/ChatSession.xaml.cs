﻿using SyncPlayWPF.SyncPlay;
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

        private bool LastAdditionWasChatInfo = false;
        private User LastSender = null;

        private void OnPageLoad(object sender, RoutedEventArgs e) {
            Common.Shared.Wrapper.SyncPlayClient.OnNewChatMessage += NewChatMessage;
            Common.Shared.Wrapper.SyncPlayClient.OnChatInfoEvent += NewChatEvent;

            Common.Shared.Wrapper.SyncPlayClient.OnFileSet += SyncPlayClient_OnFileSet;
            Common.Shared.Wrapper.SyncPlayClient.OnUserRoomEvent += SyncPlayClient_OnUserRoomEvent;

            

            LoadUserName();
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
                    spacer.Style = (Style)this.FindResource("ChatInfoSpacer");
                    MessageStack.Children.Add(spacer);
                }
                LastAdditionWasChatInfo = false;
                LastSender = u;
                MessageStack.Children.Add(c);
            }

            if (isAtBottom) {
                ChatScrollView.ScrollToEnd();
            }
    
        }

        private void LoadUserName() {
            foreach (var u in Common.Shared.Wrapper.SyncPlayClient.UserDictionary.Values) {
                var newControl = new CustomControls.UserSessionView();
                newControl.Username = u.Username;
                newControl.FileDuration = "NA";
                newControl.FileName = "NA";
                newControl.FileSize = "NA";
                UserStack.Children.Add(newControl);
            }
        }

        private void SyncPlayClient_OnUserRoomEvent(SyncPlayClient sender, SyncPlay.SPEventArgs.UserRoomStateEventArgs e) {
            if (e.EventType == SyncPlay.SPEventArgs.UserRoomStateEventArgs.EventTypes.JOINED) {
                Dispatcher.Invoke(() => {
                    var newControl = new CustomControls.UserSessionView();
                    newControl.Username = e.User.Username;
                    newControl.FileDuration = "NA";
                    newControl.FileName = "NA";
                    newControl.FileSize = "NA";

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
            throw new NotImplementedException();
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
                if (LastAdditionWasChatInfo || LastSender != e.Sender) {
                    var spacer = new Border();
                    spacer.Style = (Style)this.FindResource("ChatInfoSpacer");
                    MessageStack.Children.Add(spacer);
                    LastAdditionWasChatInfo = false;
                }
                var msgballoon = new CustomControls.ChatMessage();
                msgballoon.Style = e.LocallySentMessage ? (Style)this.FindResource("OutgoingMessage") : (Style)this.FindResource("IncomingMessage");
                msgballoon.MessageSender = e.Sender.Username;
                msgballoon.MessageContent = e.Message;
                msgballoon.IsInitialMessage = LastSender == null || LastSender != e.Sender;
                msgballoon.MessageTime = DateTime.Now.ToString("hh:mm tt");


                this.AddItemToStack(msgballoon, false, e.Sender);

                //var text = new TextBlock();
                //text.Text = e.Message;
                //var isAtBottom = ChatScrollView.VerticalOffset == ChatScrollView.ScrollableHeight;

                //if (isAtBottom) {
                //    MessageStack
                //}


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
            if (e.Key == Key.Enter) {
                SendMessage();
            }
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



            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = new TimeSpan(0, 0, 2);
            //timer.Tick += ((sender, e) =>
            //{
            //    ChatScrollView.Height += 10;

            //    if (ChatScrollView.VerticalOffset == ChatScrollView.ScrollableHeight) {
            //        ChatScrollView.ScrollToEnd();
            //    }
            //});
            //timer.Start();
        }

        

        
    }
}
