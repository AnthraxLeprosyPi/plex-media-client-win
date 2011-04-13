
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
            Transcoding.OnMediaReady += new Transcoding.OnMediaReadyEventHandler(Transcoding_OnMediaBuffered);
            axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayer1_PlayStateChange);
            axWindowsMediaPlayer1.ErrorEvent += new EventHandler(axWindowsMediaPlayer1_ErrorEvent);
            axWindowsMediaPlayer1.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(axWindowsMediaPlayer1_MediaError);           
        }       

        void axWindowsMediaPlayer1_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e) {
            WMPLib.IWMPMedia2 errSource = e.pMediaObject as WMPLib.IWMPMedia2;
            WMPLib.IWMPErrorItem errorItem = errSource.Error;
            MessageBox.Show("Error " + errorItem.errorCode.ToString("X")
                            + " in " + errSource.sourceURL);
            throw new NotImplementedException();
        }

        void axWindowsMediaPlayer1_ErrorEvent(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e) {
            switch ((WMPLib.WMPPlayState)e.newState) {
                case WMPLib.WMPPlayState.wmppsBuffering:
                    break;
                case WMPLib.WMPPlayState.wmppsLast:
                    break;
                case WMPLib.WMPPlayState.wmppsMediaEnded:
                    this.Invoke(new MethodInvoker(delegate() {
                        this.axWindowsMediaPlayer1.SendToBack();
                        this.pictureBoxArtWork.BringToFront();
                    }));
                    break;
                case WMPLib.WMPPlayState.wmppsPaused:
                    break;
                case WMPLib.WMPPlayState.wmppsPlaying:
                    this.Invoke(new MethodInvoker(delegate() {
                        this.pictureBoxArtWork.SendToBack();
                        this.axWindowsMediaPlayer1.BringToFront();
                    }));
                    break;
                case WMPLib.WMPPlayState.wmppsReady:
                    break;
                case WMPLib.WMPPlayState.wmppsReconnecting:
                    break;
                case WMPLib.WMPPlayState.wmppsScanForward:
                    break;
                case WMPLib.WMPPlayState.wmppsScanReverse:
                    break;
                case WMPLib.WMPPlayState.wmppsStopped:
                    this.Invoke(new MethodInvoker(delegate() {
                        this.axWindowsMediaPlayer1.SendToBack();
                        this.pictureBoxArtWork.BringToFront();
                    }));
                    break;
                case WMPLib.WMPPlayState.wmppsTransitioning:
                    break;
                case WMPLib.WMPPlayState.wmppsUndefined:
                    break;
                case WMPLib.WMPPlayState.wmppsWaiting:
                    break;
                default:
                    break;
            }
        }


        void Transcoding_OnMediaBuffered(List<string> playList) {
            this.Invoke(new MethodInvoker(delegate() {
                axWindowsMediaPlayer1.currentPlaylist.clear();
                playList.ForEach(url => axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(url)));
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }));
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
            SelectedMenuItem.OnClicked(sender, e);
        }

        void axWindowsMediaPlayer1_Buffering(object sender, AxWMPLib._WMPOCXEvents_BufferingEvent e) {

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
                    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                        axWindowsMediaPlayer1.Ctlcontrols.pause();
                    } else {
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    break;
                case Keys.Play:
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    break;
                case Keys.MediaNextTrack:
                    axWindowsMediaPlayer1.Ctlcontrols.next();
                    break;
                case Keys.MediaPreviousTrack:
                    axWindowsMediaPlayer1.Ctlcontrols.previous();
                    break;
                case Keys.MediaStop:
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    Transcoding.StopBuffering();
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
                rec.Width -= 50;
                Bounds = rec;
            }
        }

        private void Expand() {
            int maxWidth = Screen.GetWorkingArea(this).Width;
            Rectangle bounds = Bounds;
            while (bounds.Width < maxWidth) {
                bounds.Width += 50;
                Bounds = bounds;
            }
        }

        private void menuPane_SelectionChanged(object sender, EventArgs e) {
            try {

                pictureBoxArtWork.BringToFront();
                axWindowsMediaPlayer1.SendToBack();
                SelectedMenuItem = ((List<IMenuItem>)iMenuItemBindingSource.DataSource)[MenuPane.SelectedRows[0].Index];
                pictureBoxArtWork.Image = SelectedMenuItem.ArtWork;                
                propertyGridDetails.SelectedObject = SelectedMenuItem.Details;
                //SuspendLayout();
                pictureBoxArtWork.Invalidate();
                propertyGridDetails.Invalidate();
                Update();
                //ResumeLayout();
                if (SelectedMenuItem is PlexItemVideo) {
                    Expand();
                }
                SelectedMenuItem.OnSelected();
            } catch { 
            }
        }

        private void MenuPane_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.ColumnIndex == titleDataGridViewTextBoxColumn.Index) {
                ((List<IMenuItem>)iMenuItemBindingSource.DataSource)[e.RowIndex].OnPaint(sender, e);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            Transcoding.StopBuffering();
            base.OnClosing(e);
        }

        private void axWindowsMediaPlayer1_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e) {
            try {
                axWindowsMediaPlayer1.fullScreen = !axWindowsMediaPlayer1.fullScreen;
            } catch { }
        }
    }
}