using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace LauncherKG.Source
{
    internal class FileChecker
    {
        private static BackgroundWorker backgroundWorker = new BackgroundWorker();

        public static void CheckFiles()
        {
            FileChecker.backgroundWorker.WorkerReportsProgress = true;
            FileChecker.backgroundWorker.DoWork += new DoWorkEventHandler(FileChecker.BackgroundWorker_DoWork);
            FileChecker.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(FileChecker.BackgroundWorker_ProgressChanged);
            FileChecker.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FileChecker.BackgroundWorker_RunWorkerCompleted);
            if (FileChecker.backgroundWorker.IsBusy)
            {
                int num = (int) MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object) "CheckFiles isBusy"), Import.windowName);
                Application.Exit();
            }
            else
                FileChecker.backgroundWorker.RunWorkerAsync();
        }

        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Import.File file in Import.Files)
            {
                ++Import.fullSize;
                FileChecker.backgroundWorker.ReportProgress(0, (object) Path.GetFileName(file.Name));
                if (file.Name.ToLower().Contains("launcher.exe") || file.Name.ToLower().Contains("mu.exe"))
                {
                    ++Import.completeSize;
                    FileChecker.backgroundWorker.ReportProgress(1);
                }
                else if (!File.Exists(file.Name.Remove(file.Name.Length - 4, 4)) || Common.GetHash(file.Name.Remove(file.Name.Length - 4, 4)) != file.Hash)
                {
                    Import.OldFiles.Add(file.Name);
                }
                else
                {
                    ++Import.completeSize;
                    FileChecker.backgroundWorker.ReportProgress(1);
                }
            }
        }

        private static void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
                Common.ChangeStatus("CHECKFILE");
            else
                Common.UpdateCompleteProgress(Computer.Compute(Import.completeSize));
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => FileDownloader.DownloadFiles();

        private enum State
        {
            REPORT_NAME,
            REPORT_PROGRESS,
        }
    }
}
