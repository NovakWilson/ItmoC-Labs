using Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.Accounts;

public class CheckAccountBalanceScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CheckAccountBalanceScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "CheckBalance";

    public void Run()
    {
        long money = _accountService.CheckAccountBalance();

        if (money == -1)
        {
            AnsiConsole.WriteLine("Вы не вошли в аккаунт");
        }
        else
        {
            AnsiConsole.WriteLine("Баланс счета: " + money);
        }
    }
}