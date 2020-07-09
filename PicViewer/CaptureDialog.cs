using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace picViewer_NS
{
    /// Przechwytuje prostokąt ekranu i zapisuje jako obraz:
    /// * Automatycznie robi zdjęcia co 5 sekund, zatrzymując się po 5 obrazach.
    /// * Przechwytuje przy zamknięciu
    /// * Przechwytuje region pod ramą okna.
    /// * Pasek tytułu wyświetli pozycję i rozmiar ramki

    public partial class CaptureDialog : Form
    {
        public CaptureDialog()
        {
            InitializeComponent();
            this.Text = "Zmień rozmiar, aby przechwycić";
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
        }

        public ArrayList imageList = new ArrayList();
        private System.Media.SoundPlayer sPlayer = new System.Media.SoundPlayer();

        /// <summary>
        ///   Automatycznie robi zdjęcia co 5 sekund, zatrzymując się po 5 obrazach.
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
        /// Wyświetl bieżące przesunięcie i rozmiar okna dialogowego na pasku tytułu.
        /// </summary>
        private void CaptureDialog_Resize(object sender, EventArgs e)
        {
            this.Text = this.Bounds.ToString();
        }

        /// <summary>
        /// Wyświetl bieżące przesunięcie i rozmiar okna dialogowego na pasku tytułu.
        /// </summary>
        private void CaptureDialog_Move(object sender, EventArgs e)
        {
            this.Text = this.Bounds.ToString();
        }
    }
}
