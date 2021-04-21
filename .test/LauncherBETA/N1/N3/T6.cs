// Decompiled with JetBrains decompiler
// Type: N1.N3.T6
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using N1.N3.N4;
using N1.N3.N5;
using System;
using System.Reflection;

namespace N1.N3
{
  [DefaultMember("Item")]
  public class T6 : ICloneable
  {
    private T11 F21;
    private T16 F22;

    public T6()
      : this(new T11())
    {
    }

    public T6(T11 sdc)
    {
      this.F21 = (T11) sdc.Clone();
      this.P28 = new T9();
      this.P31 = '.';
    }

    public T6(T6 ori)
      : this(ori.P30)
    {
      this.P28 = (T9) ori.P28.Clone();
      this.P27 = ori.P27.M46();
    }

    public T16 P27
    {
      get
      {
        if (this.F22 == null)
          this.F22 = new T16();
        return this.F22;
      }
      set => this.F22 = value.M46();
    }

    public T9 P28 { get; protected set; }

    public T9 get_Item(string sectionName)
    {
      if (!this.F21.M37(sectionName))
      {
        if (!this.P27.P64)
          return (T9) null;
        this.F21.M34(sectionName);
      }
      return this.F21.get_Item(sectionName);
    }

    public T11 P30
    {
      get => this.F21;
      set => this.F21 = value;
    }

    public char P31 { get; set; }

    public override string ToString() => this.ToString((T13) new T12(this.P27));

    public virtual string ToString(T13 formatter) => formatter.IniDataToString(this);

    public object Clone() => (object) new T6(this);

    public void M13()
    {
      this.P28.M23();
      foreach (T10 t10 in this.P30)
        t10.M31();
    }

    public void M14(T6 toMergeIniData)
    {
      if (toMergeIniData == null)
        return;
      this.P28.M26(toMergeIniData.P28);
      this.P30.M39(toMergeIniData.P30);
    }

    public bool M15(string key, out string value)
    {
      value = string.Empty;
      bool flag;
      if (string.IsNullOrEmpty(key))
      {
        flag = false;
      }
      else
      {
        string[] strArray = key.Split(this.P31);
        int num = strArray.Length - 1;
        if (num > 1)
          throw new ArgumentException("key contains multiple separators", nameof (key));
        if (num == 0)
        {
          if (!this.P28.M24(key))
          {
            flag = false;
          }
          else
          {
            value = this.P28.get_Item(key);
            flag = true;
          }
        }
        else
        {
          string str = strArray[0];
          key = strArray[1];
          if (!this.F21.M37(str))
          {
            flag = false;
          }
          else
          {
            T9 t9 = this.F21.get_Item(str);
            if (!t9.M24(key))
            {
              flag = false;
            }
            else
            {
              value = t9.get_Item(key);
              flag = true;
            }
          }
        }
      }
      return flag;
    }

    public string M16(string key)
    {
      string str;
      return !this.M15(key, out str) ? (string) null : str;
    }

    private void M17(T10 otherSection)
    {
      if (!this.P30.M37(otherSection.P37))
        this.P30.M34(otherSection.P37);
      this.P30.M38(otherSection.P37).M33(otherSection);
    }

    private void M18(T9 globals)
    {
      foreach (T8 global in globals)
        this.P28.set_Item(global.P34, global.P33);
    }
  }
}
