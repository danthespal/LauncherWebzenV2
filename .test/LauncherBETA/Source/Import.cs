using System.Collections.Generic;

namespace LauncherKG.Source
{
    internal class Import
    {
        //public static string F98 = "0";
        public static string launcherName = "PTYNetwork.com Launcher";
        public static string UpdateURL = "";
        public static string HomeURL = "";
        //public static string F102 = "";
        public static string PatchlistName = "update.txt";
        public static string ExecutableName = "Main.exe";
        public static string windowName = "Launcher";
        public static bool FalseStance = false;
        public static bool Stance = false;
        public static List<Import.File> Files = new List<Import.File>();
        public static List<string> OldFiles = new List<string>();
        public static Main gMain;
        public static long fullSize;
        public static long completeSize;

        public struct File
        {
            public string Name;
            public string Hash;
        }
    }
}
