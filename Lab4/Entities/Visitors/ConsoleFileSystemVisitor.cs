using System;
using System.Globalization;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;
using File = Itmo.ObjectOrientedProgramming.Lab4.Entities.Files.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

public class ConsoleFileSystemVisitor : IFileSystemVisitor
{
    public ConsoleFileSystemVisitor(int depth)
    {
        Depth = depth;
    }

    public int Depth { get; set; }

    private string FileOutputSymbol { get; set; } = "File";
    private string DirectoryOutputSymbol { get; set; } = "Directory";
    private string IndentOutputSymbol { get; set; } = "  ";

    private StringBuilder AsciiTree { get; set; } = new StringBuilder();

    public void SetFileOutputSymbol(string fileSymbol)
    {
        FileOutputSymbol = fileSymbol;
    }

    public void SetDirectoryOutputSymbol(string directorySymbol)
    {
        DirectoryOutputSymbol = directorySymbol;
    }

    public void SetIndentOutputSymbol(string indentSymbol)
    {
        IndentOutputSymbol = indentSymbol;
    }

    public string GetAsciiTree()
    {
        return AsciiTree.ToString();
    }

    public void Visit(File file)
    {
        if (file is not null)
            AsciiTree.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}{1}: {2}", new string(' ', Depth * IndentOutputSymbol.Length), FileOutputSymbol, file.Name));
    }

    public void Visit(FileSystemDirectory directory)
    {
        if (Depth < 0)
        {
            return;
        }

        if (directory is not null)
        {
            AsciiTree.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}{1}: {2}", new string(' ', Depth * IndentOutputSymbol.Length), DirectoryOutputSymbol, directory.Name));
            foreach (IComponent component in directory.GetContent)
            {
                component.Accept(this);
            }

            Depth -= 1;
        }
    }

    public void VisitFileContent(File file)
    {
        if (file is not null)
            Console.WriteLine(System.IO.File.ReadAllText(file.Path));
    }
}