using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestParser;

public class TreeListParser : ParserBase
{
    public override CommandBase? ParseRequest(string[] request)
    {
        if (request is not null)
        {
            if (request[0] == "tree" && request[1] == "list")
            {
                if (request.Length == 2)
                {
                    return new TreeListCommand(1);
                }

                int depth = Convert.ToInt32(request[3], CultureInfo.InvariantCulture);
                return new TreeListCommand(depth);
            }

            if (NextParser is not null)
            {
                return NextParser.ParseRequest(request);
            }
        }

        return null;
    }
}