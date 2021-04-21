// Decompiled with JetBrains decompiler
// Type: N1.N3.N5.T16
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace N1.N3.N5
{
  public class T16 : ICloneable
  {
    private char F36;
    private char F37;
    private string F38;
    protected const string F39 = "^{0}(.*)";
    protected const string F40 = "^(\\s*?)";
    protected const string F41 = "{1}\\s*[\\p{L}\\p{P}\\p{M}_\\\"\\'\\{\\}\\#\\+\\;\\*\\%\\(\\)\\=\\?\\&\\$\\,\\:\\/\\.\\-\\w\\d\\s\\\\\\~]+\\s*";
    protected const string F42 = "(\\s*?)$";
    protected const string F43 = "^(\\s*[_\\.\\d\\w]*\\s*)";
    protected const string F44 = "([\\s\\d\\w\\W\\.]*)$";
    protected const string F45 = "[]\\^$.|?*+()";

    public T16()
    {
      this.P54 = ";";
      this.P50 = '[';
      this.P51 = ']';
      this.P56 = '=';
      this.P57 = " ";
      this.P55 = Environment.NewLine;
      this.P61 = false;
      this.P58 = true;
      this.P59 = false;
      this.P63 = false;
      this.P64 = true;
      this.P62 = true;
      this.P65 = false;
    }

    public T16(T16 ori)
    {
      this.P59 = ori.P59;
      this.P60 = ori.P60;
      this.P63 = ori.P63;
      this.P58 = ori.P58;
      this.P64 = ori.P64;
      this.P50 = ori.P50;
      this.P51 = ori.P51;
      this.P54 = ori.P54;
      this.P62 = ori.P62;
    }

    public Regex P48 { get; set; }

    public Regex P49 { get; set; }

    public char P50
    {
      get => this.F36;
      set
      {
        this.F36 = value;
        this.M45(this.F36);
      }
    }

    public char P51
    {
      get => this.F37;
      set
      {
        this.F37 = value;
        this.M45(this.F37);
      }
    }

    public bool P52 { get; set; }

    [Obsolete("Please use the CommentString property")]
    public char P53
    {
      get => this.P54[0];
      set => this.P54 = value.ToString();
    }

    public string P54
    {
      get => this.F38 ?? string.Empty;
      set
      {
        foreach (char c in "[]\\^$.|?*+()")
          value = value.Replace(new string(c, 1), "\\" + c.ToString());
        this.P48 = new Regex(string.Format("^{0}(.*)", (object) value));
        this.F38 = value;
      }
    }

    public string P55 { get; set; }

    public char P56 { get; set; }

    public string P57 { get; set; }

    public bool P58 { get; set; }

    public bool P59 { get; set; }

    public bool P60 { get; set; }

    public bool P61 { get; set; }

    public bool P62 { get; set; }

    public bool P63 { get; set; }

    public bool P64 { get; set; }

    public bool P65 { get; set; }

    private void M45(char value)
    {
      int num;
      if (!char.IsControl(value) && !char.IsWhiteSpace(value))
      {
        if (!this.P54.Contains(new string(new char[1]
        {
          value
        })))
        {
          num = (int) value == (int) this.P56 ? 1 : 0;
          goto label_4;
        }
      }
      num = 1;
label_4:
      if (num != 0)
        throw new Exception(string.Format("Invalid character for section delimiter: '{0}", (object) value));
      string str1 = "^(\\s*?)";
      string str2 = (!"[]\\^$.|?*+()".Contains(new string(this.F36, 1)) ? str1 + this.F36.ToString() : str1 + "\\" + this.F36.ToString()) + "{1}\\s*[\\p{L}\\p{P}\\p{M}_\\\"\\'\\{\\}\\#\\+\\;\\*\\%\\(\\)\\=\\?\\&\\$\\,\\:\\/\\.\\-\\w\\d\\s\\\\\\~]+\\s*";
      this.P49 = new Regex((!"[]\\^$.|?*+()".Contains(new string(this.F37, 1)) ? str2 + this.F37.ToString() : str2 + "\\" + this.F37.ToString()) + "(\\s*?)$");
    }

    public override int GetHashCode()
    {
      int num = 27;
      foreach (PropertyInfo property in this.GetType().GetProperties())
        num = num * 7 + property.GetValue((object) this, (object[]) null).GetHashCode();
      return num;
    }

    public override bool Equals(object obj)
    {
      bool flag;
      if (!(obj is T16 t16))
      {
        flag = false;
      }
      else
      {
        Type type = this.GetType();
        try
        {
          foreach (PropertyInfo property in type.GetProperties())
          {
            if (property.GetValue((object) t16, (object[]) null).Equals(property.GetValue((object) this, (object[]) null)))
              return false;
          }
        }
        catch
        {
          return false;
        }
        flag = true;
      }
      return flag;
    }

    public T16 M46() => this.MemberwiseClone() as T16;

    object ICloneable.Clone() => (object) this.M46();
  }
}
