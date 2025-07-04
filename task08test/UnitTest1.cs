using System;

namespace Xunit;

public class FileSystemCommandsTests
{
    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "test1.txt"), "Hello"); // 5 байт
        File.WriteAllText(Path.Combine(testDir, "test2.txt"), "World"); // 5 байт

        var command = new DirectorySizeCommand(testDir);
        command.Execute();

        Assert.Equal(10, command.size);
        Directory.Delete(testDir, true);
    }

    [Fact]
    public void DirectorySizeCommand_ShouldReturnZeroLenForEmptyDir()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);


        var command = new DirectorySizeCommand(testDir);
        command.Execute();

        Assert.Equal(0, command.size);
        Directory.Delete(testDir, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.txt"), "Text1");
        File.WriteAllText(Path.Combine(testDir, "file2.log"), "Log");
        File.WriteAllText(Path.Combine(testDir, "file3.txt"), "Text3");

        var command = new FindFilesCommand(testDir, "*.txt");
        command.Execute();

        Assert.Equal(2, command.Files.Length);

        Directory.Delete(testDir, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldntFindMatchingFiles()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.txt"), "Text1");
        File.WriteAllText(Path.Combine(testDir, "file2.log"), "Log");
        File.WriteAllText(Path.Combine(testDir, "file3.txt"), "Text3");

        var command = new FindFilesCommand(testDir, "*.abc");
        command.Execute();

        Assert.Empty(command.Files);

        Directory.Delete(testDir, true);
    }
}
