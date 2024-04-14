using Models.Accounts;

namespace Abstractions.Repositories;

public interface IAccountRepository
{
     Account CreateAccount(long userId, string number, string pin);

     Account? LoginAccount(string number, string pin);

     long CheckAccountBalance(string number);

     void ChangeBalance(string number, long newBalance);
}