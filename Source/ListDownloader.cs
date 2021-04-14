// ListDownloader.cs
// decrypted by Arsenic for KG-Emulator

using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace LauncherWebzenV2.Source
{
    internal class ListDownloader
    {
        public static void DownloadList()
        {
            Common.ChangeStatus("LISTDOWNLOAD");
            Common.DisableStart();
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            
            if (backgroundWorker.IsBusy)
            {
                int num = (int)MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object)"DownloadList isBusy"));
                Application.Exit();
            }
            else
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamReader streamReader = new StreamReader(new WebClient().OpenRead(Import.ServerURL + Import.PatchlistName));
            while (!streamReader.EndOfStream)
            {
                ListProcessor.AddFile(streamReader.ReadLine());
            }
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FileChecker.CheckFiles();
        }
    }
}
