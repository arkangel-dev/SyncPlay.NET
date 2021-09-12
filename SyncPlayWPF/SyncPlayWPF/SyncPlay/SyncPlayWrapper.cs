﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPlayWPF.SyncPlay {
    public class SyncPlayWrapper {
        public SyncPlayClient SyncPlayClient;
        public MediaPlayerInterface Player;
        public int RemoteSeekOffset = 1;

        public SyncPlayWrapper(string serverip, int port, string username, string password, string room, MediaPlayerInterface mp) {
            this.SyncPlayClient = new SyncPlayClient(serverip, port, username, password, room, "1.6.8");

            this.Player = mp;


            this.SyncPlayClient.OnPlayerStateChange += PlayerStateChanged;
            this.SyncPlayClient.OnConnect += SyncPlayClient_OnConnect;
            this.SyncPlayClient.OnDisconnect += SyncPlayClient_OnDisconnect;
            this.SyncPlayClient.OnNewChatMessage += SyncPlayClient_OnNewChatMessage;
        }

        private void SyncPlayClient_OnNewChatMessage(SyncPlayClient sender, SPEventArgs.ChatMessageEventArgs e) {
            //if (!e.LocallySentMessage)
            //    this.Player.DisplayOSDMessage(e.Sender.Username + " : " + e.Message);
        }

        private void SyncPlayClient_OnDisconnect(SyncPlayClient sender, SPEventArgs.ServerDisconnectedEventArgs e) {
            Console.WriteLine(e.ReasonForDisconnection);
            Console.WriteLine(e.ServerKicked);
        }

        private void SyncPlayClient_OnConnect(SyncPlayClient sender, SPEventArgs.ServerConnectedEventArgs e) {
            this.Player.OnSeek += SyncPlayClient.SetPlayPosition;
            this.Player.OnPauseStateChange += SyncPlayClient.SetPause;
            this.Player.OnNewFileLoad += NewFileLoad;
            if (!this.Player.StartPlayerInstance()) {
                Console.WriteLine("Start player instance failed at wrapper");
                this.OnConnectonFailure?.Invoke(this);
                return;
            }
            this.OnConnectionSuccess?.Invoke(this);
        }



        private void NewFileLoad(SPEventArgs.NewFileLoadEventArgs e) {
            SyncPlayClient.AddFileToPlayList(e.AbsoluteFilePath);
        }

        private void PlayerStateChanged(SyncPlayClient sender, SPEventArgs.RemoteStateChangeEventArgs e) {
            Player.SetPauseState(e.Paused);
            Player.SetPosition(e.Position + RemoteSeekOffset);
        }

        public void Dispose() {
            if (Player != null) {
                Player.ClosePlayer();
                Player = null;
            }

            if (SyncPlayClient != null) {
                SyncPlayClient.Dispose();
                SyncPlayClient = null;
            }
        }

        public event ConnectionFailed OnConnectonFailure;
        public delegate void ConnectionFailed(SyncPlayWrapper sender);

        public event ConnectionSuccess OnConnectionSuccess;
        public delegate void ConnectionSuccess(SyncPlayWrapper sender);

    }
}
