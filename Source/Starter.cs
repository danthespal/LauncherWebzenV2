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
                _ = (int)MessageBox.Show(Texts.GetText("MISSINGBINARY", Import.ExecutableName));
                Common.EnableStart();
            }
            else
            {
                try
                {
                    if (Import.MutexName != "")
                    {
                        Import.Mutex = new Mutex(false, Import.MutexName);
                    }

                    Process process = new Process();
                    process.StartInfo.FileName = Import.ExecutableName;
                    process.StartInfo.UseShellExecute = true;
                    _ = process.Start();
                    _ = process.WaitForExit(2000);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    _ = (int)MessageBox.Show(Texts.GetText("UNKNOWNERROR", ex.Message));
                    Application.Exit();
                }
            }
        }
    }
}
