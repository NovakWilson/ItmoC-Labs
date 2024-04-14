using System;
using Contracts.Accounts;
using Contracts.OperationResults;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class LoginAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LoginAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "LoginAccount";

    public void Run()
    {
        string number = AnsiConsole.Ask<string>("Enter account number");
        string pin = AnsiConsole.Ask<string>("Enter account pin code");

        OperationRes result = _accountService.LoginAccount(number, pin);

        string message = result switch
        {
            Success => "Successful Account login",
            NotFound => "Account not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}