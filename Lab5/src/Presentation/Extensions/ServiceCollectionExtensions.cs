using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios.Accounts;
using Presentation.Scenarios.Login;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<IScenarioProvider, CreateUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckAccountBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetAccountHistoryScenarioProvider>();

        return collection;
    }
}