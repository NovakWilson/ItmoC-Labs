using System.Collections.Generic;
using Contracts.Accounts;
using Models.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.Accounts;

public class GetAccountHistoryScenario : IScenario
{
    private readonly IAccountService _accountService;

    public GetAccountHistoryScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "GetHistory";

    public void Run()
    {
        IEnumerable<History> history = _accountService.GetAccountHistory();

        foreach (History hist in history)
        {
            AnsiConsole.WriteLine(hist.Number + " " + hist.Operation + " " + hist.Result + "\n");
        }
    }
}