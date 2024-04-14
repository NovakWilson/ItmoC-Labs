using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class DisconnectCommand : CommandBase
{
    public override void Execute(FileSystemConnection fileSystemConnection)
    {
        if (fileSystemConnection is not null)
            fileSystemConnection.FileSystem = null;
    }
}