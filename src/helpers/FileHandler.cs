namespace CIDevTools;
public static class FileHandling
{
    public static void ReadFile(FileInfo file)
    {
        File.ReadLines(file.FullName).ToList()
            .ForEach(line => Console.WriteLine(line));
    }

}