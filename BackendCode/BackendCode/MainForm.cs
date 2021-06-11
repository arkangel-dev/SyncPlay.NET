using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackendCode {
    public partial class MainForm : Form {


        SyncPlay.Client spclient;
        bool SyncThreadStarted = false;


        public MainForm() {
            InitializeComponent();

            spclient = new SyncPlay.Client("127.0.0.1", 5005, "Sammy", "", "ck", "1.2.7");
            spclient.OnUserRoomEvent += NewUserJoined;

            spclient.OnNewChatMessage += NewChatMessage;

        }

        private void NewChatMessage(SyncPlay.Client sender, SyncPlay.EventArgs.ChatMessageEventArgs e) {
            this.Invoke(new MethodInvoker(delegate () {
                ChatWindow.Text += $"{e.Sender.Username} : {e.Message}\n";
            }));
        }

        private void NewUserJoined(SyncPlay.Client sender, SyncPlay.EventArgs.UserRoomStateEventArgs e) {
            if (e.EventType.Equals(SyncPlay.EventArgs.UserRoomStateEventArgs.EventTypes.JOINED)) {
                this.Invoke(new MethodInvoker(delegate () {
                    UserList.Items.Add(e.User);
                }));
            } else {
                 this.Invoke(new MethodInvoker(delegate () {
                    UserList.Items.Remove(e.User);
                }));
            }
        }

        private void SetFile_Click(object sender, EventArgs e) {
            spclient.AddFileToPlayList("D:\\GitHub\\SyncPlayWPF\\BackendCode\\BackendCode\\bin\\Debug\\DoYouLoveMe.mp4");
        }

        private void Ready_Click(object sender, EventArgs e) {
            spclient.SetReadyState(true);
        }

        private void NotReady_Click(object sender, EventArgs e) {
            spclient.SetReadyState(false);
        }

        private void Pause_Click(object sender, EventArgs e) {
            spclient.SetPause(true);
        }
        private void Play_Click(object sender, EventArgs e) {
            spclient.SetPause(false);

            if (!SyncThreadStarted) {
                SyncThreadStarted = true;
                var recieveThread = new Thread(SyncPlayPositionLoop);
                recieveThread.Start();
            }
        }

        private void MoveBackTenSeconds_Click(object sender, EventArgs e) {
            spclient.SetPlayPosition(spclient.GetPlayPosition() - 10);
        }

        private void MoveForwardTenSeconds_Click(object sender, EventArgs e) {
            spclient.SetPlayPosition(spclient.GetPlayPosition() + 10);
        }

        public void SyncPlayPositionLoop() {
            while (true) {
                if (!spclient.GetPause()) {
                    
                    spclient.TimerSetPosition(spclient.GetPlayPosition() + 1);
                }

                var ts = TimeSpan.FromSeconds(spclient.GetPlayPosition());

                var total_mins = (int)ts.TotalMinutes;
                var total_secs = ts.TotalSeconds - ((int)(ts.TotalMinutes % 60) * 60);

                SetPlayerPositionText($"{total_mins}:{total_secs}");
                Thread.Sleep(1000);
            }
        }

        delegate void SetTextCallback(string text);
        private void SetPlayerPositionText(string text) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.PlayerPositionBox.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetPlayerPositionText);
                this.Invoke(d, new object[] { text });
            } else {
                this.PlayerPositionBox.Text = text;
            }
        }


    }
}
