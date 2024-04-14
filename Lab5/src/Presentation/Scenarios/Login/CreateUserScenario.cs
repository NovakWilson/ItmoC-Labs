using Contracts.Users;
using Models.Users;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class CreateUserScenario : IScenario
{
    private readonly IUserService _userService;

    public CreateUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "CreateUser";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");

        string askrole = AnsiConsole.Ask<string>("Enter your role");

        if (askrole == "user")
        {
            _userService.CreateUser(username, UserRole.User);
        }
        else
        {
            _userService.CreateUser(username, UserRole.Admin);
        }

        AnsiConsole.WriteLine("User was successfully created!");
        AnsiConsole.Ask<string>("Ok");
    }
}