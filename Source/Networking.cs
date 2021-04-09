// Networking.cs
// decrypted by Arsenic for KG-Emulator

using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace LauncherWebzenV2.Source
{
  internal class Networking
  {
    public static void CheckNetwork()
    {
      Common.ChangeStatus("CONNECTING");
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(Networking.backgroundWorker_DoWork);
      backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Networking.backgroundWorker_RunWorkerCompleted);
      if (backgroundWorker.IsBusy)
      {
        int num = (int) MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object) "CheckNetwork isBusy"));
        Application.Exit();
      }
      else
        backgroundWorker.RunWorkerAsync();
    }

    private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        new WebClient().OpenRead(Import.ServerURL + Import.PatchlistName);
        e.Result = (object) true;
      }
      catch
      {
        e.Result = (object) false;
      }
    }

    private static void backgroundWorker_RunWorkerCompleted(
      object sender,
      RunWorkerCompletedEventArgs e)
    {
      if (!Convert.ToBoolean(e.Result))
      {
        int num = (int) MessageBox.Show(Texts.GetText("NONETWORK"));
        Application.Exit();
      }
      else
      {
        Common.ChangeStatus("CONNECTED");
        Common.EnableStart();
      }
    }
  }
}
