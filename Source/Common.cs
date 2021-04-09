// Common.cs
// decrypted by Arsenic for KG-Emulator

using Cyclic.Redundancy.Check;
using LauncherWebzenV2.Properties;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LauncherWebzenV2.Source
{
    internal class Common
    {
        public static void ChangeStatus(string Key, params string[] Arguments) => Import.gMain.Status.Text = Texts.GetText(Key, (object[]) Arguments);

        public static void UpdateCompleteProgress(long Value)
        {
            if (Value < 0L || Value > 100L)
                return;
            
            Import.gMain.completeProgressText.Text = Texts.GetText("COMPLETEPROGRESS", (object) Value);
            float num = (float) (650.0 * ((double) Value / 100.0));
            Import.gMain.completeBar.Width = (int) num;
            Import.gMain.UpdatePanel.Update();
        }

        public static void UpdateCurrentProgress(long Value, double Speed)
        {
            if (Value < 0L || Value > 100L)
                return;
            
            Import.gMain.currentProgressText.Text = Texts.GetText("CURRENTPROGRESS", (object) Value);
            float num = (float) (650.0 * ((double) Value / 100.0));
            Import.gMain.currentBar.Width = (int) num;
        }

        public static string GetHash(string Name)
        {
            if (Name == string.Empty)
                return string.Empty;
            
            CRC crc = new CRC();
            
            string empty = string.Empty;

            using (FileStream fileStream = System.IO.File.Open(Name, FileMode.Open))
            {
                foreach (byte num in crc.ComputeHash((Stream) fileStream))
                empty += num.ToString("x2").ToLower();
            }
            return empty;
        }

        public static void EnableStart()
        {
            Import.gMain.Btn_Run.BackgroundImage = (Image) Resources.Jugar_n;
            Import.gMain.Btn_Run.Enabled = true;
            Import.gMain.Btn_Run.Cursor = Cursors.Hand;
        }

        public static void DisableStart()
        {
            Import.gMain.Btn_Run.BackgroundImage = (Image) Resources.Jugar_d;
            Import.gMain.Btn_Run.Enabled = false;
            Import.gMain.Btn_Run.Cursor = Cursors.Default;
        }
    }
}
