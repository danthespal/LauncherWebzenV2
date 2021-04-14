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
        private static readonly Stopwatch stopWatch = new Stopwatch();

        public static void DownloadFile()
        {
            if (Import.OldFiles.Count <= 0)
            {
                Common.ChangeStatus("CHECKCOMPLETE");
                Common.UpdateCurrentProgress(100L, 0.0);
                Common.UpdateCompleteProgress(100L);
                Starter.Start();
            }
            else if (curFile >= Import.OldFiles.Count)
            {
                Common.ChangeStatus("DOWNLOADCOMPLETE");
                Common.UpdateCurrentProgress(100L, 0.0);
                Common.UpdateCompleteProgress(100L);
                Starter.Start();
            }
            else
            {
                if (Import.OldFiles[curFile].Contains("/"))
                {
                    _ = Directory.CreateDirectory(Path.GetDirectoryName(Import.OldFiles[curFile]));
                }

                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClient_DownloadFileCompleted);
                stopWatch.Start();
                Common.ChangeStatus("DOWNLOADFILE", Import.OldFiles[curFile]);
                webClient.DownloadFileAsync(new Uri(Import.ServerURL + Import.OldFiles[curFile]), Import.OldFiles[curFile]);
            }
        }

        private static void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            currentBytes = lastBytes + e.BytesReceived;
            Common.UpdateCompleteProgress(Computer.Compute(Import.completeSize + currentBytes));
            Common.UpdateCurrentProgress(e.ProgressPercentage, Computer.ComputeDownloadSpeed(e.BytesReceived, stopWatch));
        }

        private static void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lastBytes = currentBytes;
            Common.UpdateCurrentProgress(100L, 0.0);
            ++curFile;
            stopWatch.Reset();
            DownloadFile();
        }
    }
}
