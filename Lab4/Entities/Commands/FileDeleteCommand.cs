using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileDeleteCommand : CommandBase
{
    public FileDeleteCommand(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public override void Execute(FileSystemConnection fileSystemConnection)
    {
        if (fileSystemConnection is not null && fileSystemConnection.FileSystem is not null)
        {
            fileSystemConnection.FileSystem.DeleteFile(Path);
        }
    }
}