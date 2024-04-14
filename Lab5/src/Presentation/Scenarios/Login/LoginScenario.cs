using System;
using Contracts.OperationResults;
using Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");

        OperationRes result = _userService.Login(username);

        string message = result switch
        {
            Success => "Successful login",
            NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}