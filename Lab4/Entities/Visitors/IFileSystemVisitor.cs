using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

public interface IFileSystemVisitor
{
    int Depth { get; set; }
    void Visit(File file);
    void Visit(FileSystemDirectory directory);
    void VisitFileContent(File file);
}