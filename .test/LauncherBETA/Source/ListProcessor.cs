namespace LauncherKG.Source
{
    internal class ListProcessor
    {
        public static void AddFile(string File) => Import.Files.Add(new Import.File()
        {
            Name = File.Split(';')[0],
            Hash = File.Split(';')[1]
        });
    }
}
