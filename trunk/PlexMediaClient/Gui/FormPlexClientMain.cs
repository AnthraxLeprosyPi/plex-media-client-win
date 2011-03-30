
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
            MenuNavigation.OnClose += new MenuNavigation.OnCloseEventHandler(MenuNavigation_OnClose);
            MenuNavigation.OnMenuItemsFetched += new MenuNavigation.OnMenuItemsFetchedEventHandler(Navigation_OnItemsFetched);
            MenuNavigation.OnErrorOccured += new MenuNavigation.OnErrorOccuredEventHandler(Navigation_OnErrorOccured);
            ArtWorkRetrieval.OnArtWorkRetrieved += new ArtWorkRetrieval.OnArtWorkRetrievedEventHandler(ArtWorkRetrieval_OnArtWorkRetrieved);
        }

        void MenuNavigation_OnClose(string reason) {
            Close();
        }

        private IMenuItem SelectedMenuItem { get; set; }

        void ArtWorkRetrieval_OnArtWorkRetrieved() {
            this.Invoke(new MethodInvoker(delegate() {
                MenuPane.SuspendLayout();
                MenuPane.InvalidateColumn(iconDataGridViewImageColumn.Index);
                MenuPane.ResumeLayout();
                Update();
            }));
        }

        void Navigation_OnErrorOccured(Exception e) {
            Cursor = Cursors.Default;
            this.Invoke(new MethodInvoker(delegate() { MessageBox.Show(e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); }));
        }

        void Navigation_OnItemsFetched(List<IMenuItem> fetchedItems) {
            Cursor = Cursors.Default;
            this.Invoke(new MethodInvoker(delegate() { iMenuItemBindingSource.DataSource = fetchedItems; iMenuItemBindingSource.ResetBindings(false); }));
        }

        protected override void OnLoad(EventArgs e) {
            //Cursor = Cursors.WaitCursor;                     
            this.Size = new Size(this.Size.Width, Screen.PrimaryScreen.WorkingArea.Height);
            // ServerManager.Instance.ToString();
            //PlexInterface.Login();
            if (PlexInterface.TryConnectLastServer()) {
                MenuNavigation.ShowMenuServerSections();
            } else if (PlexInterface.LoadAndDiscoverServers()) {
                MenuNavigation.ShowMenuServerSelection();
            } else if (ShowErrorMessage("Unable to start PlexMediaCenter - Please check network connection...") == DialogResult.Retry) {
                OnLoad(e);
            } else {
                this.Close();
            }

            base.OnLoad(e);
        }

        private DialogResult ShowErrorMessage(string errorMessage) {
            return MessageBox.Show(errorMessage, "PlexMediaClient - Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }



        private void menuPane_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (PlexInterface.IsBusy) {
                return;
            }
            SelectedMenuItem.OnClicked(sender, e);

            //MenuNavigation.FetchItems(((List<ListItem>)listItemBindingSource.DataSource)[e.RowIndex]);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Up:
                case Keys.Down:
                    if (!MenuPane.Focused) {
                        MenuPane.Select();                        
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case Keys.Enter:
                case Keys.Select:
                    if (SelectedMenuItem != null) {
                        SelectedMenuItem.OnClicked(null, null);
                    }
                    break;
                case Keys.MediaPlayPause:
                case Keys.Play:
                    //MediaPlayer.PlayItem();
                    break;
                case Keys.Back:
                case Keys.BrowserBack:
                case Keys.Escape:
                    MenuNavigation.FetchPreviousMenu();
                    break;
                case Keys.Alt | Keys.F4:
                    this.Close();
                    break;
                case Keys.F11:
                    ToggleFullScreen();
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

        private void menuPane_SelectionChanged(object sender, EventArgs e) {
            try {
                SelectedMenuItem = ((List<IMenuItem>)iMenuItemBindingSource.DataSource)[MenuPane.SelectedRows[0].Index];
            } catch { }
        }
    }
}