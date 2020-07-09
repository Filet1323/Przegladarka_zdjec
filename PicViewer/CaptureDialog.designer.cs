namespace picViewer_NS
{
    partial class CaptureDialog
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Czasomierz
            // 
            this.timer.Interval = 5000;
            // 
            //  Przechwyć Okno dialogowe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "CaptureDialog";
            this.Text = "CaptureDialog";
            this.TransparencyKey = System.Drawing.Color.LimeGreen;
            this.Move += new System.EventHandler(this.CaptureDialog_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureDialog_FormClosing);
            this.Resize += new System.EventHandler(this.CaptureDialog_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
    }
}