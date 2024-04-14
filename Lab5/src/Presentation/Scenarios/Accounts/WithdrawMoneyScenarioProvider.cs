using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Presentation.Scenarios.Accounts;

public class WithdrawMoneyScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;

    public WithdrawMoneyScenarioProvider(IAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new WithdrawMoneyScenario(_service);
        return true;
    }
}