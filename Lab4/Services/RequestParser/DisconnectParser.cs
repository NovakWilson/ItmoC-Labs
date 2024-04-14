using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestParser;

public class DisconnectParser : ParserBase
{
    public override CommandBase? ParseRequest(string[] request)
    {
        if (request is not null)
        {
            if (request[0] == "connect")
            {
                return new DisconnectCommand();
            }

            if (NextParser is not null)
            {
               return NextParser.ParseRequest(request);
            }
        }

        return null;
    }
}