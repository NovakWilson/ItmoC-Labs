using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestParser;

public class FileShowParser : ParserBase
{
    public override CommandBase? ParseRequest(string[] request)
    {
        if (request is not null)
        {
            if (request[0] == "file" && request[1] == "show")
            {
                string path = request[2];
                string mode = request[4];
                return new FileShowCommand(path, mode);
            }

            if (NextParser is not null)
            {
               return NextParser.ParseRequest(request);
            }
        }

        return null;
    }
}