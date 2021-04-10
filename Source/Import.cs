// Import.cs
// decrypted by Arsenic for KG-Emulator

using System.Collections.Generic;
using System.Threading;

namespace LauncherWebzenV2.Source
{
    internal class Import
    {
        public static string LauncherInfo = ".\\LauncherInfo.bmd";
        public static string ServerURL = "";
        public static string PatchlistName = "";
        public static string ExecutableName = "";
        public static string MutexName = "";
        public static Mutex Mutex = (Mutex) null;
        public static string webPanelURL = "";
        public static string windowName = "Mu Launcher - KG-Emulator";
        public static int LauncherLanguage = 0;
        public static Main gMain;
        public static List<Import.File> Files = new List<Import.File>();
        public static List<string> OldFiles = new List<string>();
        public static long fullSize;
        public static long completeSize;
        public static IDictionary<string, string> Lang = (IDictionary<string, string>) new Dictionary<string, string>()
        {
            {
              "Eng",
              "English"
            },
            {
              "Spn",
              "Español"
            },
            {
              "Por",
              "Português"
            }
        };
        public static IDictionary<int, string> Resolution = (IDictionary<int, string>) new Dictionary<int, string>()
        {
          {
            0,
            "640x480"
          },
          {
            1,
            "800x600"
          },
          {
            2,
            "1024x768"
          },
          {
            3,
            "1280x1024"
          },
          {
            4,
            "1366x768"
          },
          {
            5,
            "1440x900"
          },
          {
            6,
            "1600x900"
          },
          {
            7,
            "1680x1050"
          },
          {
            8,
            "1920x1080"
          }
        };

        public struct File
        {
            public string Name;
            public string Hash;
            public long Size;
        }
    }
}
