// Decompiled with JetBrains decompiler
// Type: N1.N3.T9
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
  public class T9 : IEnumerable<T8>, IEnumerable, ICloneable
  {
    private IEqualityComparer<string> F26;
    private readonly Dictionary<string, T8> F27;

    public T9()
      : this((IEqualityComparer<string>) EqualityComparer<string>.Default)
    {
    }

    public T9(IEqualityComparer<string> searchComparer)
    {
      this.F26 = searchComparer;
      this.F27 = new Dictionary<string, T8>(this.F26);
    }

    public T9(T9 ori, IEqualityComparer<string> searchComparer)
      : this(searchComparer)
    {
      foreach (T8 t8 in ori)
      {
        if (this.F27.ContainsKey(t8.P34))
          this.F27[t8.P34] = (T8) t8.Clone();
        else
          this.F27.Add(t8.P34, (T8) t8.Clone());
      }
    }

    public string get_Item(string keyName) => this.F27.ContainsKey(keyName) ? this.F27[keyName].P33 : (string) null;

    public void set_Item(string keyName, string value)
    {
      if (!this.F27.ContainsKey(keyName))
        this.M19(keyName);
      this.F27[keyName].P33 = value;
    }

    public int P36 => this.F27.Count;

    public bool M19(string keyName)
    {
      if (this.F27.ContainsKey(keyName))
        return false;
      this.F27.Add(keyName, new T8(keyName));
      return true;
    }

    [Obsolete("Pottentially buggy method! Use AddKey(KeyData keyData) instead (See comments in code for an explanation of the bug)")]
    public bool M20(string keyName, T8 keyData)
    {
      if (!this.M19(keyName))
        return false;
      this.F27[keyName] = keyData;
      return true;
    }

    public bool M21(T8 keyData)
    {
      if (!this.M19(keyData.P34))
        return false;
      this.F27[keyData.P34] = keyData;
      return true;
    }

    public bool M22(string keyName, string keyValue)
    {
      if (!this.M19(keyName))
        return false;
      this.F27[keyName].P33 = keyValue;
      return true;
    }

    public void M23()
    {
      foreach (T8 t8 in this)
        t8.P32.Clear();
    }

    public bool M24(string keyName) => this.F27.ContainsKey(keyName);

    public T8 M25(string keyName) => this.F27.ContainsKey(keyName) ? this.F27[keyName] : (T8) null;

    public void M26(T9 keyDataToMerge)
    {
      foreach (T8 t8 in keyDataToMerge)
      {
        this.M19(t8.P34);
        this.M25(t8.P34).P32.AddRange((IEnumerable<string>) t8.P32);
        this.set_Item(t8.P34, t8.P33);
      }
    }

    public void M27() => this.F27.Clear();

    public bool M28(string keyName) => this.F27.Remove(keyName);

    public void M29(T8 data)
    {
      if (data == null)
        return;
      if (this.F27.ContainsKey(data.P34))
        this.M28(data.P34);
      this.M21(data);
    }

    public IEnumerator<T8> GetEnumerator()
    {
      foreach (string key in this.F27.Keys)
        yield return this.F27[key];
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.F27.GetEnumerator();

    public object Clone() => (object) new T9(this, this.F26);

    internal T8 M30()
    {
      T8 t8 = (T8) null;
      if (this.F27.Keys.Count <= 0)
        return t8;
      foreach (string key in this.F27.Keys)
        t8 = this.F27[key];
      return t8;
    }
  }
}
