using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedReaction_07072018
{
    static class Program
    {
        /// <summary>
        /// Научился продумывать программу перед тем как ее садиться писать, тк раньше я делал наоборот, садился кодить, а потом думал, что было очень долго и не оптимально
        /// The main entry point for the application.
        /// все понятно, спасибо
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormReaction());
        }
    }
}
