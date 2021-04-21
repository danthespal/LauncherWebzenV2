// Decompiled with JetBrains decompiler
// Type: N1.T3
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using N1.N2;
using N1.N3;
using System;

namespace N1
{
  [Obsolete("Use class IniDataParser instead. See remarks comments in this class.")]
  public class T3
  {
    public T3()
      : this(new T5())
    {
    }

    public T3(T5 parser) => this.P22 = parser;

    public T5 P22 { get; protected set; }

    public T6 M9(string dataStr) => this.P22.M11(dataStr);

    public string M10(T6 iniData) => iniData.ToString();
  }
}
