using Cyclic.Redundancy.Check;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LauncherKG.Source
{
    internal class Common
    {
        public const int WM_NCLBUTTONDOWN = 161;
        public const int HT_CAPTION = 2;

        public static void ChangeStatus(string Key, params string[] Arguments) => Import.gMain.Status.Text = Texts.GetText(Key, (object[]) Arguments);

        public static void UpdateCompleteProgress(float fPercent)
        {
            float num = (float) (617.0 * ((double) fPercent / 100.0) + 1.5 * Math.Sin((double) DateTime.Now.Ticks / 100.0));
            if ((double) num < 0.0 || (double) fPercent < 0.00999999977648258)
                num = 0.0f;
            if ((double) num > 617.0 || (double) fPercent > 99.9899978637695)
                num = 0.0f;
            Import.gMain.Background.Update();
            Import.gMain.Background.Width = (int) num;
        }

        public static void UpdateCompleteProgress(long Value)
        {
            if (Value < 0L)
            {
                return;
            }
        }

        public static void UpdateCurrentProgress(long Value, double Speed)
        {
            if (Value < 0L || Value > 100L)
                return;
            Common.UpdateCompleteProgress((float) Value);
        }

        public static string GetHash(string Name)
        {
            if (Name == string.Empty)
                return string.Empty;
            CRC crc = new CRC();
            string empty = string.Empty;
            using (FileStream fileStream = File.Open(Name, FileMode.Open))
            {
                foreach (byte num in crc.ComputeHash((Stream) fileStream))
                    empty += num.ToString("x2").ToUpper();
            }
            return empty;
        }

        public static void EnableStart()
        {
            Import.gMain.Btn_Start.Enabled = true;
            Import.gMain.Btn_Options.Enabled = true;
            Import.gMain.Btn_WindowMode.Enabled = true;
            Import.gMain.Btn_HomePage.Enabled = true;
            Import.gMain.Btn_Minimize.Enabled = true;
            Import.gMain.Btn_Start.Cursor = Cursors.Hand;
            Import.FalseStance = true;
        }

        public static Image M108(Image source, int Width, int Height, int dx, int dy)
        {
            RectangleF rectangleF = new RectangleF(0.0f, 0.0f, (float) source.Width, (float) source.Height);
            RectangleF rect = new RectangleF(0.0f, 0.0f, (float) Width, (float) Height);
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage((Image) bitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.FillRectangle((Brush) new SolidBrush(Color.White), rect);
            if ((double) source.Width / (double) source.Height >= 1.0)
            {
                float num1 = (float) Width / rectangleF.Width;
                float height = rectangleF.Height * num1;
                float num2 = (float) Height - height;
                graphics.DrawImage(source, 0.0f, num2 / 2f, (float) Width, height);
                return (Image) bitmap;
            }
            float num3 = (float) Height / rectangleF.Height;
            float width = rectangleF.Width * num3;
            float num4 = (float) Width - width;
            graphics.DrawImage(source, num4 / 2f, 0.0f, width, (float) Height);
            return (Image) bitmap;
        }

        public static void M109(string newText, string fileName, int line_to_edit)
        {
            string[] contents = File.ReadAllLines(fileName);
            contents[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, contents);
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern bool ReleaseCapture();
    }
}
