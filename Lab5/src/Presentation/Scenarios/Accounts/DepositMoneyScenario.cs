using System;
using Contracts.Accounts;
using Contracts.OperationResults;
using Spectre.Console;

namespace Presentation.Scenarios.Accounts;

public class DepositMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public DepositMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "DepositMoney";

    public void Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter amount of deposit money");

        OperationRes result = _accountService.DepositMoney(amount);

        string message = result switch
        {
            Success => "Successful Deposit",
            NotFound => "Account not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}