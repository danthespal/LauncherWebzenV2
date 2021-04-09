// ListProcessor.cs
// decrypted by Arsenic for KG-Emulator

using System;

namespace LauncherWebzenV2.Source
{
  internal class ListProcessor
  {
    public static void AddFile(string File) => Import.Files.Add(new Import.File()
    {
      Name = File.Split(' ')[0],
      Hash = File.Split(' ')[1],
      Size = Convert.ToInt64(File.Split(' ')[2])
    });
  }
}
