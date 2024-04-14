using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private string CurrentPath { get; set; } = string.Empty;
    private string AbsolutePath { get; set; } = string.Empty;

    private IComponent? Component { get; set; }

    public void Connect(string newAbsPath)
    {
        AbsolutePath = newAbsPath;
        Component = BuildComponent(newAbsPath);
    }

    public string CombinePath(string newPath)
    {
        if (Path.Exists(AbsolutePath + '/' + newPath))
        {
            return AbsolutePath + '/' + newPath;
        }

        if (Path.Exists(CurrentPath + '/' + newPath))
        {
            return CurrentPath + '/' + newPath;
        }

        return string.Empty;
    }

    public void ChangePath(string newPath)
    {
        string combinedPath = CombinePath(newPath);
        if (combinedPath.Length != 0)
        {
            CurrentPath = combinedPath;
        }
        else
        {
            throw new ArgumentException("Указанного пути не существует");
        }
    }

    public void GetTreeList(IFileSystemVisitor visitor)
    {
        if (Component is not null)
            Component.Accept(visitor);
    }

    public void ShowFileContent(IFileSystemVisitor visitor, string path)
    {
        string combinedPath = CombinePath(path);
        if (combinedPath.Length != 0)
        {
            var file = new Files.File(combinedPath);
            file.AcceptContent(visitor);
        }
        else
        {
            throw new ArgumentException("Указанного пути не существует");
        }
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        string sourceCombinedPath = CombinePath(sourcePath);
        if (sourceCombinedPath.Length != 0)
        {
            sourcePath = sourceCombinedPath;
        }
        else
        {
            throw new ArgumentException("Указанного пути не существует");
        }

        string destinationCombinedPath = CombinePath(destinationPath);
        if (destinationCombinedPath.Length != 0)
        {
            destinationPath = destinationCombinedPath;
        }
        else
        {
            throw new ArgumentException("Указанного пути не существует");
        }

        File.Move(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        string sourceCombinedPath = CombinePath(sourcePath);
        if (sourceCombinedPath.Length != 0)
        {
            sourcePath = sourceCombinedPath;
        }
        else
        {
            throw new ArgumentException("Указанного пути не существует");
        }

        string destinationCombinedPath = CombinePath(destinationPath);
        if (destinationCombinedPath.Length != 0)
        {
            destinationPath = destinationCombinedPath;
        }
        else
        {
            throw new ArgumentException("Указанного пути не существует");
        }

        File.Copy(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        string combinedPath = CombinePath(path);
        if (combinedPath.Length != 0)
        {
            File.Delete(combinedPath);
        }
        else
        {
            throw new ArgumentException("Указанного пути не существует");
        }
    }

    public void RenameFile(string path, string newName)
    {
        string combinedPath = CombinePath(path);
        if (combinedPath.Length != 0)
        {
            string? directoryPath = Path.GetDirectoryName(combinedPath);
            if (directoryPath is not null)
            {
                string newFilePath = Path.Combine(directoryPath, newName);
                File.Move(combinedPath, newFilePath);
            }
        }
        else
        {
            throw new ArgumentException("Указанного пути не существует");
        }
    }

    private IComponent? BuildComponent(string path)
    {
        if (File.Exists(path))
        {
            return new Files.File(path);
        }

        if (Directory.Exists(path))
        {
            var directory = new FileSystemDirectory(path);

            foreach (string subPath in Directory.GetFileSystemEntries(path))
            {
                IComponent? subComponent = BuildComponent(subPath);
                if (subComponent is not null)
                    directory.AddComponent(subComponent);
            }

            return directory;
        }

        return null;
    }
}