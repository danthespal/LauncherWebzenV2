// Decompiled with JetBrains decompiler
// Type: N1.N7.T18
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using System;
using System.Reflection;

namespace N1.N7
{
  public class T18 : Exception
  {
    public T18(string msg)
      : this(msg, 0, string.Empty, (Exception) null)
    {
    }

    public T18(string msg, Exception innerException)
      : this(msg, 0, string.Empty, innerException)
    {
    }

    public T18(string msg, int lineNumber, string lineValue)
      : this(msg, lineNumber, lineValue, (Exception) null)
    {
    }

    public T18(string msg, int lineNumber, string lineValue, Exception innerException)
      : base(string.Format("{0} while parsing line number {1} with value '{2}' - IniParser version: {3}", (object) msg, (object) lineNumber, (object) lineValue, (object) Assembly.GetExecutingAssembly().GetName().Version), innerException)
    {
      this.P66 = Assembly.GetExecutingAssembly().GetName().Version;
      this.P67 = lineNumber;
      this.P68 = lineValue;
    }

    public Version P66 { get; private set; }

    public int P67 { get; private set; }

    public string P68 { get; private set; }
  }
}
