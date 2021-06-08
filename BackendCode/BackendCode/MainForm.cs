using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackendCode {
    public partial class MainForm : Form {


        SyncPlay.Client spclient;


        public MainForm() {
            InitializeComponent();

            spclient = new SyncPlay.Client("127.0.0.1", 5005, "Sammy", "", "ck", "1.2.7");
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

        }
    }
}
