// Decompiled with JetBrains decompiler
// Type: N1.T2
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using N1.N2;
using N1.N3;
using N1.N3.N4;
using System;
using System.IO;

namespace N1
{
  public class T2
  {
    public T2()
      : this(new T5())
    {
    }

    public T2(T5 parser) => this.P21 = parser;

    public T5 P21 { get; protected set; }

    public T6 M6(StreamReader reader) => reader != null ? this.P21.M11(reader.ReadToEnd()) : throw new ArgumentNullException(nameof (reader));

    public void M7(StreamWriter writer, T6 iniData)
    {
      if (iniData == null)
        throw new ArgumentNullException(nameof (iniData));
      if (writer == null)
        throw new ArgumentNullException(nameof (writer));
      writer.Write(iniData.ToString());
    }

    public void M8(StreamWriter writer, T6 iniData, T13 formatter)
    {
      if (formatter == null)
        throw new ArgumentNullException(nameof (formatter));
      if (iniData == null)
        throw new ArgumentNullException(nameof (iniData));
      if (writer == null)
        throw new ArgumentNullException(nameof (writer));
      writer.Write(iniData.ToString(formatter));
    }
  }
}
