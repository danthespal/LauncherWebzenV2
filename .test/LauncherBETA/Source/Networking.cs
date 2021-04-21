using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace LauncherKG.Source
{
    internal class Networking
    {
        public static void CheckNetwork()
        {
            Common.ChangeStatus("CONNECTING");
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(Networking.BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Networking.BackgroundWorker_RunWorkerCompleted);
            if (backgroundWorker.IsBusy)
            {
                int num = (int) MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object) "CheckNetwork isBusy"), Import.windowName);
                Application.Exit();
            }
            else
                backgroundWorker.RunWorkerAsync();
        }

        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType) 3072;
            try
            {
                new WebClient().OpenRead(Import.UpdateURL);
                e.Result = (object) true;
            }
            catch
            {
                e.Result = (object) false;
            }
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Convert.ToBoolean(e.Result))
            {
                int num = (int) MessageBox.Show(Texts.GetText("NONETWORK"), Import.windowName);
                Application.Exit();
            }
            else
                ListDownloader.DownloadList();
        }
    }
}
