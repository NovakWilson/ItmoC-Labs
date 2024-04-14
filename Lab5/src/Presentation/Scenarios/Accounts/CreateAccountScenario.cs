using Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.Accounts;

public class CreateAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CreateAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "CreateAccount";

    public void Run()
    {
        long userId = AnsiConsole.Ask<long>("Enter your Id");
        string number = AnsiConsole.Ask<string>("Create account number");
        string pin = AnsiConsole.Ask<string>("create account pin code");

        _accountService.CreateAccount(userId, number, pin);

        AnsiConsole.WriteLine("New account has been created!");
    }
}