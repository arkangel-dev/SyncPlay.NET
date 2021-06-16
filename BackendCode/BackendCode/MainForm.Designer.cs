namespace BackendCode {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DebugWindow = new System.Windows.Forms.RichTextBox();
            this.ChatWindow = new System.Windows.Forms.RichTextBox();
            this.UserList = new System.Windows.Forms.ListBox();
            this.MoveForwardTenSeconds = new System.Windows.Forms.Button();
            this.MoveBackTenSeconds = new System.Windows.Forms.Button();
            this.PlayerPositionBox = new System.Windows.Forms.TextBox();
            this.Play = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.NotReady = new System.Windows.Forms.Button();
            this.Ready = new System.Windows.Forms.Button();
            this.SetFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.VLCStartServer = new System.Windows.Forms.Button();
            this.VLCLoadFile = new System.Windows.Forms.Button();
            this.VLCPause = new System.Windows.Forms.Button();
            this.VLCPlay = new System.Windows.Forms.Button();
            this.VLCServerOutput = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(895, 551);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(887, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Syncplay";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DebugWindow);
            this.groupBox1.Controls.Add(this.ChatWindow);
            this.groupBox1.Controls.Add(this.UserList);
            this.groupBox1.Controls.Add(this.MoveForwardTenSeconds);
            this.groupBox1.Controls.Add(this.MoveBackTenSeconds);
            this.groupBox1.Controls.Add(this.PlayerPositionBox);
            this.groupBox1.Controls.Add(this.Play);
            this.groupBox1.Controls.Add(this.Pause);
            this.groupBox1.Controls.Add(this.NotReady);
            this.groupBox1.Controls.Add(this.Ready);
            this.groupBox1.Controls.Add(this.SetFile);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 511);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SyncPlayTestUI";
            // 
            // DebugWindow
            // 
            this.DebugWindow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DebugWindow.Location = new System.Drawing.Point(311, 257);
            this.DebugWindow.Name = "DebugWindow";
            this.DebugWindow.Size = new System.Drawing.Size(556, 195);
            this.DebugWindow.TabIndex = 35;
            this.DebugWindow.Text = "";
            // 
            // ChatWindow
            // 
            this.ChatWindow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChatWindow.Location = new System.Drawing.Point(311, 32);
            this.ChatWindow.Name = "ChatWindow";
            this.ChatWindow.Size = new System.Drawing.Size(556, 219);
            this.ChatWindow.TabIndex = 34;
            this.ChatWindow.Text = "";
            // 
            // UserList
            // 
            this.UserList.FormattingEnabled = true;
            this.UserList.ItemHeight = 16;
            this.UserList.Location = new System.Drawing.Point(148, 32);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(157, 420);
            this.UserList.TabIndex = 33;
            // 
            // MoveForwardTenSeconds
            // 
            this.MoveForwardTenSeconds.Location = new System.Drawing.Point(311, 466);
            this.MoveForwardTenSeconds.Name = "MoveForwardTenSeconds";
            this.MoveForwardTenSeconds.Size = new System.Drawing.Size(124, 31);
            this.MoveForwardTenSeconds.TabIndex = 32;
            this.MoveForwardTenSeconds.Text = "+ 10 Seconds";
            this.MoveForwardTenSeconds.UseVisualStyleBackColor = true;
            // 
            // MoveBackTenSeconds
            // 
            this.MoveBackTenSeconds.Location = new System.Drawing.Point(18, 466);
            this.MoveBackTenSeconds.Name = "MoveBackTenSeconds";
            this.MoveBackTenSeconds.Size = new System.Drawing.Size(124, 31);
            this.MoveBackTenSeconds.TabIndex = 31;
            this.MoveBackTenSeconds.Text = "- 10 Seconds";
            this.MoveBackTenSeconds.UseVisualStyleBackColor = true;
            // 
            // PlayerPositionBox
            // 
            this.PlayerPositionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerPositionBox.Location = new System.Drawing.Point(148, 468);
            this.PlayerPositionBox.Name = "PlayerPositionBox";
            this.PlayerPositionBox.Size = new System.Drawing.Size(157, 28);
            this.PlayerPositionBox.TabIndex = 30;
            this.PlayerPositionBox.Text = "00";
            this.PlayerPositionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(18, 217);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(124, 34);
            this.Play.TabIndex = 29;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(18, 177);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(124, 34);
            this.Pause.TabIndex = 28;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            // 
            // NotReady
            // 
            this.NotReady.Location = new System.Drawing.Point(18, 112);
            this.NotReady.Name = "NotReady";
            this.NotReady.Size = new System.Drawing.Size(124, 34);
            this.NotReady.TabIndex = 27;
            this.NotReady.Text = "Not Ready";
            this.NotReady.UseVisualStyleBackColor = true;
            // 
            // Ready
            // 
            this.Ready.Location = new System.Drawing.Point(18, 72);
            this.Ready.Name = "Ready";
            this.Ready.Size = new System.Drawing.Size(124, 34);
            this.Ready.TabIndex = 26;
            this.Ready.Text = "Ready";
            this.Ready.UseVisualStyleBackColor = true;
            // 
            // SetFile
            // 
            this.SetFile.Location = new System.Drawing.Point(18, 32);
            this.SetFile.Name = "SetFile";
            this.SetFile.Size = new System.Drawing.Size(124, 34);
            this.SetFile.TabIndex = 25;
            this.SetFile.Text = "Set File";
            this.SetFile.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(887, 522);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "VLC";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.VLCStartServer);
            this.panel1.Controls.Add(this.VLCLoadFile);
            this.panel1.Controls.Add(this.VLCPause);
            this.panel1.Controls.Add(this.VLCPlay);
            this.panel1.Controls.Add(this.VLCServerOutput);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 510);
            this.panel1.TabIndex = 0;
            // 
            // VLCStartServer
            // 
            this.VLCStartServer.Location = new System.Drawing.Point(3, 182);
            this.VLCStartServer.Name = "VLCStartServer";
            this.VLCStartServer.Size = new System.Drawing.Size(103, 29);
            this.VLCStartServer.TabIndex = 5;
            this.VLCStartServer.Text = "Start Server";
            this.VLCStartServer.UseVisualStyleBackColor = true;
            this.VLCStartServer.Click += new System.EventHandler(this.VLCStartServer_Click);
            // 
            // VLCLoadFile
            // 
            this.VLCLoadFile.Location = new System.Drawing.Point(221, 3);
            this.VLCLoadFile.Name = "VLCLoadFile";
            this.VLCLoadFile.Size = new System.Drawing.Size(103, 29);
            this.VLCLoadFile.TabIndex = 4;
            this.VLCLoadFile.Text = "Load file";
            this.VLCLoadFile.UseVisualStyleBackColor = true;
            // 
            // VLCPause
            // 
            this.VLCPause.Location = new System.Drawing.Point(112, 3);
            this.VLCPause.Name = "VLCPause";
            this.VLCPause.Size = new System.Drawing.Size(103, 29);
            this.VLCPause.TabIndex = 2;
            this.VLCPause.Text = "Pause";
            this.VLCPause.UseVisualStyleBackColor = true;
            this.VLCPause.Click += new System.EventHandler(this.VLCPause_Click);
            // 
            // VLCPlay
            // 
            this.VLCPlay.Location = new System.Drawing.Point(3, 3);
            this.VLCPlay.Name = "VLCPlay";
            this.VLCPlay.Size = new System.Drawing.Size(103, 29);
            this.VLCPlay.TabIndex = 1;
            this.VLCPlay.Text = "Play";
            this.VLCPlay.UseVisualStyleBackColor = true;
            this.VLCPlay.Click += new System.EventHandler(this.VLCPlay_Click);
            // 
            // VLCServerOutput
            // 
            this.VLCServerOutput.Location = new System.Drawing.Point(3, 217);
            this.VLCServerOutput.Name = "VLCServerOutput";
            this.VLCServerOutput.Size = new System.Drawing.Size(869, 290);
            this.VLCServerOutput.TabIndex = 0;
            this.VLCServerOutput.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 563);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox DebugWindow;
        private System.Windows.Forms.RichTextBox ChatWindow;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Button MoveForwardTenSeconds;
        private System.Windows.Forms.Button MoveBackTenSeconds;
        private System.Windows.Forms.TextBox PlayerPositionBox;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button NotReady;
        private System.Windows.Forms.Button Ready;
        private System.Windows.Forms.Button SetFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button VLCPause;
        private System.Windows.Forms.Button VLCPlay;
        private System.Windows.Forms.RichTextBox VLCServerOutput;
        private System.Windows.Forms.Button VLCLoadFile;
        private System.Windows.Forms.Button VLCStartServer;
    }
}