// FileChecker.cs
// decrypted by Arsenic for KG-Emulator

using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace LauncherWebzenV2.Source
{
    internal class FileChecker
    {
        private static readonly BackgroundWorker backgroundWorker = new BackgroundWorker();

        public static void CheckFiles()
        {
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            
            if (backgroundWorker.IsBusy)
            {
                int num = (int)MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object)"CheckFiles isBusy"));
                Application.Exit();
            }
            else
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Import.File file in Import.Files)
            {
                Import.fullSize += file.Size;
                backgroundWorker.ReportProgress(0, Path.GetFileName(file.Name));
                
                if (!File.Exists(file.Name) || string.Compare(Common.GetHash(file.Name), file.Hash) != 0)
                {
                    Import.OldFiles.Add(file.Name);
                }
                else
                {
                    Import.completeSize += file.Size;
                    backgroundWorker.ReportProgress(1);
                }
            }
        }

        private static void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
