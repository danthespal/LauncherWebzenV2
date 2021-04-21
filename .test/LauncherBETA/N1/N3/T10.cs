// Decompiled with JetBrains decompiler
// Type: N1.N3.T10
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using System;
using System.Collections.Generic;

namespace N1.N3
{
  public class T10 : ICloneable
  {
    private List<string> F28 = new List<string>();
    private IEqualityComparer<string> F29;
    private List<string> F30;
    private T9 F31;
    private string F32;

    public T10(string sectionName)
      : this(sectionName, (IEqualityComparer<string>) EqualityComparer<string>.Default)
    {
    }

    public T10(string sectionName, IEqualityComparer<string> searchComparer)
    {
      this.F29 = searchComparer;
      if (string.IsNullOrEmpty(sectionName))
        throw new ArgumentException("section name can not be empty");
      this.F30 = new List<string>();
      this.F31 = new T9(this.F29);
      this.P37 = sectionName;
    }

    public T10(T10 ori, IEqualityComparer<string> searchComparer = null)
    {
      this.P37 = ori.P37;
      this.F29 = searchComparer;
      this.F30 = new List<string>((IEnumerable<string>) ori.F30);
      this.F31 = new T9(ori.F31, searchComparer ?? ori.F29);
    }

    public void M31() => this.P41.M23();

    public void M32() => this.P41.M27();

    public void M33(T10 toMergeSection)
    {
    }

    public string P37
    {
      get => this.F32;
      set
      {
        if (string.IsNullOrEmpty(value))
          return;
        this.F32 = value;
      }
    }

    [Obsolete("Do not use this property, use property Comments instead")]
    public List<string> P38
    {
      get => this.F30;
      internal set => this.F30 = new List<string>((IEnumerable<string>) value);
    }

    public List<string> P39 => this.F30;

    [Obsolete("Do not use this property, use property Comments instead")]
    public List<string> P40
    {
      get => this.F28;
      internal set => this.F28 = new List<string>((IEnumerable<string>) value);
    }

    public T9 P41
    {
      get => this.F31;
      set => this.F31 = value;
    }

    public object Clone() => (object) new T10(this);
  }
}
