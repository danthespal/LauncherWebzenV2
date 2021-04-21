// Decompiled with JetBrains decompiler
// Type: N1.N3.T11
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace N1.N3
{
  [DefaultMember("Item")]
  public class T11 : IEnumerable<T10>, IEnumerable, ICloneable
  {
    private IEqualityComparer<string> F33;
    private readonly Dictionary<string, T10> F34;

    public T11()
      : this((IEqualityComparer<string>) EqualityComparer<string>.Default)
    {
    }

    public T11(IEqualityComparer<string> searchComparer)
    {
      this.F33 = searchComparer;
      this.F34 = new Dictionary<string, T10>(this.F33);
    }

    public T11(T11 ori, IEqualityComparer<string> searchComparer)
    {
      this.F33 = searchComparer ?? (IEqualityComparer<string>) EqualityComparer<string>.Default;
      this.F34 = new Dictionary<string, T10>(this.F33);
      foreach (T10 t10 in ori)
        this.F34.Add(t10.P37, (T10) t10.Clone());
    }

    public int P42 => this.F34.Count;

    public T9 get_Item(string sectionName) => this.F34.ContainsKey(sectionName) ? this.F34[sectionName].P41 : (T9) null;

    public bool M34(string keyName)
    {
      if (this.M37(keyName))
        return false;
      this.F34.Add(keyName, new T10(keyName, this.F33));
      return true;
    }

    public void M35(T10 data)
    {
      if (this.M37(data.P37))
        this.M40(data.P37, new T10(data, this.F33));
      else
        this.F34.Add(data.P37, new T10(data, this.F33));
    }

    public void M36() => this.F34.Clear();

    public bool M37(string keyName) => this.F34.ContainsKey(keyName);

    public T10 M38(string sectionName) => this.F34.ContainsKey(sectionName) ? this.F34[sectionName] : (T10) null;

    public void M39(T11 sectionsToMerge)
    {
      foreach (T10 t10 in sectionsToMerge)
      {
        if (this.M38(t10.P37) == null)
          this.M34(t10.P37);
        this.get_Item(t10.P37).M26(t10.P41);
      }
    }

    public void M40(string sectionName, T10 data)
    {
      if (data == null)
        return;
      this.F34[sectionName] = data;
    }

    public bool M41(string keyName) => this.F34.Remove(keyName);

    public IEnumerator<T10> GetEnumerator()
    {
      foreach (string key in this.F34.Keys)
        yield return this.F34[key];
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public object Clone() => (object) new T11(this, this.F33);
  }
}
