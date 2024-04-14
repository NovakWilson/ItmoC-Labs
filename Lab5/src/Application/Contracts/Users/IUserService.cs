using Contracts.OperationResults;
using Models.Users;

namespace Contracts.Users;

public interface IUserService
{
    OperationRes Login(string username);

    void CreateUser(string username, UserRole userRole);
}