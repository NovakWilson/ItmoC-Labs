using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Presentation.Scenarios.Accounts;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;

    public CreateAccountScenarioProvider(IAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new CreateAccountScenario(_service);
        return true;
    }
}