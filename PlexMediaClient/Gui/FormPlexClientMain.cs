
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PlexMediaClient.Plex;
using PlexMediaClient.Util;


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
            pictureBoxArtWork.BorderStyle = BorderStyle.None;
            MenuPane.MouseWheel += new MouseEventHandler(MenuPane_MouseWheel);
            MenuNavigation.OnClose += new MenuNavigation.OnCloseEventHandler(MenuNavigation_OnClose);
            MenuNavigation.OnMenuItemsFetched += new MenuNavigation.OnMenuItemsFetchedEventHandler(Navigation_OnItemsFetched);
            MenuNavigation.OnErrorOccured += new MenuNavigation.OnErrorOccuredEventHandler(Navigation_OnErrorOccured);
            MediaRetrieval.OnArtWorkRetrieved += new MediaRetrieval.OnArtWorkRetrievedEventHandler(ArtWorkRetrieval_OnArtWorkRetrieved);
            MediaRetrieval.OnShowLargeArtWork += new MediaRetrieval.OnShowLargeArtWorkEventHandler(ArtWorkRetrieval_OnShowLargeArtWork);
            MediaRetrieval.OnDetailsRetrieved += new MediaRetrieval.OnDetailsRetrievedEventHandler(DetailsRetrieval_OnDetailsRetrieved);
            MediaRetrieval.OnPlayListRetrieved += new MediaRetrieval.OnPlayListRetrievedEventHandler(MediaRetrieval_OnPlayListRetrieved);

        }

        void MediaRetrieval_OnPlayListRetrieved(object playList) {
            throw new NotImplementedException();
        }

        void MenuPane_MouseWheel(object sender, MouseEventArgs e) {
            try {
                if (e.Delta > 0) {
                    MenuPane.Rows[MenuPane.SelectedRows[0].Index - 1].Selected = true;
                } else {
                    MenuPane.Rows[MenuPane.SelectedRows[0].Index + 1].Selected = true;
                }
            } catch {
            }
        }



        void MenuNavigation_OnClose(string reason) {
            Close();
        }

        private IMenuItem SelectedMenuItem { get; set; }

        void ArtWorkRetrieval_OnArtWorkRetrieved() {            
            this.Invoke(new MethodInvoker(delegate() {
                MenuPane.SuspendLayout();
                MenuPane.InvalidateColumn(iconDataGridViewImageColumn.Index);
                pictureBoxArtWork.Invalidate();
                Update();
                MenuPane.ResumeLayout();
            }));
        }

        void ArtWorkRetrieval_OnShowLargeArtWork(Image largeArtWork) {
            this.Invoke(new MethodInvoker(delegate() {
                pictureBoxArtWork.SuspendLayout();
                pictureBoxArtWork.Image = largeArtWork;
                pictureBoxArtWork.Show();
                pictureBoxArtWork.ResumeLayout();
            }));
        }

        void DetailsRetrieval_OnDetailsRetrieved(object infoObject) {
            this.Invoke(new MethodInvoker(delegate() {
                propertyGridDetails.SuspendLayout();
                propertyGridDetails.SelectedObject = infoObject;
                propertyGridDetails.ResumeLayout();
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
            Rectangle workingArea = Screen.GetWorkingArea(this);
            workingArea.Width = 300;
            Bounds = workingArea;
            if (MenuNavigation.CreateStartupMenu()) {
                base.OnLoad(e);
            } else if (ShowErrorMessage("Unable to start PlexMediaCenter - Please check network connection...") == DialogResult.Retry) {
                MenuNavigation.RefreshServerMenu();
                Thread.Sleep(500);
                OnLoad(e);
            } else {
                this.Close();
            }
        }

        private DialogResult ShowErrorMessage(string errorMessage) {
            return MessageBox.Show(errorMessage, "PlexMediaClient - Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }



        private void menuPane_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (PlexInterface.IsBusy) {
                return;
            }
            menuPane_SelectionChanged(sender, e);
            mediaPLayer.BaseURL = ServerManager.Instance.PlexServerCurrent.UriPlexBase.AbsoluteUri;
            mediaPLayer.play += new EventHandler(mediaPLayer_play);
            mediaPLayer.MediaPlayerEncounteredError += new EventHandler(mediaPLayer_MediaPlayerEncounteredError);
            mediaPLayer.MediaPlayerPlaying += new EventHandler(mediaPLayer_MediaPlayerPlaying);
            if (SelectedMenuItem is PlexItemVideo) {
                try {
                    string t = Transcoding.GetM3U8Playlist(ServerManager.Instance.PlexServerCurrent, ((PlexItemVideo)SelectedMenuItem).Video.Media[0].Part[0].key);
                    mediaPLayer.playlist.add(t);
                    mediaPLayer.playlist.play();
                } catch {

                }
            }
            SelectedMenuItem.OnClicked(sender, e);

            //MenuNavigation.FetchItems(((List<ListItem>)listItemBindingSource.DataSource)[e.RowIndex]);
        }

        void mediaPLayer_MediaPlayerEncounteredError(object sender, EventArgs e) {
            
        }

        void mediaPLayer_MediaPlayerPlaying(object sender, EventArgs e) {
            
        }

        void mediaPLayer_play(object sender, EventArgs e) {
            
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
                    MenuNavigation.FetchPreviousMenu(SelectedMenuItem.Parent);
                    MenuPane.ClearSelection();
                    SelectedMenuItem = null;
                    break;
                case Keys.Alt | Keys.F4:
                    this.Close();
                    break;
                case Keys.Right:
                    Expand();
                    break;
                case Keys.Left:
                    Shrink();
                    break;
                default:
                    break;
            }
            return true;
        }


        private void Shrink() {
            Rectangle rec = Screen.GetWorkingArea(this);
            while (rec.Width > 300) {
                rec.Width -= 5;
                Bounds = rec;
            }
        }

        private void Expand() {
            int maxWidth = Screen.GetWorkingArea(this).Width;
            Rectangle bounds = Bounds;
            while (bounds.Width < maxWidth) {
                bounds.Width += 5;
                Bounds = bounds;
            }
        }

        private void menuPane_SelectionChanged(object sender, EventArgs e) {
            try {
                SelectedMenuItem = ((List<IMenuItem>)iMenuItemBindingSource.DataSource)[MenuPane.SelectedRows[0].Index];
                SelectedMenuItem.OnSelected();
            } catch { }
        }

        private void MenuPane_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.ColumnIndex == titleDataGridViewTextBoxColumn.Index) {
                ((List<IMenuItem>)iMenuItemBindingSource.DataSource)[e.RowIndex].OnPaint(sender, e);
            }
        }
    }
}