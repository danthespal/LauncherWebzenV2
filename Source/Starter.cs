// Starter.cs
// decrypted by Arsenic for KG-Emulator

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace LauncherWebzenV2.Source
{
    internal class Starter
    {
        public static void Start()
        {
            if (!System.IO.File.Exists(Import.ExecutableName))
            {
                int num = (int) MessageBox.Show(Texts.GetText("MISSINGBINARY", (object) Import.ExecutableName));
                Common.EnableStart();
            }
            else
            {
                try
                {
                    if (Import.MutexName != "")
                        Import.Mutex = new Mutex(false, Import.MutexName);
                    Process process = new Process();
                    process.StartInfo.FileName = Import.ExecutableName;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                    process.WaitForExit(2000);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    int num = (int) MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object) ex.Message));
                    Application.Exit();
                }
            }
        }
    }
}
