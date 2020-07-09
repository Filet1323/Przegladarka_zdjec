using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace picViewer_NS
{
    public partial class PicViewerForm : Form
    {
        public PicViewerForm()
        {
            /// Ustaw wartość bitów stylu podwójnego buforowania na true.
            this.SetStyle(
                /// ControlStyles.DoubleBuffer 
                ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint 
                | ControlStyles.AllPaintingInWmPaint
             ///   | ControlStyles.Opaque
                , true);

            InitializeComponent();

            this.Text = ProductNameAndVersion() + " " + Application.CompanyName;
        }

        private ArrayList viewers = new ArrayList();
        private Size viewerSize = ImgViewer.DefaultSize;

        public static string ProductNameAndVersion()
        {
            string appName = Application.ProductName;
            string appVern = Application.ProductVersion;
            return appName + " v" + appVern.Substring(0, 3); ///  Uzyskaj część ciągu wersji „n.n”
        }

        #region ==== Main UI buttons and actions

        private Point NextViewerLocation()
        {
            int margin = viewerSize.Width / 10;
            int rows = this.mainPanel.Height / viewerSize.Height + 2;   /// dopuścić 2 kolejne rzędy
            int cols = this.mainPanel.Width / viewerSize.Width + 1;     /// jeszcze jedna kolumna.
            bool[,] gridSpots = new bool[rows, cols];

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    gridSpots[r, c] = false;

            foreach (ImgViewer imgViewer in viewers)
            {
                if (imgViewer.Visible)
                {
                    Point  vLoc = imgViewer.Location;
                    int r1 = vLoc.Y / viewerSize.Width;
                    int c1 = vLoc.X / viewerSize.Height;
                    int r2 = (vLoc.Y + imgViewer.Height-margin) / viewerSize.Height;
                    int c2 = (vLoc.X + imgViewer.Width-margin) / viewerSize.Width;
                    for (int r = r1; r <= r2; r++)
                        for (int c = c1; c <= c2; c++)
                            try { 
                                gridSpots[r, c] = true; 
                            }
                            catch { }
                }
            }

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (gridSpots[r, c] == false)
                        return new Point(c * viewerSize.Width, r * viewerSize.Height);

            return new Point(0, 0);
        }

        private ImgViewer AddViewer()
        {
            ImgViewer imgViewer = new ImgViewer(this, viewerSize);
            imgViewer.BringToFront();
            imgViewer.Tag = viewers.Count.ToString();
            imgViewer.Location = NextViewerLocation();
            viewers.Add(imgViewer);
            this.mainPanel.Controls.Add(imgViewer);
            return imgViewer;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddViewer();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            foreach (ImgViewer imgViewer in viewers)
            {
                if (imgViewer.Visible == true)
                {
                    this.mainPanel.Controls.Remove(imgViewer);
                }
            }

            viewers.Clear();
        }

        private void exitMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openMenuBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "All files (*.*)|*.*";
            openDialog.Multiselect = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fn in openDialog.FileNames)
                {
                    AddViewer().Filename = fn;
                }
            }
        }

        private void LoadMultiFilesBtn_Click(object sender, EventArgs e)
        {
            openMenuBtn_Click(sender, e);
        }

        private void AboutTsBtn_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
           aboutBox.Show();
       }

        private void ExitTsBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void solidColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPanel.BackgroundImage = null;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.mainPanel.BackColor = colorDialog.Color;
            }
        }

        int bgImageIdx = 0;
        private void pictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (bgImageIdx)
            {
                case 0:
                    this.mainPanel.BackgroundImage = global::picViewer_NS.Properties.Resources.image0;
                    break;
            }

            bgImageIdx = (bgImageIdx + 1) % 1;
        }


        #endregion

        #region ==== Focus and Keyboard controls
        public void SetFocus(ImgViewer focusViewer)
        {
            foreach (ImgViewer imgViewer in viewers)
            {
                imgViewer.HasFocus = (imgViewer == focusViewer);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            bool nextFocus = false;

            switch (e.KeyCode)
            {
                case Keys.Tab:
                    foreach (ImgViewer imgViewer in viewers)
                    {
                        if (imgViewer.Visible == true)
                        {
                            if (nextFocus)
                            {
                                imgViewer.HasFocus = true;
                                return;
                            }
                            if (imgViewer.HasFocus)
                            {
                                imgViewer.HasFocus = false;
                                nextFocus = true;
                            }
                        }
                    }

                    foreach (ImgViewer imgViewer in viewers)
                    {
                        if (imgViewer.Visible == true)
                        {
                            imgViewer.HasFocus = true;
                            return;
                        }
                    }
                    break;

                default:
                    if (listViewers.Focused == false && e.Control == false && e.Alt == false)
                    {
                        foreach (ImgViewer imgViewer in viewers)
                        {
                            if (imgViewer.HasFocus)
                            {
                                imgViewer.KeyCmd(e.KeyCode);
                            }
                        }
                    }
                    break;
            }

            base.OnKeyUp(e);
        }
        #endregion

        #region ==== Image menu 
        /// Przechwyć ekran i dodaj do eksploratora obrazów.

        private void grabAndAddImage_Click(object sender, EventArgs e)
        {
            CaptureDialog captureDialog = new CaptureDialog();
            this.Hide();
            captureDialog.ShowDialog();
            this.Show();

            int idx = 0;
            foreach (Image image in captureDialog.imageList)
            {
                Bitmap bitmap = new Bitmap(image);
                string imageName = "screen" + idx++.ToString() + ".bmp";
                bitmap.Save(imageName);
                AddViewer().Filename = imageName;
            }
        }

        /// Zrób zdjęcie okna dialogowego (zrzut ekranu)
        private void savePicViewerImage_Click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(this.mainPanel.PointToScreen(this.mainPanel.Location), this.mainPanel.Size);

            int color = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pFormat;

            switch (color)
            {
                case 8:
                case 16:
                    pFormat = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    pFormat = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;

                default:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;
            }

            Application.DoEvents();
            Bitmap image = new Bitmap(rect.Width, rect.Height, pFormat);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog.FileName);
            }
        }
        #endregion

        #region ==== Viewer List UI
        bool checkEvent = true;
        public void UpdateListViewers()
        {
            this.listViewers.Items.Clear();

            int idx = 0;
            checkEvent = false;
            foreach (Control c in this.mainPanel.Controls)
            {
                if (c is ImgViewer)
                {
                    ImgViewer imgViewer = (ImgViewer)c;
                    idx++;
                    ListViewItem item = this.listViewers.Items.Add(idx.ToString());
                    item.SubItems.Add(imgViewer.Filename);
                    item.SubItems.Add(Path.GetFileName(imgViewer.Filename));
                    item.SubItems.Add(imgViewer.Width.ToString());
                    item.SubItems.Add(imgViewer.Height.ToString());
                    item.SubItems.Add(imgViewer.Location.X.ToString());
                    item.SubItems.Add(imgViewer.Location.Y.ToString());
                    item.SubItems.Add(imgViewer.ViewSizeMode.ToString());
                    item.SubItems.Add(imgViewer.Transparent.ToString());
                    item.SubItems.Add(imgViewer.MenuVisible.ToString());

                    item.Checked = imgViewer.Visible;
                    item.Tag = imgViewer;
                }
            }
            checkEvent = true;
        }

        private void listViewers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (checkEvent)
            {
                ImgViewer imgViewer = (ImgViewer)e.Item.Tag;
                imgViewer.Visible = e.Item.Checked;
            }
        }

        private void listViewers_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.T:    /// przezroczysty
                    bool bTransparent = true;
                    if (e.Control || e.Alt)
                    {
                        /// Przełącz przezroczystość WSZYSTKICH elementów
                        foreach (ListViewItem item in listViewers.Items)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            if (item == listViewers.Items[0])
                                bTransparent = !imgViewer.Transparent;
                            imgViewer.Transparent = bTransparent;
                            item.SubItems[8].Text = bTransparent.ToString();
                        }
                    }
                    else
                    {
                        /// Przełącz przezroczystość WYBRANYCH elementów
                        foreach (ListViewItem item in listViewers.SelectedItems)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            if (item == listViewers.SelectedItems[0])
                                bTransparent = !imgViewer.Transparent;
                            imgViewer.Transparent = bTransparent;
                            item.SubItems[8].Text = bTransparent.ToString();
                        }
                    }
                    e.Handled = true;
                    break;


                case Keys.M:    /// menu
                    bool bMenuVisible = false;
                    if (e.Control || e.Alt)
                    {
                        foreach (ListViewItem item in listViewers.Items)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            if (item == listViewers.Items[0])
                                bMenuVisible = !imgViewer.MenuVisible;
                            imgViewer.MenuVisible = bMenuVisible;
                            item.SubItems[9].Text = bMenuVisible.ToString();
                        }
                    }
                    else
                    {
                        foreach (ListViewItem item in listViewers.SelectedItems)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            if (item == listViewers.SelectedItems[0])
                                bMenuVisible = !imgViewer.MenuVisible;
                            imgViewer.MenuVisible = bMenuVisible;
                            item.SubItems[9].Text = bMenuVisible.ToString();
                        }
                    }
                    e.Handled = true;
                    break;

                case Keys.C:        /// zamknij
                case Keys.Delete:   /// zamknij
                    if (e.Control || e.Alt)
                    {
                        /// zamknij wszystko
                        foreach (ListViewItem item in listViewers.Items)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            imgViewer.Close();
                        }
                    }
                    else
                    {
                        /// Zamknij WYBRANE elementy.
                        foreach (ListViewItem item in listViewers.SelectedItems)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            imgViewer.Close();
                        }
                    }
                    e.Handled = true;
                    break;

                case Keys.H:     /// Home
                    if (e.Control || e.Alt)
                    {
                        foreach (ListViewItem item in listViewers.Items)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            imgViewer.Location = Point.Empty;
                            imgViewer.Focus();
                        }
                    }
                    else
                    {
                        foreach (ListViewItem item in listViewers.SelectedItems)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            imgViewer.Location = Point.Empty;
                            imgViewer.Focus();
                        }
                    }
                    e.Handled = true;
                    break;

                case Keys.Oemplus:     /// plus - podbić
                    if (e.Control || e.Alt)
                    {
                        foreach (ListViewItem item in listViewers.Items)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            imgViewer.BringToFront();
                            imgViewer.Focus();
                        }
                    }
                    else
                    {
                        foreach (ListViewItem item in listViewers.SelectedItems)
                        {
                            ImgViewer imgViewer = (ImgViewer)item.Tag;
                            imgViewer.BringToFront();
                            imgViewer.Focus();
                        }
                    }
                    e.Handled = true;
                    break;
            }
        }

        private void mainPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            UpdateListViewers();
        }

        private void mainPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            UpdateListViewers();
        }

        #endregion

        private void mainPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) ||
              e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void mainPanel_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    string fileName = (string)e.Data.GetData(DataFormats.Text);
                    if (fileName.Length > 0)
                    {
                        AddViewer().Filename = fileName;
                    }
                }
                else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] fileNames;
                    fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string fileName in fileNames)
                    {
                        if (fileName.Length > 0)
                        {
                            AddViewer().Filename = fileName;
                        }
                    }
                }
            }
            catch { }
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
