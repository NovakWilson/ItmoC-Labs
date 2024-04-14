using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Presentation.Scenarios.Login;

public class LoginAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;

    public LoginAccountScenarioProvider(IAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new LoginAccountScenario(_service);
        return true;
    }
}