using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Presentation.Scenarios.Accounts;

public class DepositMoneyScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;

    public DepositMoneyScenarioProvider(IAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new DepositMoneyScenario(_service);
        return true;
    }
}