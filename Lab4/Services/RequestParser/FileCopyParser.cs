using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestParser;

public class FileCopyParser : ParserBase
{
    public override CommandBase? ParseRequest(string[] request)
    {
        if (request is not null)
        {
            if (request[0] == "file" && request[1] == "copy")
            {
                string sourcePath = request[2];
                string destinationPath = request[3];
                return new FileCopyCommand(sourcePath, destinationPath);
            }

            if (NextParser is not null)
            {
                return NextParser.ParseRequest(request);
            }
        }

        return null;
    }
}