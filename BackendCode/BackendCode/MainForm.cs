﻿using System;
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

            spclient = new SyncPlay.Client("127.0.0.1", 5005, "Sammy", "", "ck", "1.2.7", VLC);

            spclient.OnUserRoomEvent += NewUserJoined;
            spclient.OnNewChatMessage += NewChatMessage;
            spclient.OnDebugLog += DebugLogEvent;

        }

        private void DebugLogEvent(SyncPlay.Client sender, string message) {
            this.Invoke(new MethodInvoker(delegate () {
                DebugWindow.Text += message + "\n";
            }));
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
                SetPlayerPositionText(SyncPlay.Misc.Common.ConvertSecondsToTimeStamp((int)spclient.GetPlayPosition()));
                Thread.Sleep(1000);
            }
        }

        delegate void SetTextCallback(string text);
        private void SetPlayerPositionText(string text) {
            if (this.PlayerPositionBox.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetPlayerPositionText);
                this.Invoke(d, new object[] { text });
            } else {
                this.PlayerPositionBox.Text = text;
            }
        }


        #region VLC Player Interface Test
        SyncPlay.MediaPlayers.VLCMediaPlayer.Connector VLC = new SyncPlay.MediaPlayers.VLCMediaPlayer.Connector();

        private void VLCStartServer_Click(object sender, EventArgs e) {
            VLC.StartPlayerInstance();
            //VLC.OnVLCMessage += VLC_OnVLCMessage;
            VLC.OnPauseStateChange += VLC_OnPauseStateChange;
            VLC.OnSeek += VLC_OnSeek;
            VLC.OnDebugMessage += VLC_OnDebugMessage;
            
        }

        private void VLC_OnDebugMessage(string s) {
            WriteToUIConsole("[DEBUG] " + s);
        }

        private void VLC_OnSeek(float position) {
            WriteToUIConsole($"Player has seeked to the poition {position} seconds");
        }

        private void VLC_OnPauseStateChange(bool paused) {
            WriteToUIConsole(paused ? "Player Paused!" : "Player Played!");
        }



        private void WriteToUIConsole(string s) {
            this.Invoke(new MethodInvoker(() => {
                VLCServerOutput.Text += s + "\n";
                VLCServerOutput.SelectionStart = VLCServerOutput.Text.Length;
                VLCServerOutput.ScrollToCaret();

            }));
        }

        private void VLCPlay_Click(object sender, EventArgs e) {
            VLC.Play();
        }

        private void VLCPause_Click(object sender, EventArgs e) {
            VLC.Pause();
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e) {

        }
    }
}
