using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Presentation.Scenarios.Accounts;

public class GetAccountHistoryScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;

    public GetAccountHistoryScenarioProvider(IAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new GetAccountHistoryScenario(_service);
        return true;
    }
}