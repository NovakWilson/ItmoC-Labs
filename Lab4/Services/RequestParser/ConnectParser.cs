using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestParser;

public class ConnectParser : ParserBase
{
    public override CommandBase? ParseRequest(string[] request)
    {
        if (request is not null)
        {
            if (request[0] == "connect")
            {
                string path = request[1];
                string mode = request[3];
                return new ConnectCommand(path, mode);
            }

            if (NextParser is not null)
            {
                return NextParser.ParseRequest(request);
            }
        }

        return null;
    }
}