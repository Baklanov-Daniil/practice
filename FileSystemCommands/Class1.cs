using System.IO;

public class DirectorySizeCommand : ICommand
{
    private string _path {get; }

    public long size = 0;

    public DirectorySizeCommand(string path)
    {
        _path = path;
    }

    public void Execute()
    {
        if (!Directory.Exists(_path))
        {
            return;
        }
        this.size = CalculateSize(_path);
    }

    private long CalculateSize(string directory)
    {
        long size = 0;

        foreach (var file in Directory.GetFiles(directory))
            size += new FileInfo(file).Length;

        foreach (var dir in Directory.GetDirectories(directory))
            size += CalculateSize(dir);

        return size;
    }
}

public class FindFilesCommand : ICommand
{
    private string _path { get; }
    private string _pattern { get; }

    public string[] Files = Array.Empty<string>();

    public FindFilesCommand(string path, string pattern)
    {
        _path = path;
        _pattern = pattern;
    }

    public void Execute()
    {
        if (!Directory.Exists(_path))
        {
            return;
        }
        this.Files = Directory.GetFiles(_path, _pattern, SearchOption.AllDirectories);
    }
}
