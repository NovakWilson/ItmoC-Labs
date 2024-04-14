using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public abstract class CommandBase
{
    public abstract void Execute(FileSystemConnection fileSystemConnection);
}