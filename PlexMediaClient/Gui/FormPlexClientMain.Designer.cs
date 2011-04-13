namespace PlexMediaClient.Gui {
    partial class FormPlexClientMain {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlexClientMain));
            this.MenuPane = new System.Windows.Forms.DataGridView();
            this.propertyGridDetails = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pictureBoxArtWork = new System.Windows.Forms.PictureBox();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMenuItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPane)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArtWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMenuItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPane
            // 
            this.MenuPane.AllowUserToAddRows = false;
            this.MenuPane.AllowUserToDeleteRows = false;
            this.MenuPane.AllowUserToResizeColumns = false;
            this.MenuPane.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkOrange;
            this.MenuPane.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MenuPane.AutoGenerateColumns = false;
            this.MenuPane.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.MenuPane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MenuPane.ColumnHeadersVisible = false;
            this.MenuPane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iconDataGridViewImageColumn,
            this.titleDataGridViewTextBoxColumn});
            this.MenuPane.DataSource = this.iMenuItemBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MenuPane.DefaultCellStyle = dataGridViewCellStyle3;
            this.MenuPane.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPane.GridColor = System.Drawing.Color.Black;
            this.MenuPane.Location = new System.Drawing.Point(0, 0);
            this.MenuPane.MultiSelect = false;
            this.MenuPane.Name = "MenuPane";
            this.MenuPane.ReadOnly = true;
            this.MenuPane.RowHeadersVisible = false;
            this.MenuPane.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MenuPane.RowTemplate.Height = 75;
            this.MenuPane.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MenuPane.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MenuPane.Size = new System.Drawing.Size(300, 768);
            this.MenuPane.TabIndex = 4;
            this.MenuPane.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.menuPane_CellDoubleClick);
            this.MenuPane.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.MenuPane_CellPainting);
            this.MenuPane.SelectionChanged += new System.EventHandler(this.menuPane_SelectionChanged);
            // 
            // propertyGridDetails
            // 
            this.propertyGridDetails.CategoryForeColor = System.Drawing.Color.DarkOrange;
            this.propertyGridDetails.CommandsForeColor = System.Drawing.Color.DarkOrange;
            this.propertyGridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridDetails.HelpVisible = false;
            this.propertyGridDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.propertyGridDetails.LineColor = System.Drawing.Color.Black;
            this.propertyGridDetails.Location = new System.Drawing.Point(0, 619);
            this.propertyGridDetails.Margin = new System.Windows.Forms.Padding(0);
            this.propertyGridDetails.Name = "propertyGridDetails";
            this.propertyGridDetails.Size = new System.Drawing.Size(724, 149);
            this.propertyGridDetails.TabIndex = 0;
            this.propertyGridDetails.ToolbarVisible = false;
            this.propertyGridDetails.ViewBackColor = System.Drawing.Color.Black;
            this.propertyGridDetails.ViewForeColor = System.Drawing.Color.DarkOrange;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.propertyGridDetails, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(300, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.59896F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.40104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 768);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axVLCPlugin21);
            this.panel1.Controls.Add(this.pictureBoxArtWork);
            this.panel1.Controls.Add(this.axWindowsMediaPlayer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 613);
            this.panel1.TabIndex = 1;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(718, 613);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            this.axWindowsMediaPlayer1.DoubleClickEvent += new AxWMPLib._WMPOCXEvents_DoubleClickEventHandler(this.axWindowsMediaPlayer1_DoubleClickEvent);
            // 
            // pictureBoxArtWork
            // 
            this.pictureBoxArtWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxArtWork.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArtWork.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxArtWork.Name = "pictureBoxArtWork";
            this.pictureBoxArtWork.Size = new System.Drawing.Size(718, 613);
            this.pictureBoxArtWork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxArtWork.TabIndex = 7;
            this.pictureBoxArtWork.TabStop = false;
            // 
            // iconDataGridViewImageColumn
            // 
            this.iconDataGridViewImageColumn.DataPropertyName = "Icon";
            this.iconDataGridViewImageColumn.HeaderText = "Icon";
            this.iconDataGridViewImageColumn.Image = global::PlexMediaClient.Properties.Resources.icon_empty_artwork;
            this.iconDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.iconDataGridViewImageColumn.MinimumWidth = 75;
            this.iconDataGridViewImageColumn.Name = "iconDataGridViewImageColumn";
            this.iconDataGridViewImageColumn.ReadOnly = true;
            this.iconDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.iconDataGridViewImageColumn.Width = 75;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.titleDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMenuItemBindingSource
            // 
            this.iMenuItemBindingSource.DataSource = typeof(PlexMediaClient.Gui.IMenuItem);
            // 
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(73, 534);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(320, 240);
            this.axVLCPlugin21.TabIndex = 9;
            // 
            // FormPlexClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MenuPane);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(300, 34);
            this.Name = "FormPlexClientMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MenuPane)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArtWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMenuItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource iMenuItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridView MenuPane;
        private System.Windows.Forms.PropertyGrid propertyGridDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxArtWork;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;

    }
}

