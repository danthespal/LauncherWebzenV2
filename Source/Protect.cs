// Protect.cs
// decrypted by Arsenic for KG-Emulator

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LauncherWebzenV2.Source
{
    internal class Protect
    {
        public static void ReadInfo()
        {
            Common.ChangeStatus("READINGINFO");
            Common.DisableStart();
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            
            if (backgroundWorker.IsBusy)
            {
                _ = (int)MessageBox.Show(Texts.GetText("READINFOERROR"));
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
                string[] strArray = System.IO.File.Exists(Import.LauncherInfo) ? Regex.Split(SecureStringManager.Decrypt(System.IO.File.ReadAllText(Import.LauncherInfo), "WhyAreYouReadingThis"), "\r\n") : throw new Exception(Texts.GetText("READINFOERROR"));
                Import.ServerURL = strArray[0];
                Import.PatchlistName = strArray[1];
                Import.ExecutableName = strArray[2];
                Import.MutexName = strArray[3];
                Import.webPanelURL = strArray[4];
                Import.windowName = strArray[5];
            }
            catch (Exception ex)
            {
                _ = (int)MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Common.ChangeStatus("READINFOCOMPLETE");
            Networking.CheckNetwork();
        }
    }
}
