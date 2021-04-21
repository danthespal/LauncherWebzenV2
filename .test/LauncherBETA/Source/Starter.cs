using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LauncherKG.Source
{
    internal class Starter
    {
        public static void Start()
        {
            if (!File.Exists(Import.ExecutableName))
            {
                int num1 = (int) MessageBox.Show(Texts.GetText("MISSINGBINARY", (object) Import.ExecutableName), Import.windowName);
            }
            else
            {
                try
                {
                    Process.Start(Import.ExecutableName);
                    Import.gMain.WindowState = FormWindowState.Minimized;
                    Thread.Sleep(5000);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    int num2 = (int) MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object) ex.Message), Import.windowName);
                    Application.Exit();
                }
            }
        }
    }
}
