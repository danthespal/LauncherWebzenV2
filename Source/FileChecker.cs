// FileChecker.cs
// decrypted by Arsenic for KG-Emulator

using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace LauncherWebzenV2.Source
{
    internal class FileChecker
    {
        private static BackgroundWorker backgroundWorker = new BackgroundWorker();

        public static void CheckFiles()
        {
            FileChecker.backgroundWorker.WorkerReportsProgress = true;
            FileChecker.backgroundWorker.DoWork += new DoWorkEventHandler(FileChecker.backgroundWorker_DoWork);
            FileChecker.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(FileChecker.backgroundWorker_ProgressChanged);
            FileChecker.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FileChecker.backgroundWorker_RunWorkerCompleted);
            
            if (FileChecker.backgroundWorker.IsBusy)
            {
                int num = (int) MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object) "CheckFiles isBusy"));
                Application.Exit();
            }
            else
                FileChecker.backgroundWorker.RunWorkerAsync();
        }

        private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Import.File file in Import.Files)
            {
                Import.fullSize += file.Size;
                FileChecker.backgroundWorker.ReportProgress(0, (object) Path.GetFileName(file.Name));
                
                if (!System.IO.File.Exists(file.Name) || string.Compare(Common.GetHash(file.Name), file.Hash) != 0)
                {
                    Import.OldFiles.Add(file.Name);
                }
                else
                {
                    Import.completeSize += file.Size;
                    FileChecker.backgroundWorker.ReportProgress(1);
                }
            }
        }

        private static void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                Common.ChangeStatus("CHECKFILE", e.UserState.ToString());
            }
            else
            {
                Common.UpdateCompleteProgress(Computer.Compute(Import.completeSize));
                Common.UpdateCurrentProgress(Computer.Compute(Import.completeSize), 0.0);
            }
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FileDownloader.DownloadFile();
        }

        private enum State
        {
            REPORT_NAME,
            REPORT_PROGRESS,
        }
    }
}
