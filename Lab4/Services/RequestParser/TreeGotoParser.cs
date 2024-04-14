using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestParser;

public class TreeGotoParser : ParserBase
{
    public override CommandBase? ParseRequest(string[] request)
    {
        if (request is not null)
        {
            if (request[0] == "tree" && request[1] == "goto")
            {
                string path = request[2];
                return new TreeGoToCommand(path);
            }

            if (NextParser is not null)
            {
                return NextParser.ParseRequest(request);
            }
        }

        return null;
    }
}