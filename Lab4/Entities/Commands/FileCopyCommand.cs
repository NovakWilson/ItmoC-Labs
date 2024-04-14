using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileCopyCommand : CommandBase
{
    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    private string SourcePath { get; }
    private string DestinationPath { get; }

    public override void Execute(FileSystemConnection fileSystemConnection)
    {
        if (fileSystemConnection is not null && fileSystemConnection.FileSystem is not null)
        {
            fileSystemConnection.FileSystem.CopyFile(SourcePath, DestinationPath);
        }
    }
}