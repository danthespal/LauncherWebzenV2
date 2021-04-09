// Decompiled with JetBrains decompiler
// Type: LauncherWebzenV2.Program
// Assembly: LauncherWebzenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE99EB13-A342-49B7-BE94-B9FF93247050
// Assembly location: D:\Git\MuOnlineLauncher\Webzen\LauncherWebzenV2\Cliente\LauncherWebzenV2.exe

using System;
using System.Windows.Forms;

namespace LauncherWebzenV2
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((Form) new LauncherWebzenV2.Main());
        }
    }
}
