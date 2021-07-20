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

namespace SyncPlayWPF.Pages.SessionPages {
    /// <summary>
    /// Interaction logic for ChatSession.xaml
    /// </summary>
    public partial class ChatSession : UserControl {
        public ChatSession() {
            InitializeComponent();
            this.Loaded += OnPageLoad;
        }

        private bool LastAdditionWasChatInfo = false;
        private SyncPlay.User LastSender = null;

        private void OnPageLoad(object sender, RoutedEventArgs e) {
            Common.Shared.Wrapper.SyncPlayClient.OnNewChatMessage += NewChatMessage;
            Common.Shared.Wrapper.SyncPlayClient.OnChatInfoEvent += NewChatEvent;
        }

        private void NewChatEvent(SyncPlay.SyncPlayClient sender, SyncPlay.EventArgs.ChatInfoMessageArgs e) {
            Console.WriteLine("_________-----__" + e.Message);
            Dispatcher.Invoke(() => {
                if (!LastAdditionWasChatInfo) {
                    var spacer = new Border();
                    spacer.Style = (Style)this.FindResource("ChatInfoSpacer");
                    LastAdditionWasChatInfo = true;
                    MessageStack.Children.Add(spacer);
                }
                var msgblock = new TextBlock();
                msgblock.Text = e.Message;
                msgblock.Style = (Style)this.FindResource("ChatInfo");
                MessageStack.Children.Add(msgblock);
            });
        }

        private void NewChatMessage(SyncPlay.SyncPlayClient sender, SyncPlay.EventArgs.ChatMessageEventArgs e) {
            Dispatcher.Invoke(() => {
                if (LastAdditionWasChatInfo) {
                    var spacer = new Border();
                    spacer.Style = (Style)this.FindResource("ChatInfoSpacer");
                    LastAdditionWasChatInfo = false;
                }
                var msgballoon = new CustomControls.ChatMessage();
                msgballoon.Style = e.LocallySentMessage ? (Style)this.FindResource("OutgoingMessage") : (Style)this.FindResource("IncomingMessage");
                msgballoon.MessageSender = e.Sender.Username;
                msgballoon.MessageContent = e.Message;
                msgballoon.IsInitialMessage = LastSender == null || LastSender != e.Sender;
                msgballoon.MessageTime = DateTime.Now.ToString("hh:mm tt");

                LastSender = e.Sender;

                var text = new TextBlock();
                text.Text = e.Message;

                MessageStack.Children.Add(msgballoon);
            });
        }

        private void SendMessageButtonClick(object sender, RoutedEventArgs e) {
            SendMessage();
        }

        private void SendMessage() {
            if (!String.IsNullOrWhiteSpace(MessageBlockField.Text)) {
                Common.Shared.Wrapper.SyncPlayClient.SendChatMessage(MessageBlockField.Text);
            } else {
                Console.WriteLine("Ignored Blank Message");
            }
            MessageBlockField.Text = "";
        }

        private void SendMessageEnterClick(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                SendMessage();
            }
        }
    }
}
