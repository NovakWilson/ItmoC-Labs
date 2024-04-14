using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeListCommand : CommandBase
{
    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    public int Depth { get; }

    public override void Execute(FileSystemConnection fileSystemConnection)
    {
        if (fileSystemConnection is not null && fileSystemConnection.FileSystem is not null)
        {
            fileSystemConnection.FileSystem.GetTreeList(new ConsoleFileSystemVisitor(Depth));
        }
    }
}