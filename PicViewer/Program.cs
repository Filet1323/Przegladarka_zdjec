using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace picViewer_NS
{
    static class Program
    {
        /// <summary>
        ///
        /// Prosta przeglądarka obrazów, która umożliwia przeglądanie wielu obrazów i przenoszenie ich w obszarze roboczym.
        /// 
        /// Przydatne, jeśli musisz porównać wiele obrazów lub części obrazu razem.
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PicViewerForm());
        }
    }
}
