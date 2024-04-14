using System;
using Contracts.Accounts;
using Contracts.OperationResults;
using Spectre.Console;

namespace Presentation.Scenarios.Accounts;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "WithdrawMoney";

    public void Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter amount of withdraw money");

        OperationRes result = _accountService.DepositMoney(amount);

        string message = result switch
        {
            Success => "Successful withdraw",
            NotFound => "Account not found",
            NotEnoughMoney => "You don't have enough money to withdraw",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}