// Program.cs
// decrypted by Arsenic for KG-Emulator

using System;
using System.Windows.Forms;

namespace LauncherWebzenV2
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
