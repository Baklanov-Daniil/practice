class Program
{
    static void Main(string[] args)
    {
        var assembly = Assembly.LoadFrom("FileSystemCommands.dll");

        var sizeCmdType = assembly.GetType("FileSystemCommands.DirectorySizeCommand");
        var sizeCmd = (ICommand)Activator.CreateInstance(sizeCmdType, new object[] { @"C:\Test" });
        sizeCmd.Execute();

        var findCmdType = assembly.GetType("FileSystemCommands.FindFilesCommand");
        var findCmd = (ICommand)Activator.CreateInstance(findCmdType, new object[] { @"C:\Test", "*.txt" });
        findCmd.Execute();
    }
}
