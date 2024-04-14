using Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserByUsername(string username);

    void CreateUser(string username, UserRole userRole);
}