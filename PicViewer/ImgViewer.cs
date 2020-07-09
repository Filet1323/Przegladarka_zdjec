using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace picViewer_NS
{
    public partial class ImgViewer : UserControl
    {
        public ImgViewer(PicViewerForm parent, Size dlgSize)
        {
            InitializeComponent();
            this.picViewer = parent;
            this.Focus();
            this.Size = dlgSize;
            SetViewSizeMode(ViewEnum.eZoom);

            mouseMoveFilter = new MouseMoveFilter(this);
            Application.AddMessageFilter(mouseMoveFilter);
        }

        ~ImgViewer()
        {
            Application.RemoveMessageFilter(mouseMoveFilter);
        }

        public void Close()
        {
            Application.RemoveMessageFilter(mouseMoveFilter);
            this.Visible = this.Enabled = false;
            this.Parent.Controls.Remove(this);
            /// this.Dispose();
        }


        ///  Hack, aby złapać globalny ruch myszy, który poprawia przeciąganie i zmienia rozmiar użyteczności.

        public class MouseMoveFilter : IMessageFilter
        {
            #region IMessageFilter Members
            private const int WM_MOUSELEAVE = 0x02A3;
            private const int WM_NCMOUSEMOVE = 0x0A0;
            private const int WM_MOUSEMOVE = 0x0200;
            private const int WM_NCMOUSELEAVE = 0x2A2;

            private ImgViewer imgViewer;
            private bool imgInside = false;
            public MouseMoveFilter(ImgViewer iv)
            {
                imgViewer = iv;
            }

            public bool PreFilterMessage(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_NCMOUSEMOVE:
                    case WM_MOUSEMOVE:
                        
                        Point p = imgViewer.PointToClient(Control.MousePosition);
                        bool newInside = imgViewer.DisplayRectangle.Contains(p);
                        if (newInside != imgInside)
                        {
                            if (imgViewer.autoHide)
                                imgViewer.VisMode(newInside);
                            imgInside = newInside;
                        }

                        /// Prześlij wszystkie przeciągnięcia myszy oprócz opcji Zmień rozmiar
                        Point pntResize = imgViewer.resize.PointToClient(Control.MousePosition);
                        if (imgViewer.resize.DisplayRectangle.Contains(pntResize) == false)
                        {
                            if (Control.MouseButtons == MouseButtons.Left && imgViewer.startResize)
                            {
                                MouseEventArgs mouseEvent = new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0);
                                imgViewer.resize_MouseMove(null, mouseEvent);
                                return true;
                            }
                            else if (newInside || (Control.MouseButtons == MouseButtons.Left && imgViewer.startMove))
                            {
                                imgViewer.MouseDrag();
                                return (Control.MouseButtons == MouseButtons.Left);
                            }
                       
                        }
                        break;

                    case WM_NCMOUSELEAVE:
                    case WM_MOUSELEAVE:
                        break;

                }
                return false;
            }

            #endregion
        }
        private MouseMoveFilter mouseMoveFilter;

        static public new Size DefaultSize = new Size(300, 300);

        private string filename;
        private Size startPos;
        private bool startResize = false;
        private bool startMove = false;
        private Size ShrinkSize = new Size(96, 96);
        private bool hasFocus = false;
        private PicViewerForm picViewer;
        private bool autoHide = false;

        public bool HasFocus
        {
            get { return this.hasFocus; }
            set
            {
                this.hasFocus = value;
                if (this.hasFocus)
                {
                    menuStrip.BackColor = Color.Plum;
                    BringToFront();
                    this.Focus();
                }
                else
                {
                    menuStrip.BackColor = Color.LightBlue;
                }
            }
        }

        public string Filename
        {
            get { return this.filename; }
            set
            {
                try
                {
                    Image image = Bitmap.FromFile(value);
                    this.pictureBox.Image = image;
                    this.statusBar.Text = filename = value;
                    this.statusBar.SelectionStart = filename.Length;
                    this.statusBar.SelectionLength = 0;

                    picViewer.UpdateListViewers();
                }
                catch
                {
                    this.statusBar.Text = "Failed to load:" + value; 
                }
            }
        }

        private void openMenuBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Filename = openDialog.FileName;
            }
        }

        private void CloseMenuBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShrinkMenuBtn_Click(object sender, EventArgs e)
        {
            this.Size = this.ShrinkSize;
        }

        private void resize_Click(object sender, EventArgs e)
        {
            this.Size = new Size(this.Width + 10, this.Height);
        }

        private void pictureBox_Resize(object sender, EventArgs e)
        {
#if false
            if (pictureBox.SizeMode == PictureBoxSizeMode.AutoSize)
            {
                this.Width = pictureBox.Width;
                int adjHeight = pictureBox.Height;
                if (this.menuStrip.Visible)
                    adjHeight += menuStrip.Height + statusBar.Height;
                this.Height = adjHeight;
                statusBar.Location = new Point(0, this.Height - statusBar.Height);
            }
#endif
        }

        public void VisMode(bool mode)
        {
            if (resize.Visible == mode)
                return;

            this.Visible = false;
            resize.Visible = menuStrip.Visible = statusBar.Visible = mode;
            this.BackColor = mode ? this.pictureBox.BackColor : Color.Transparent;
            int picHeight = this.pictureBox.Height;

            if (mode)
            {
                this.Location = new Point(this.Location.X, this.Location.Y - menuStrip.Height);
                this.pictureBox.Location = new Point(0, menuStrip.Height);
                this.Height += menuStrip.Height + statusBar.Height;
            }
            else
            {
                this.Location = new Point(this.Location.X, this.Location.Y + menuStrip.Height);
                this.pictureBox.Location = new Point(0,0);
                this.Height -= menuStrip.Height + statusBar.Height;
            }
            this.pictureBox.Height = picHeight;
            this.Visible = true;
        }

        #region Resize viewer
        private void resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.startResize)
            {
                if (this.Size == this.ShrinkSize)
                {
                    this.Size = ImgViewer.DefaultSize;
                    this.startResize = false;
                    this.InfoTxt.Visible = false;

                    picViewer.UpdateListViewers();
                }
                else
                {
                    Size newPos = new Size(Control.MousePosition.X, Control.MousePosition.Y);
                    this.Size = this.Size - (this.startPos - newPos);
                    this.startPos = newPos;
                    this.InfoTxt.Text = this.Size.ToString();
                }
            }
        }

        private void resize_MouseDown(object sender, MouseEventArgs e)
        {
            this.picViewer.SetFocus(this);
            this.startMove = false;
            this.startResize = true;
            this.InfoTxt.Visible = true;
            this.startPos = new Size(Control.MousePosition.X, Control.MousePosition.Y);
            this.Cursor = Cursors.SizeNWSE;
        }

        private void resize_MouseUp(object sender, MouseEventArgs e)
        {
            resize_MouseLeave(sender, e);
        }
        private void resize_MouseLeave(object sender, EventArgs e)
        {
            this.startResize = (Control.MouseButtons == MouseButtons.Left);
            this.InfoTxt.Visible = false;
            this.Cursor = Cursors.Arrow;

        }
        #endregion

        #region Move Viewer

        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            this.picViewer.SetFocus(this);
            this.startMove = false;
            this.Cursor = Cursors.PanNW;
            this.menuStrip.Focus();
        }

        private void menuStrip_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.PanNW;
        }

        private void menuStrip_MouseMove(object sender, MouseEventArgs e)
        {
            MouseDrag();
        }

        public void MouseDrag()
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                Size newPos = new Size(Control.MousePosition.X, Control.MousePosition.Y);
                if (this.startMove)
                {
                    this.Location = this.Location - (this.startPos - newPos);
                }

                this.startPos = newPos;
                this.startMove = true;
            }
            else
            {
                if (this.startMove)
                    picViewer.UpdateListViewers();

                this.startMove = false;
            }
        }

        private void menuStrip_MouseUp(object sender, MouseEventArgs e)
        {
            menuStrip_MouseLeave(sender, e);
        }

        private void menuStrip_MouseLeave(object sender, EventArgs e)
        {
            this.startMove = System.Windows.Forms.Control.MouseButtons == MouseButtons.Left;
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region Mouse Position
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.picViewer.SetFocus(this); 
            this.InfoTxt.Visible = true;
            this.Cursor = Cursors.Cross;
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.InfoTxt.Text = e.Location.ToString();
        }
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            this.InfoTxt.Visible = false;
            this.Cursor = Cursors.Arrow;
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox_MouseLeave(sender, e);
        }
        #endregion


        #region View Controls

        public bool Transparent
        {
            get { return this.pictureBox.BackColor == Color.Transparent; }
            set {
                this.pictureBox.BackColor = value ? Color.Transparent : Color.Gray;
                this.BackColor = this.pictureBox.BackColor;
                this.transparentViewBtn.Checked = value;
            }
        }

        public bool MenuVisible
        {
            get { return this.menuStrip.Visible; }
            set { this.VisMode(value); }
        }

        public PictureBoxSizeMode ViewSizeMode
        {
            get { return this.pictureBox.SizeMode; }
        }

        public enum ViewEnum {eNormal, eZoom, eStretch, eAutosize, eCenter};
        public void SetViewSizeMode(ViewEnum viewEnum)
        {
            NormalViewBtn.Checked =
                ZoomViewBtn.Checked =
                StretchViewBtn.Checked =
                AutosizeViewBtn.Checked =
                CenterViewBtn.Checked = false;

            this.resize.Enabled = true;

            switch (viewEnum)
            {
                case ViewEnum.eNormal:
                    NormalViewBtn.Checked = true;
                    this.pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    break;
                case ViewEnum.eZoom:
                    ZoomViewBtn.Checked = true;
                    this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case ViewEnum.eStretch:
                    StretchViewBtn.Checked = true;
                    this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case ViewEnum.eAutosize:
                    AutosizeViewBtn.Checked = true;
                    if (this.pictureBox.SizeMode != PictureBoxSizeMode.AutoSize)
                    {
                        this.Width = pictureBox.Image.Width;
                        int adjHeight = pictureBox.Image.Height;
                        if (this.menuStrip.Visible)
                            adjHeight += menuStrip.Height + statusBar.Height;
                        this.Height = adjHeight;

                        this.pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                        // this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        this.resize.Enabled = false;
                    }
                    break;
                case ViewEnum.eCenter:
                    CenterViewBtn.Checked = true;
                    this.pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
            };
        }

        private void zoomViewBtn_Click(object sender, EventArgs e)
        {
            SetViewSizeMode(ViewEnum.eZoom);
        }

        private void StretchViewBtn_Click(object sender, EventArgs e)
        {
            SetViewSizeMode(ViewEnum.eStretch);
        }

        private void NormalViewBtn_Click(object sender, EventArgs e)
        {
            SetViewSizeMode(ViewEnum.eNormal);
        }

        private void AutosizeViewBtn_Click(object sender, EventArgs e)
        {
            SetViewSizeMode(ViewEnum.eAutosize);
        }

        private void CenterViewBtn_Click(object sender, EventArgs e)
        {
            SetViewSizeMode(ViewEnum.eCenter);
        }

        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transparent = transparentViewBtn.Checked;
        }
        #endregion


        ///  Przetwarzaj polecenia klawiszy

        /// <param name="k"></param>
        public void KeyCmd(Keys k)
        {
            switch (k)
            {
                case Keys.C:
                    Close();
                    break;

                case Keys.M:
                    MenuVisible = !MenuVisible;
                    break;

                case Keys.Space:
                    this.VisMode(!this.resize.Visible);
                    break;

                case Keys.T:
                    Transparent = !transparentViewBtn.Checked;
                    break;

                case Keys.D4:
                    break;
            }
        }

    
    }
}
