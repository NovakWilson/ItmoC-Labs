using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Presentation.Scenarios.Login;

public class CreateUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;

    public CreateUserScenarioProvider(IUserService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new CreateUserScenario(_service);
        return true;
    }
}