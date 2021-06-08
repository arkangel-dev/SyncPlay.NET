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
            this.SetFile = new System.Windows.Forms.Button();
            this.Ready = new System.Windows.Forms.Button();
            this.NotReady = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetFile
            // 
            this.SetFile.Location = new System.Drawing.Point(12, 12);
            this.SetFile.Name = "SetFile";
            this.SetFile.Size = new System.Drawing.Size(124, 34);
            this.SetFile.TabIndex = 0;
            this.SetFile.Text = "Set File";
            this.SetFile.UseVisualStyleBackColor = true;
            this.SetFile.Click += new System.EventHandler(this.SetFile_Click);
            // 
            // Ready
            // 
            this.Ready.Location = new System.Drawing.Point(12, 52);
            this.Ready.Name = "Ready";
            this.Ready.Size = new System.Drawing.Size(124, 34);
            this.Ready.TabIndex = 1;
            this.Ready.Text = "Ready";
            this.Ready.UseVisualStyleBackColor = true;
            this.Ready.Click += new System.EventHandler(this.Ready_Click);
            // 
            // NotReady
            // 
            this.NotReady.Location = new System.Drawing.Point(12, 92);
            this.NotReady.Name = "NotReady";
            this.NotReady.Size = new System.Drawing.Size(124, 34);
            this.NotReady.TabIndex = 2;
            this.NotReady.Text = "Not Ready";
            this.NotReady.UseVisualStyleBackColor = true;
            this.NotReady.Click += new System.EventHandler(this.NotReady_Click);
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(12, 157);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(124, 34);
            this.Pause.TabIndex = 3;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(12, 197);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(124, 34);
            this.Play.TabIndex = 4;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 489);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.NotReady);
            this.Controls.Add(this.Ready);
            this.Controls.Add(this.SetFile);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetFile;
        private System.Windows.Forms.Button Ready;
        private System.Windows.Forms.Button NotReady;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Play;
    }
}