using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace picViewer_NS
{
    public partial class LayerPanel : Panel
    {
        public LayerPanel()
        {
            InitializeComponent();
            OrgBgImage = this.BackgroundImage;
            base.BackgroundImage = null;
        }

        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                this.OrgBgImage = (value != null) ? new Bitmap(value) : null;
                base.BackgroundImage = value;            
            }
        }

        public bool TransparentChildren
        {
            get { return this.transparentChildren; }
            set { this.transparentChildren = value; }
        }

        bool transparentChildren = true;
        Image OrgBgImage;
        Bitmap bgBitmap;
        Graphics g;

        bool clearBg = true;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (clearBg)
            {
                if (transparentChildren)
                {
                    if (bgBitmap == null)
                    {
                        bgBitmap = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        g = Graphics.FromImage(bgBitmap);
                    }

                    if (this.OrgBgImage != null)
                    {
                        /// Rozciągnij opcjonalny obraz tła.
                        GraphicsUnit gUnits = new GraphicsUnit();
                        RectangleF dstRect = this.Bounds;
                        RectangleF srcRect = this.OrgBgImage.GetBounds(ref gUnits);
                        g.DrawImage(this.OrgBgImage, dstRect, srcRect, gUnits);
                    }
                    else
                    {
                        g.Clear(this.BackColor);
                        /// g.Clear(Color.Transparent);
                    }
                }
                base.OnPaintBackground(e);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (transparentChildren)
            {
                transparentChildren = false;    /// zapobiec ponownemu wejściu

                if (bgBitmap == null)
                {
                    bgBitmap = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(bgBitmap);
                    g.Clear(this.BackColor);
                    /// g.Clear(Color.Transparent);
                }

                if (this.OrgBgImage != null)
                {
                    /// Jeśli obraz tła ma przezroczysty kolor, kliknij Wyczyść, aby ustawić kolor tła.
                    /// Rozciągnij opcjonalny obraz tła.
                    GraphicsUnit gUnits = new GraphicsUnit();
                    RectangleF dstRect = this.Bounds;
                    RectangleF srcRect = this.OrgBgImage.GetBounds(ref gUnits);
                    g.DrawImage(this.OrgBgImage, dstRect, srcRect, gUnits);
                }
                else
                {
                    g.Clear(Color.Transparent);
                }

                clearBg = false;    /// uniemożliwić usunięcie tła
                base.BackgroundImage = bgBitmap;

                /// Rysuj w odwrotnej kolejności
                for (int cIdx = this.Controls.Count - 1; cIdx >= 0 ; cIdx--)
                {
                    g.Flush();
                    Control c = this.Controls[cIdx];
                    Rectangle controlRect = new Rectangle(c.Location, c.Size);
                    if (this.Bounds.Contains(controlRect))
                    {
                        if (c.Enabled && c.Visible)
                        {
                            c.DrawToBitmap(bgBitmap, controlRect);
                        }
                    }
                }

                clearBg = true;
                transparentChildren = true;
                pe.Graphics.DrawImage(bgBitmap, Point.Empty);
            }
            else
            {
                base.OnPaint(pe);
            }
        }
    }
}
