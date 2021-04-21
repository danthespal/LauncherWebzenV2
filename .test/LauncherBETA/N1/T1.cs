// Decompiled with JetBrains decompiler
// Type: N1.T1
// Assembly: Launcher, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: D410EDBF-30AF-46E0-87CA-E381D23E95AB
// Assembly location: D:\Git\MuOnlineLauncher\CPTeamLauncher\Launcher.exe

using N1.N2;
using N1.N3;
using N1.N7;
using System;
using System.IO;
using System.Text;

namespace N1
{
  public class T1 : T2
  {
    public T1()
    {
    }

    public T1(T5 parser)
      : base(parser)
    {
      this.P21 = parser;
    }

    [Obsolete("Please use ReadFile method instead of this one as is more semantically accurate")]
    public T6 M0(string filePath) => this.M2(filePath);

    [Obsolete("Please use ReadFile method instead of this one as is more semantically accurate")]
    public T6 M1(string filePath, Encoding fileEncoding) => this.M3(filePath, fileEncoding);

    public T6 M2(string filePath) => this.M3(filePath, Encoding.ASCII);

    public T6 M3(string filePath, Encoding fileEncoding)
    {
      if (filePath == string.Empty)
        throw new ArgumentException("Bad filename.");
      try
      {
        using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
          using (StreamReader reader = new StreamReader((Stream) fileStream, fileEncoding))
            return this.M6(reader);
        }
      }
      catch (IOException ex)
      {
        throw new T18(string.Format("Could not parse file {0}", (object) filePath), (Exception) ex);
      }
    }

    [Obsolete("Please use WriteFile method instead of this one as is more semantically accurate")]
    public void M4(string filePath, T6 parsedData) => this.M5(filePath, parsedData, Encoding.UTF8);

    public void M5(string filePath, T6 parsedData, Encoding fileEncoding = null)
    {
      if (fileEncoding == null)
        fileEncoding = Encoding.UTF8;
      if (string.IsNullOrEmpty(filePath))
        throw new ArgumentException("Bad filename.");
      if (parsedData == null)
        throw new ArgumentNullException(nameof (parsedData));
      using (FileStream fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
      {
        using (StreamWriter writer = new StreamWriter((Stream) fileStream, fileEncoding))
          this.M7(writer, parsedData);
      }
    }
  }
}
