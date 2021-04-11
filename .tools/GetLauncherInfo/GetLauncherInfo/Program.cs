// Program.cs
// decrypted by Arsenic for KG-Emulator

using ConfigCreator;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace GetLauncherInfo
{
    internal class Program
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static string IniReadValue(string Key)
        {
            string filePath = Environment.CurrentDirectory + "\\GetLauncherInfo.ini";
            StringBuilder retVal = new StringBuilder((int)byte.MaxValue);
            Program.GetPrivateProfileString("LauncherInfo", Key, "", retVal, (int)byte.MaxValue, filePath);
            return retVal.ToString();
        }

        private static void Main(string[] args)
        {
            try
            {
                File.WriteAllText(Environment.CurrentDirectory + "\\LauncherInfo.bmd", SecureStringManager.Encrypt(Program.IniReadValue("ServerURL") + "\r\n" + Program.IniReadValue("PatchlistName") + "\r\n" + Program.IniReadValue("ExecutableName") + "\r\n" + Program.IniReadValue("MutexName") + "\r\n" + Program.IniReadValue("WebPanelURL") + "\r\n" + Program.IniReadValue("LauncherWindowName"), "WhyAreYouReadingThis"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
