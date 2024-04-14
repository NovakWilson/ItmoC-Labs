using System.Collections.Generic;
using Contracts.OperationResults;
using Models.Accounts;

namespace Contracts.Accounts;

public interface IAccountService
{
    void CreateAccount(long userId, string number, string pin);

    OperationRes LoginAccount(string number, string pin);

    long CheckAccountBalance();

    OperationRes DepositMoney(long amount);

    OperationRes WithdrawMoney(long amount);

    IEnumerable<History> GetAccountHistory();
}