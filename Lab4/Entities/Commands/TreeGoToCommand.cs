using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeGoToCommand : CommandBase
{
    public TreeGoToCommand(string goToPath)
    {
        GoToPath = goToPath;
    }

    private string GoToPath { get; }

    public override void Execute(FileSystemConnection fileSystemConnection)
    {
        if (fileSystemConnection is not null && fileSystemConnection.FileSystem is not null)
        {
            fileSystemConnection.FileSystem.ChangePath(GoToPath);
        }
    }
}