using Abstractions.Repositories;
using Contracts.OperationResults;
using Contracts.Users;
using Models.Users;

namespace Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public OperationRes Login(string username)
    {
        User? user = _repository.FindUserByUsername(username);

        if (user is null)
        {
            return new NotFound();
        }

        _currentUserManager.User = user;
        return new Success();
    }

    public void CreateUser(string username, UserRole userRole)
    {
        _repository.CreateUser(username, userRole);
    }
}