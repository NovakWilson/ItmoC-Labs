using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : CommandBase
{
    public ConnectCommand(string absolutePath, string mode)
    {
        AbsolutePath = absolutePath;
        Mode = mode;
    }

    public string AbsolutePath { get; }
    public string Mode { get; }

    public override void Execute(FileSystemConnection fileSystemConnection)
    {
        if (Mode == "local")
        {
            if (fileSystemConnection is not null)
            {
                fileSystemConnection.FileSystem = new LocalFileSystem();
                fileSystemConnection.FileSystem.Connect(AbsolutePath);
            }
        }
    }
}