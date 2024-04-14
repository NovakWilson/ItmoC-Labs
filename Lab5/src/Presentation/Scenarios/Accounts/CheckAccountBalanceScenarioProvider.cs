using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Presentation.Scenarios.Accounts;

public class CheckAccountBalanceScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;

    public CheckAccountBalanceScenarioProvider(IAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new CheckAccountBalanceScenario(_service);
        return true;
    }
}