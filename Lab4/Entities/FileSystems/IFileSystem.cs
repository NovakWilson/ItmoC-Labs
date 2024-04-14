using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public interface IFileSystem
{
    void Connect(string newAbsPath);
    void ChangePath(string newPath);
    void GetTreeList(IFileSystemVisitor visitor);
    void ShowFileContent(IFileSystemVisitor visitor, string path);
    void MoveFile(string sourcePath, string destinationPath);
    void CopyFile(string sourcePath, string destinationPath);
    void DeleteFile(string path);
    void RenameFile(string path, string newName);
}