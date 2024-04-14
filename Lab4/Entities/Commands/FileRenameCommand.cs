using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileRenameCommand : CommandBase
{
    public FileRenameCommand(string path, string newName)
    {
        Path = path;
        NewName = newName;
    }

    private string Path { get; }
    private string NewName { get; }

    public override void Execute(FileSystemConnection fileSystemConnection)
    {
        if (fileSystemConnection is not null && fileSystemConnection.FileSystem is not null)
        {
            fileSystemConnection.FileSystem.RenameFile(Path, NewName);
        }
    }
}