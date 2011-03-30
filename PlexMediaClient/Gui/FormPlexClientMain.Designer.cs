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
            this.splitContainerInner = new System.Windows.Forms.SplitContainer();
            this.MenuPane = new System.Windows.Forms.DataGridView();
            this.iMenuItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInner)).BeginInit();
            this.splitContainerInner.Panel1.SuspendLayout();
            this.splitContainerInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMenuItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerInner
            // 
            this.splitContainerInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInner.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerInner.IsSplitterFixed = true;
            this.splitContainerInner.Location = new System.Drawing.Point(0, 0);
            this.splitContainerInner.Name = "splitContainerInner";
            // 
            // splitContainerInner.Panel1
            // 
            this.splitContainerInner.Panel1.Controls.Add(this.MenuPane);
            this.splitContainerInner.Panel2Collapsed = true;
            this.splitContainerInner.Size = new System.Drawing.Size(300, 768);
            this.splitContainerInner.SplitterDistance = 275;
            this.splitContainerInner.TabIndex = 5;
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
            this.MenuPane.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.MenuPane.SelectionChanged += new System.EventHandler(this.menuPane_SelectionChanged);
            // 
            // iMenuItemBindingSource
            // 
            this.iMenuItemBindingSource.DataSource = typeof(PlexMediaClient.Gui.IMenuItem);
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
            this.titleDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormPlexClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(300, 768);
            this.Controls.Add(this.splitContainerInner);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(300, 766);
            this.Name = "FormPlexClientMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.FormPlexClientMain_SizeChanged);
            this.splitContainerInner.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInner)).EndInit();
            this.splitContainerInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MenuPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMenuItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerInner;
        private System.Windows.Forms.DataGridView MenuPane;
        private System.Windows.Forms.BindingSource iMenuItemBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;

    }
}

