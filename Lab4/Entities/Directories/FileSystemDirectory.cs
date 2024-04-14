using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directories;

public class FileSystemDirectory : IComponent
{
    private ICollection<IComponent> content;

    public FileSystemDirectory(string path)
    {
        Path = path;
        content = new Collection<IComponent>();
        Name = System.IO.Path.GetFileName(path);
    }

    public string Path { get; private set; }
    public string Name { get; }

    public ICollection<IComponent> GetContent
    {
        get { return content; }
    }

    public void AddComponent(IComponent component)
    {
        content.Add(component);
    }

    public void RemoveComponent(IComponent component)
    {
        content.Remove(component);
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        if (visitor is not null)
        {
            visitor.Visit(this);
        }
    }
}