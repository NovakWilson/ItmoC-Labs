using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileShowCommand : CommandBase
{
    public FileShowCommand(string path, string mode)
    {
        Path = path;
        Mode = mode;
    }

    private string Path { get; }
    private string Mode { get; }

    public override void Execute(FileSystemConnection fileSystemConnection)
    {
        if (fileSystemConnection is not null && fileSystemConnection.FileSystem is not null)
        {
            if (Mode == "console")
            {
                fileSystemConnection.FileSystem.ShowFileContent(new ConsoleFileSystemVisitor(1), Path);
            }
        }
    }
}