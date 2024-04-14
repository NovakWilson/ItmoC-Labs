using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;

public interface IComponent
{
    void Accept(IFileSystemVisitor visitor);
}