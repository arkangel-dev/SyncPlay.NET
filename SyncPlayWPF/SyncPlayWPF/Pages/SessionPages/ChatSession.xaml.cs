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

namespace SyncPlayWPF.Pages.SessionPages {
    /// <summary>
    /// Interaction logic for ChatSession.xaml
    /// </summary>
    public partial class ChatSession : UserControl {
        public ChatSession() {
            InitializeComponent();

            this.Loaded += OnPageLoad;
        }

        private void OnPageLoad(object sender, RoutedEventArgs e) {
            Common.Shared.Wrapper.SyncPlayClient.OnNewChatMessage += NewChatMessage;
        }

        private void NewChatMessage(SyncPlay.SyncPlayClient sender, SyncPlay.EventArgs.ChatMessageEventArgs e) {
            Console.WriteLine("NEW MESSAGE!");
            Dispatcher.Invoke(() => {
                var msgballoon = new CustomControls.ChatMessage();
                msgballoon.Style = (Style)this.FindResource("IncomingMessage");
                msgballoon.MessageSender = e.Sender.Username;
                msgballoon.MessageContent = e.Message;
                msgballoon.MessageTime = DateTime.Now.ToString("hh:mm tt");

                var text = new TextBlock();
                text.Text = e.Message;

                MessageStack.Children.Add(msgballoon);
            });
            
        }
    }
}
