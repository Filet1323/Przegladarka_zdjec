namespace picViewer_NS
{
    partial class PicViewerForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicViewerForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bgPictureMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bgColorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.grabMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.savePicViewerImage = new System.Windows.Forms.ToolStripMenuItem();
            this.grabAndAddImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.mainPanel = new picViewer_NS.LayerPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewers = new System.Windows.Forms.ListView();
            this.col_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_width = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_height = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_X = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Y = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_view = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_trans = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_menu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.LoadMultiFilesBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.AddBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.ClearBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ExitTsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutTsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.backgroundMenu,
            this.grabMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(970, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuBtn,
            this.exitMenuBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "Plik";
            // 
            // openMenuBtn
            // 
            this.openMenuBtn.Name = "openMenuBtn";
            this.openMenuBtn.Size = new System.Drawing.Size(117, 22);
            this.openMenuBtn.Text = "Otwórz";
            this.openMenuBtn.Click += new System.EventHandler(this.openMenuBtn_Click);
            // 
            // exitMenuBtn
            // 
            this.exitMenuBtn.Name = "exitMenuBtn";
            this.exitMenuBtn.Size = new System.Drawing.Size(117, 22);
            this.exitMenuBtn.Text = "Zamknij";
            this.exitMenuBtn.Click += new System.EventHandler(this.exitMenuBtn_Click);
            // 
            // backgroundMenu
            // 
            this.backgroundMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bgPictureMenu,
            this.bgColorMenu});
            this.backgroundMenu.Name = "backgroundMenu";
            this.backgroundMenu.Size = new System.Drawing.Size(35, 20);
            this.backgroundMenu.Text = "Tło";
            // 
            // bgPictureMenu
            // 
            this.bgPictureMenu.Enabled = false;
            this.bgPictureMenu.Name = "bgPictureMenu";
            this.bgPictureMenu.Size = new System.Drawing.Size(151, 22);
            this.bgPictureMenu.Text = "Obraz";
            this.bgPictureMenu.Click += new System.EventHandler(this.pictureToolStripMenuItem_Click);
            // 
            // bgColorMenu
            // 
            this.bgColorMenu.Name = "bgColorMenu";
            this.bgColorMenu.Size = new System.Drawing.Size(151, 22);
            this.bgColorMenu.Text = "Jednolity kolor";
            this.bgColorMenu.Click += new System.EventHandler(this.solidColorToolStripMenuItem_Click);
            // 
            // grabMenu
            // 
            this.grabMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePicViewerImage,
            this.grabAndAddImage});
            this.grabMenu.Name = "grabMenu";
            this.grabMenu.Size = new System.Drawing.Size(50, 20);
            this.grabMenu.Text = "Obraz";
            // 
            // savePicViewerImage
            // 
            this.savePicViewerImage.Name = "savePicViewerImage";
            this.savePicViewerImage.Size = new System.Drawing.Size(139, 22);
            this.savePicViewerImage.Text = "Zapisz obraz";
            this.savePicViewerImage.Click += new System.EventHandler(this.savePicViewerImage_Click);
            // 
            // grabAndAddImage
            // 
            this.grabAndAddImage.Name = "grabAndAddImage";
            this.grabAndAddImage.Size = new System.Drawing.Size(139, 22);
            this.grabAndAddImage.Text = "Złap obraz";
            this.grabAndAddImage.Click += new System.EventHandler(this.grabAndAddImage_Click);
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitter);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(970, 577);
            this.toolStripContainer.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(970, 647);
            this.toolStripContainer.TabIndex = 1;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.Gray;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.mainPanel);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.label1);
            this.splitter.Panel2.Controls.Add(this.listViewers);
            this.splitter.Size = new System.Drawing.Size(970, 577);
            this.splitter.SplitterDistance = 711;
            this.splitter.TabIndex = 1;
            // 
            // mainPanel
            // 
            this.mainPanel.AllowDrop = true;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(711, 577);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.TransparentChildren = true;
            this.mainPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.mainPanel_ControlAdded);
            this.mainPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.mainPanel_ControlRemoved);
            this.mainPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainPanel_DragDrop);
            this.mainPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainPanel_DragEnter);
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 257);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prosta przeglądarka obrazów, która umożliwia przeglądanie wielu obrazów i przenos" +
    "zenie ich w obszarze roboczym. Przydatne, jeśli musisz porównać wiele obrazów lu" +
    "b części obrazu razem.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listViewers
            // 
            this.listViewers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewers.CheckBoxes = true;
            this.listViewers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_num,
            this.col_path,
            this.col_file,
            this.col_width,
            this.col_height,
            this.col_X,
            this.col_Y,
            this.col_view,
            this.col_trans,
            this.col_menu});
            this.listViewers.FullRowSelect = true;
            this.listViewers.GridLines = true;
            this.listViewers.HideSelection = false;
            this.listViewers.Location = new System.Drawing.Point(3, 0);
            this.listViewers.Name = "listViewers";
            this.listViewers.Size = new System.Drawing.Size(255, 317);
            this.listViewers.TabIndex = 0;
            this.listViewers.UseCompatibleStateImageBehavior = false;
            this.listViewers.View = System.Windows.Forms.View.Details;
            this.listViewers.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewers_ItemChecked);
            this.listViewers.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewers_KeyUp);
            // 
            // col_num
            // 
            this.col_num.Text = "#";
            this.col_num.Width = 41;
            // 
            // col_path
            // 
            this.col_path.Text = "Ścieżka";
            // 
            // col_file
            // 
            this.col_file.Text = "Plik";
            // 
            // col_width
            // 
            this.col_width.Text = "Szerokość";
            this.col_width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_height
            // 
            this.col_height.Text = "Wysokość";
            this.col_height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_X
            // 
            this.col_X.Text = "X";
            this.col_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_Y
            // 
            this.col_Y.Text = "Y";
            this.col_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // col_view
            // 
            this.col_view.Text = "Widok";
            // 
            // col_trans
            // 
            this.col_trans.Text = "Przezroczysty";
            // 
            // col_menu
            // 
            this.col_menu.Text = "Menu";
            // 
            // toolStrip
            // 
            this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadMultiFilesBtn,
            this.toolStripButton4,
            this.AddBtn,
            this.toolStripButton2,
            this.ClearBtn,
            this.toolStripButton1,
            this.toolStripButton3,
            this.ExitTsBtn,
            this.toolStripSeparator1,
            this.AboutTsBtn});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(970, 70);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "Pasek narzędzi";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // LoadMultiFilesBtn
            // 
            this.LoadMultiFilesBtn.Image = global::picViewer_NS.Properties.Resources._48_button_blue_pluses;
            this.LoadMultiFilesBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadMultiFilesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadMultiFilesBtn.Name = "LoadMultiFilesBtn";
            this.LoadMultiFilesBtn.Size = new System.Drawing.Size(52, 67);
            this.LoadMultiFilesBtn.Text = "Załaduj";
            this.LoadMultiFilesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LoadMultiFilesBtn.Click += new System.EventHandler(this.LoadMultiFilesBtn_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 67);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // AddBtn
            // 
            this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
            this.AddBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(52, 67);
            this.AddBtn.Text = "Dodaj";
            this.AddBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddBtn.ToolTipText = "Dodaj zdjęcie";
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 67);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // ClearBtn
            // 
            this.ClearBtn.AutoSize = false;
            this.ClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("ClearBtn.Image")));
            this.ClearBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ClearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(52, 65);
            this.ClearBtn.Text = "Zamknij";
            this.ClearBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ClearBtn.ToolTipText = "Zamknij wszystko";
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 67);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 67);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // ExitTsBtn
            // 
            this.ExitTsBtn.Image = global::picViewer_NS.Properties.Resources._48_button_purple_exit;
            this.ExitTsBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExitTsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitTsBtn.Name = "ExitTsBtn";
            this.ExitTsBtn.Size = new System.Drawing.Size(52, 67);
            this.ExitTsBtn.Text = "Wyjście";
            this.ExitTsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ExitTsBtn.Click += new System.EventHandler(this.ExitTsBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 70);
            // 
            // AboutTsBtn
            // 
            this.AboutTsBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AboutTsBtn.AutoSize = false;
            this.AboutTsBtn.Image = global::picViewer_NS.Properties.Resources.icon;
            this.AboutTsBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AboutTsBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AboutTsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutTsBtn.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.AboutTsBtn.Name = "AboutTsBtn";
            this.AboutTsBtn.Size = new System.Drawing.Size(52, 65);
            this.AboutTsBtn.Text = "O nas";
            this.AboutTsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AboutTsBtn.ToolTipText = "O nas";
            this.AboutTsBtn.Click += new System.EventHandler(this.AboutTsBtn_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Png|*.Png|Jpg|*.jpg|Bmp|*.bmp|Any|*.*";
            this.saveFileDialog.Title = "Zapisz obraz";
            // 
            // PicViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 693);
            this.Controls.Add(this.toolStripContainer);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PicViewerForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Przeglądarka zdjęć";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem exitMenuBtn;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton AddBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private LayerPanel mainPanel;
        private System.Windows.Forms.ToolStripButton ClearBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton AboutTsBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton ExitTsBtn;
        private System.Windows.Forms.ToolStripButton LoadMultiFilesBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem backgroundMenu;
        private System.Windows.Forms.ToolStripMenuItem bgPictureMenu;
        private System.Windows.Forms.ToolStripMenuItem bgColorMenu;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem grabMenu;
        private System.Windows.Forms.ToolStripMenuItem savePicViewerImage;
        private System.Windows.Forms.ToolStripMenuItem grabAndAddImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.ListView listViewers;
        private System.Windows.Forms.ColumnHeader col_num;
        private System.Windows.Forms.ColumnHeader col_file;
        private System.Windows.Forms.ColumnHeader col_width;
        private System.Windows.Forms.ColumnHeader col_height;
        private System.Windows.Forms.ColumnHeader col_X;
        private System.Windows.Forms.ColumnHeader col_Y;
        private System.Windows.Forms.ColumnHeader col_path;
        private System.Windows.Forms.ColumnHeader col_view;
        private System.Windows.Forms.ColumnHeader col_trans;
        private System.Windows.Forms.ColumnHeader col_menu;
        private System.Windows.Forms.Label label1;
    }
}

