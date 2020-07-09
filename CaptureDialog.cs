using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections;

namespace AGifCreator
{
    /// <summary>
    /// Capture screen rectangle and save as an image:
    ///    * Automatically capture an image every 5 seconds, stopping after 5 images.
    ///    * Capture on close
    ///    * Capture region under window frame, resize and reposition to select capture area.
    ///    * Title bar will display position and frame size
    ///    
    /// Author: Dennis Lang  2009       
    /// http://home.comcast.net/~lang.dennis/
    /// </summary>
    public partial class CaptureDialog : Form
    {
        public CaptureDialog()
        {
            InitializeComponent();
            this.Text = "Resize then close to capture";
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
        }

        public ArrayList imageList = new ArrayList();
        private System.Media.SoundPlayer sPlayer = new System.Media.SoundPlayer();

        /// <summary>
        ///  Every 5 seconds - take an automatic screen capture, stop after 5 images.
        /// </summary>
        private void timer_Tick(object sender, EventArgs ev)
        {
            this.CaptureScreen();
            if (this.imageList.Count < 5)
                this.timer.Start();
        }

        private void CaptureScreen()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            if (this.Size != this.MaximumSize)
                rect = this.Bounds;

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

            Image image = new Bitmap(rect.Width, rect.Height, pFormat);
            Graphics g = Graphics.FromImage(image);
            this.Hide();
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
            this.Show();

            this.imageList.Add(image);
            this.sPlayer.Stream = Properties.Resources.drum1;
            this.sPlayer.Play();
        }

        private void CaptureDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer.Stop();
            this.CaptureScreen();
        }

        /// <summary>
        /// Display current dialog offset and size in title bar.
        /// </summary>
        private void CaptureDialog_Resize(object sender, EventArgs e)
        {
            this.Text = this.Bounds.ToString();
        }

        /// <summary>
        /// Display current dialog offset and size in title bar.
        /// </summary>
        private void CaptureDialog_Move(object sender, EventArgs e)
        {
            this.Text = this.Bounds.ToString();
        }

#if false
        // Following code does not work !

        // Attemp to make capture bar (aka Title bar), the same transparent color as dialog.
        // Code provided by:
        // http://www.dotnet247.com/247reference/msgs/20/102900.aspx
        [DllImport("user32.dll")]
        private static extern uint GetSysColor(Int32 nIndex);

        [DllImport("user32.dll")]
        private static extern Boolean SetSysColors(int cElements, int[] lpaElements, uint[] lpaRgbValues);

        private const int COLOR_ACTIVECAPTION = 2;
        private uint oldColor;
        
        private void CaptureDialog_Activated(object sender, EventArgs e)
        {
            oldColor = GetSysColor(COLOR_ACTIVECAPTION);

            int[] element = new int[] { COLOR_ACTIVECAPTION };
            uint[] rgb = new uint[] { (uint)Color.LimeGreen.ToArgb() & 0x00FFFFFF };
            bool b = SetSysColors(1, element, rgb);
        }

        private void CaptureDialog_Deactivate(object sender, EventArgs e)
        {
            int[] element = new int[] { COLOR_ACTIVECAPTION };
            uint[] rgb = new uint[] { oldColor };
            bool b = SetSysColors(1, element, rgb);
        }
#endif
    }
}
