// FileDownloader.cs
// decrypted by Arsenic for KG-Emulator

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace LauncherWebzenV2.Source
{
    internal class FileDownloader
    {
        private static int curFile;
        private static long lastBytes;
        private static long currentBytes;
        private static Stopwatch stopWatch = new Stopwatch();

        public static void DownloadFile()
        {
            if (Import.OldFiles.Count <= 0)
            {
                Common.ChangeStatus("CHECKCOMPLETE");
                Common.UpdateCurrentProgress(100L, 0.0);
                Common.UpdateCompleteProgress(100L);
                Starter.Start();
            }
            else if (FileDownloader.curFile >= Import.OldFiles.Count)
            {
                Common.ChangeStatus("DOWNLOADCOMPLETE");
                Common.UpdateCurrentProgress(100L, 0.0);
                Common.UpdateCompleteProgress(100L);
                Starter.Start();
            }
            else
            {
                if (Import.OldFiles[FileDownloader.curFile].Contains("/"))
                    Directory.CreateDirectory(Path.GetDirectoryName(Import.OldFiles[FileDownloader.curFile]));
                
                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(FileDownloader.webClient_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloader.webClient_DownloadFileCompleted);
                FileDownloader.stopWatch.Start();
                Common.ChangeStatus("DOWNLOADFILE", Import.OldFiles[FileDownloader.curFile]);
                webClient.DownloadFileAsync(new Uri(Import.ServerURL + Import.OldFiles[FileDownloader.curFile]), Import.OldFiles[FileDownloader.curFile]);
            }
        }

        private static void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            FileDownloader.currentBytes = FileDownloader.lastBytes + e.BytesReceived;
            Common.UpdateCompleteProgress(Computer.Compute(Import.completeSize + FileDownloader.currentBytes));
            Common.UpdateCurrentProgress((long) e.ProgressPercentage, Computer.ComputeDownloadSpeed((double) e.BytesReceived, FileDownloader.stopWatch));
        }

        private static void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            FileDownloader.lastBytes = FileDownloader.currentBytes;
            Common.UpdateCurrentProgress(100L, 0.0);
            ++FileDownloader.curFile;
            FileDownloader.stopWatch.Reset();
            FileDownloader.DownloadFile();
        }
    }
}
