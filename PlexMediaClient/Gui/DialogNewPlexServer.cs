using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlexMediaClient.Plex;

namespace PlexMediaClient.Gui {
    public partial class DialogNewPlexServer : Form {
        public DialogNewPlexServer() {
            InitializeComponent();
        }

        public PlexServer NewServer { get; set; }

        private void buttonConnect_Click(object sender, EventArgs e) {
            PlexServer newServer = new PlexServer(String.IsNullOrEmpty(textBoxName.Text) ? textBoxHost.Text : textBoxName.Text, textBoxHost.Text, textBoxUser.Text, textBoxPass.Text);
            if (PlexInterface.Login(newServer)) {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                NewServer = newServer;
            } else {
                MessageBox.Show("Unable to connect to: " + newServer.UriPlexBase, "PlexMediaClient - Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                NewServer = null;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            NewServer = null;
            this.Close();
        }

        private void textBoxHost_TextChanged(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(textBoxHost.Text)) {
                this.buttonConnect.Enabled = true;
            } else {
                this.buttonConnect.Enabled = false;
            }
        }
    }
}
