
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

namespace PlexMediaClient.Gui {
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
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.UserPaint |
                        ControlStyles.AllPaintingInWmPaint, true);
            MenuNavigation.OnItemsFetched += new MenuNavigation.OnItemsFetchedEventHandler(Navigation_OnItemsFetched);
            MenuNavigation.OnItemsFetchProgress += new MenuNavigation.OnItemsFetchProgressEventHandler(Navigation_OnItemsFetchProgress);
            MenuNavigation.OnErrorOccured += new MenuNavigation.OnErrorOccuredEventHandler(Navigation_OnErrorOccured);
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
            //Cursor = Cursors.WaitCursor;           
            listItemBindingSource.Add(new ListItem());
            listItemBindingSource.Add(new ListItem());
            listItemBindingSource.Add(new ListItem());
            listItemBindingSource.Add(new ListItem());
            listItemBindingSource.Add(new ListItem());
            listItemBindingSource.Add(new ListItem());
            listItemBindingSource.Add(new ListItem());
            this.Size = new Size(this.Size.Width,Screen.PrimaryScreen.WorkingArea.Height);
           
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
            MenuNavigation.FetchItems(((List<ListItem>)listItemBindingSource.DataSource)[e.RowIndex]);
        }
                
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Up:
                case Keys.Down:
                    dataGridView1.Select();
                    return base.ProcessCmdKey(ref msg, keyData);       
                    
                case Keys.Enter:
                case Keys.MediaPlayPause:
                case Keys.Play:
                    if (PlexInterface.IsBusy || !PlexInterface.IsConnected) {
                        break;
                    }
                    if (dataGridView1.SelectedRows != null) {
                        MenuNavigation.FetchItems(((List<ListItem>)listItemBindingSource.DataSource)[dataGridView1.SelectedRows[0].Index]);
                    }
                    break;
                case Keys.Back:
                case Keys.BrowserBack:
                case Keys.Escape:
                    MenuNavigation.GetPrevious();
                    break;
                case Keys.Alt | Keys.F4:
                    this.Close();
                    Application.Exit();
                    break;
                case Keys.F11:
                    ToggleFullScreen();
                    return true;
                    break;
                default:                    
                    break;
            }
            return true;
        }

        
        private void ToggleFullScreen() {           
            switch (WindowState) {
                case FormWindowState.Maximized:                   
                    WindowState = FormWindowState.Normal;                    
                    break;
                case FormWindowState.Minimized:
                case FormWindowState.Normal:
                default:
                    WindowState = FormWindowState.Maximized;
                    break;
            }            
        }

        private void FormPlexClientMain_SizeChanged(object sender, EventArgs e) {
                switch (WindowState) {
                case FormWindowState.Maximized:
                    splitContainerInner.Panel2Collapsed = false;
                    break;
                case FormWindowState.Minimized:
                case FormWindowState.Normal:                
                default:
                    splitContainerInner.Panel2Collapsed = true;
                    break;
            }
            
        }

    }
}