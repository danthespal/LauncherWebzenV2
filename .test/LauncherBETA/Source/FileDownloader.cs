using LauncherKG.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;

namespace LauncherKG.Source
{
    internal class FileDownloader
    {
        private static Stopwatch stopWatch = new Stopwatch();
        private static int curlFile;
        private static long lastBytes;
        private static long currentBytes;

        public static void DownloadFiles()
        {
            if (Import.OldFiles.Count <= 0)
            {
                Common.ChangeStatus("CHECKCOMPLETE");
                Import.gMain.Btn_Start.BackgroundImage = (Image) Resources.start_1;
                Common.EnableStart();
            }
            else if (FileDownloader.curlFile >= Import.OldFiles.Count)
            {
                Common.ChangeStatus("DOWNLOADCOMPLETE");
                Import.gMain.Btn_Start.BackgroundImage = (Image) Resources.start_1;
                Common.EnableStart();
            }
            else
            {
                string path = string.Format("{0}\\{1}", (object) Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), (object) Path.GetDirectoryName(Import.OldFiles[FileDownloader.curlFile]));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(FileDownloader.WebClient_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloader.WebClient_DownloadFileCompleted);
                FileDownloader.stopWatch.Start();
                webClient.DownloadFileAsync(new Uri(Import.UpdateURL + Import.OldFiles[FileDownloader.curlFile]), Import.OldFiles[FileDownloader.curlFile].Remove(Import.OldFiles[FileDownloader.curlFile].Length - 4, 4));
            }
        }

        private static void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            FileDownloader.currentBytes = FileDownloader.lastBytes + e.BytesReceived;
            Common.ChangeStatus("DOWNLOADFILE", Import.OldFiles[FileDownloader.curlFile].Remove(Import.OldFiles[FileDownloader.curlFile].Length - 4, 4));
            Common.UpdateCompleteProgress(Computer.Compute(Import.completeSize + FileDownloader.currentBytes));
            Common.UpdateCurrentProgress((long) e.ProgressPercentage, Computer.ComputeDownloadSpeed((double) e.BytesReceived, FileDownloader.stopWatch));
        }

        private static void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            FileDownloader.lastBytes = FileDownloader.currentBytes;
            Common.UpdateCurrentProgress(100L, 0.0);
            ++FileDownloader.curlFile;
            FileDownloader.stopWatch.Reset();
            FileDownloader.DownloadFiles();
        }
    }
}
