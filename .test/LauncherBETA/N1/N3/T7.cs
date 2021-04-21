// Decompiled with JetBrains decompiler
// Type: N1.N3.T7
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using System;
using System.Collections.Generic;

namespace N1.N3
{
  public class T7 : T6
  {
    public T7()
      : base(new T11((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase))
    {
      this.P28 = new T9((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    }

    public T7(T11 sdc)
      : base(new T11(sdc, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase))
    {
      this.P28 = new T9((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    }

    public T7(T6 ori)
      : this(new T11(ori.P30, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase))
    {
      this.P28 = (T9) ori.P28.Clone();
      this.P27 = ori.P27.M46();
    }
  }
}
