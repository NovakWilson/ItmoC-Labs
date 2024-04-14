using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestParser;

public abstract class ParserBase
{
    protected ParserBase? NextParser { get; set; }

    public void SetNextParser(ParserBase parser)
    {
        NextParser = parser;
    }

    public abstract CommandBase? ParseRequest(string[] request);
}