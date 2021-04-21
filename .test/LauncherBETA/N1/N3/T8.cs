// Decompiled with JetBrains decompiler
// Type: N1.N3.T8
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using System;
using System.Collections.Generic;

namespace N1.N3
{
  public class T8 : ICloneable
  {
    private List<string> F23;
    private string F24;
    private string F25;

    public T8(string keyName)
    {
      if (string.IsNullOrEmpty(keyName))
        throw new ArgumentException("key name can not be empty");
      this.F23 = new List<string>();
      this.F24 = string.Empty;
      this.F25 = keyName;
    }

    public T8(T8 ori)
    {
      this.F24 = ori.F24;
      this.F25 = ori.F25;
      this.F23 = new List<string>((IEnumerable<string>) ori.F23);
    }

    public List<string> P32
    {
      get => this.F23;
      set => this.F23 = new List<string>((IEnumerable<string>) value);
    }

    public string P33
    {
      get => this.F24;
      set => this.F24 = value;
    }

    public string P34
    {
      get => this.F25;
      set
      {
        if (!(value != string.Empty))
          return;
        this.F25 = value;
      }
    }

    public object Clone() => (object) new T8(this);
  }
}
