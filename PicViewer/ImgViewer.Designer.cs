namespace picViewer_NS
{
    partial class ImgViewer
    {
        /// Wymagana zmienna projektanta.

        private System.ComponentModel.IContainer components = null;

        /// Oczyść wszystkie używane zasoby.

        /// <param name = "disposing"> true, jeśli zasoby zarządzane powinny zostać usunięte; w przeciwnym razie false. </param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusBar = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dummyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ShrinkMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.StretchViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AutosizeViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CenterViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.resize = new System.Windows.Forms.Button();
            this.InfoTxt = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            /// 
            /// pasek stanu
            /// 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar.Location = new System.Drawing.Point(-2, 327);
            this.statusBar.Margin = new System.Windows.Forms.Padding(0);
            this.statusBar.Name = "statusBar";
            this.statusBar.ReadOnly = true;
            this.statusBar.Size = new System.Drawing.Size(311, 20);
            this.statusBar.TabIndex = 1;
            this.statusBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            /// 
            /// menuStrip
            /// 
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyMenu,
            this.FileMenuItem,
            this.ShrinkMenuBtn,
            this.viewMenu,
            this.CloseMenuBtn});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(360, 29);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseUp);
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseDown);
            this.menuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseMove);
            this.menuStrip.MouseHover += new System.EventHandler(this.menuStrip_MouseHover);
            this.menuStrip.MouseLeave += new System.EventHandler(this.menuStrip_MouseLeave);
            /// 
            /// dummyMenu
            /// 
            this.dummyMenu.AutoSize = false;
            this.dummyMenu.Enabled = false;
            this.dummyMenu.Name = "dummyMenu";
            this.dummyMenu.Size = new System.Drawing.Size(40, 25);
            /// 
            /// Plik
            /// 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuBtn,
            this.SaveAsMenuBtn});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(35, 25);
            this.FileMenuItem.Text = "Plik";
            /// 
            /// Otwórz
            /// 
            this.OpenMenuBtn.Name = "OpenMenuBtn";
            this.OpenMenuBtn.Size = new System.Drawing.Size(121, 22);
            this.OpenMenuBtn.Text = "Otwórz";
            this.OpenMenuBtn.Click += new System.EventHandler(this.openMenuBtn_Click);
            /// 
            /// SaveAsMenuBtn
            /// 
            this.SaveAsMenuBtn.Name = "SaveAsMenuBtn";
            this.SaveAsMenuBtn.Size = new System.Drawing.Size(121, 22);
            this.SaveAsMenuBtn.Text = "Zapisz";
            /// 
            /// skurcz
            /// 
            this.ShrinkMenuBtn.Name = "ShrinkMenuBtn";
            this.ShrinkMenuBtn.Size = new System.Drawing.Size(48, 25);
            this.ShrinkMenuBtn.Text = "Skurcz";
            this.ShrinkMenuBtn.Click += new System.EventHandler(this.ShrinkMenuBtn_Click);
            /// 
            /// Widok
            /// 
            this.viewMenu.CheckOnClick = true;
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomViewBtn,
            this.StretchViewBtn,
            this.NormalViewBtn,
            this.AutosizeViewBtn,
            this.CenterViewBtn,
            this.transparentViewBtn});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(41, 25);
            this.viewMenu.Text = "Widok";
            this.viewMenu.ToolTipText = "Background transparent or grey";
            /// 
            /// Zoom
            /// 
            this.ZoomViewBtn.Checked = true;
            this.ZoomViewBtn.CheckOnClick = true;
            this.ZoomViewBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ZoomViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ZoomViewBtn.Name = "ZoomViewBtn";
            this.ZoomViewBtn.Size = new System.Drawing.Size(152, 22);
            this.ZoomViewBtn.Text = "Zoom";
            this.ZoomViewBtn.Click += new System.EventHandler(this.zoomViewBtn_Click);
            /// 
            /// Rozciąg
            /// 
            this.StretchViewBtn.Checked = true;
            this.StretchViewBtn.CheckOnClick = true;
            this.StretchViewBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StretchViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StretchViewBtn.Name = "StretchViewBtn";
            this.StretchViewBtn.Size = new System.Drawing.Size(152, 22);
            this.StretchViewBtn.Text = "Rozciąg";
            this.StretchViewBtn.Click += new System.EventHandler(this.StretchViewBtn_Click);
            /// 
            /// Normalny
            /// 
            this.NormalViewBtn.Checked = true;
            this.NormalViewBtn.CheckOnClick = true;
            this.NormalViewBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NormalViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NormalViewBtn.Name = "NormalViewBtn";
            this.NormalViewBtn.Size = new System.Drawing.Size(152, 22);
            this.NormalViewBtn.Text = "Normalny";
            this.NormalViewBtn.Click += new System.EventHandler(this.NormalViewBtn_Click);
            /// 
            /// AutosizeViewBtn
            /// 
            this.AutosizeViewBtn.Checked = true;
            this.AutosizeViewBtn.CheckOnClick = true;
            this.AutosizeViewBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutosizeViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AutosizeViewBtn.Name = "AutosizeViewBtn";
            this.AutosizeViewBtn.Size = new System.Drawing.Size(152, 22);
            this.AutosizeViewBtn.Text = "AutoSize";
            this.AutosizeViewBtn.Click += new System.EventHandler(this.AutosizeViewBtn_Click);
            /// 
            /// Wyśrodkuj
            /// 
            this.CenterViewBtn.Checked = true;
            this.CenterViewBtn.CheckOnClick = true;
            this.CenterViewBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CenterViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CenterViewBtn.Name = "CenterViewBtn";
            this.CenterViewBtn.Size = new System.Drawing.Size(152, 22);
            this.CenterViewBtn.Text = "Wyśrodkuj";
            this.CenterViewBtn.Click += new System.EventHandler(this.CenterViewBtn_Click);
            /// 
            /// Przezroczysty
            /// 
            this.transparentViewBtn.CheckOnClick = true;
            this.transparentViewBtn.Name = "transparentViewBtn";
            this.transparentViewBtn.Size = new System.Drawing.Size(152, 22);
            this.transparentViewBtn.Text = "Przezroczysty";
            this.transparentViewBtn.Click += new System.EventHandler(this.transparentToolStripMenuItem_Click);
            /// 
            /// Zamknij
            /// 
            this.CloseMenuBtn.Name = "CloseMenuBtn";
            this.CloseMenuBtn.Size = new System.Drawing.Size(45, 25);
            this.CloseMenuBtn.Text = "Zamknij";
            this.CloseMenuBtn.Click += new System.EventHandler(this.CloseMenuBtn_Click);
            /// 
            /// Obraz
            /// 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.Gray;
            this.pictureBox.Location = new System.Drawing.Point(0, 29);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(360, 299);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.Resize += new System.EventHandler(this.pictureBox_Resize);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            /// 
            /// resize
            /// 
            this.resize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resize.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.resize.Image = global::picViewer_NS.Properties.Resources.resize;
            this.resize.Location = new System.Drawing.Point(315, 312);
            this.resize.Name = "resize";
            this.resize.Size = new System.Drawing.Size(45, 35);
            this.resize.TabIndex = 4;
            this.resize.UseVisualStyleBackColor = false;
            this.resize.MouseLeave += new System.EventHandler(this.resize_MouseLeave);
            this.resize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resize_MouseMove);
            this.resize.Click += new System.EventHandler(this.resize_Click);
            this.resize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resize_MouseDown);
            this.resize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resize_MouseUp);
            /// 
            /// InfoTxt
            /// 
            this.InfoTxt.AutoSize = true;
            this.InfoTxt.BackColor = System.Drawing.SystemColors.MenuText;
            this.InfoTxt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.InfoTxt.Location = new System.Drawing.Point(15, 52);
            this.InfoTxt.Name = "InfoTxt";
            this.InfoTxt.Size = new System.Drawing.Size(20, 13);
            this.InfoTxt.TabIndex = 5;
            this.InfoTxt.Text = "x,y";
            this.InfoTxt.Visible = false;
            /// 
            /// ImgViewer
            /// 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.InfoTxt);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.resize);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "ImgViewer";
            this.Size = new System.Drawing.Size(360, 345);
            this.MouseLeave += new System.EventHandler(this.menuStrip_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox statusBar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem SaveAsMenuBtn;
        private System.Windows.Forms.Button resize;
        private System.Windows.Forms.ToolStripMenuItem ShrinkMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuBtn;
        private System.Windows.Forms.Label InfoTxt;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem ZoomViewBtn;
        private System.Windows.Forms.ToolStripMenuItem StretchViewBtn;
        private System.Windows.Forms.ToolStripMenuItem NormalViewBtn;
        private System.Windows.Forms.ToolStripMenuItem AutosizeViewBtn;
        private System.Windows.Forms.ToolStripMenuItem CenterViewBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem dummyMenu;
        private System.Windows.Forms.ToolStripMenuItem transparentViewBtn;
    }
}
