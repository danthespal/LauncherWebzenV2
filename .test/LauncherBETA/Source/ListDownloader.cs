using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace LauncherKG.Source
{
    internal class ListDownloader
    {
        public static void DownloadList()
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            Common.ChangeStatus("LISTDOWNLOAD");
            backgroundWorker.DoWork += new DoWorkEventHandler(ListDownloader.BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ListDownloader.BackgroundWorker_RunWorkerCompleted);
            if (backgroundWorker.IsBusy)
            {
                int num = (int) MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object) "DownloadList isBusy"), Import.windowName);
                Application.Exit();
            }
            else
                backgroundWorker.RunWorkerAsync();
        }

        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamReader streamReader = new StreamReader(new WebClient().OpenRead(Import.UpdateURL + Import.PatchlistName));
            while (!streamReader.EndOfStream)
                ListProcessor.AddFile(streamReader.ReadLine());
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => FileChecker.CheckFiles();
    }
}
