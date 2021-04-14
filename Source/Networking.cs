// Networking.cs
// decrypted by Arsenic for KG-Emulator

using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace LauncherWebzenV2.Source
{
    internal class Networking
    {
        public static void CheckNetwork()
        {
            Common.ChangeStatus("CONNECTING");
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            
            if (backgroundWorker.IsBusy)
            {
                int num = (int)MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object)"CheckNetwork isBusy"));
                Application.Exit();
            }
            else
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _ = new WebClient().OpenRead(Import.ServerURL + Import.PatchlistName);
                e.Result = true;
            }
            catch
            {
                e.Result = false;
            }
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Convert.ToBoolean(e.Result))
            {
                _ = (int)MessageBox.Show(Texts.GetText("NONETWORK"));
                Application.Exit();
            }
            else
            {
                Common.ChangeStatus("CONNECTED");
                Common.EnableStart();
            }
        }
    }
}
