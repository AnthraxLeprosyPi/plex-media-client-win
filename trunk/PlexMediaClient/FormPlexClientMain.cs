
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using PlexMediaClient.Util;
using PlexMediaClient.Gui;
using PlexMediaClient.Plex.Xml;

namespace PlexMediaClient {
    public partial class FormPlexClientMain : Form {

        Image ImageConnectionState {
            get {
                return PlexInterface.IsConnected
                    ? Properties.Resources.icon_server_online
                    : Properties.Resources.icon_server_offline;
            }
        }

        public FormPlexClientMain() {
            InitializeComponent();
            Navigation.OnItemsFetched += new Navigation.OnItemsFetchedEventHandler(Navigation_OnItemsFetched);
            Navigation.OnItemsFetchProgress += new Navigation.OnItemsFetchProgressEventHandler(Navigation_OnItemsFetchProgress);
            Navigation.OnErrorOccured += new Navigation.OnErrorOccuredEventHandler(Navigation_OnErrorOccured);
            ArtWorkRetrieval.OnArtWorkRetrieved += new ArtWorkRetrieval.OnArtWorkRetrievedEventHandler(ArtWorkRetrieval_OnArtWorkRetrieved);
        }

        void ArtWorkRetrieval_OnArtWorkRetrieved() {
            this.Invoke(new MethodInvoker(delegate() {
                dataGridView1.SuspendLayout();
                dataGridView1.InvalidateColumn(ArtWork.Index);               
                dataGridView1.ResumeLayout();
                Update();
            }));
        }

        void Navigation_OnErrorOccured(Exception e) {
            Cursor = Cursors.Default;
            this.Invoke(new MethodInvoker(delegate() { MessageBox.Show(e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); }));
        }

        void Navigation_OnItemsFetchProgress(int progress) {
            this.Invoke(new MethodInvoker(delegate() { progressBarFetch.Value = progress; progressBarFetch.Invalidate(); Update(); }));
        }

        void Navigation_OnItemsFetched(List<ListItem> fetchedItems) {
            Cursor = Cursors.Default;
            this.Invoke(new MethodInvoker(delegate() { listItemBindingSource.DataSource = fetchedItems; listItemBindingSource.ResetBindings(false); }));
        }        

        protected override void OnLoad(EventArgs e) {
            Cursor = Cursors.WaitCursor;
            
            base.OnLoad(e);
        }        

        private void toolStripButtonExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void toolStripButton1_Paint(object sender, PaintEventArgs e) {
            this.toolStripLabel1.BackgroundImage = ImageConnectionState;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e) {
            if (!PlexInterface.IsConnected) {
                PlexInterface.Reconnect();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (PlexInterface.IsBusy) {
                return;
            }
            Navigation.FetchItems(((List<ListItem>)listItemBindingSource.DataSource)[e.RowIndex]);
        }

        private void FormPlexClientMain_KeyDown(object sender, KeyEventArgs e) {
            if (PlexInterface.IsBusy) {
                return;
            }
            switch (e.KeyCode) {
                case Keys.Enter:
                case Keys.MediaPlayPause:
                case Keys.Play:
                    if (dataGridView1.SelectedRows != null) {
                        Navigation.FetchItems(((List<ListItem>)listItemBindingSource.DataSource)[dataGridView1.SelectedRows[0].Index]);
                    }
                    break;
                case Keys.Back:
                case Keys.BrowserBack:
                case Keys.Escape:
                    Navigation.GetPrevious();
                    break;
                default:
                    break;
            }
        }

    }
}