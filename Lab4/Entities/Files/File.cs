using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;

public class File : IComponent
{
    public File(string path)
    {
        Path = path;
        Name = System.IO.Path.GetFileName(path);
    }

    public string Path { get; private set; }
    public string Name { get; }

    public void Accept(IFileSystemVisitor visitor)
    {
        if (visitor is not null)
        {
            visitor.Visit(this);
        }
    }

    public void AcceptContent(IFileSystemVisitor visitor)
    {
        if (visitor is not null)
        {
            visitor.VisitFileContent(this);
        }
    }
}