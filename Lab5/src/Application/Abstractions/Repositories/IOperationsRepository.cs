using System.Collections.Generic;
using Models.Accounts;
using Models.Operations;

namespace Abstractions.Repositories;

public interface IOperationsRepository
{
    void WriteOperation(string number, string operation, OperationResult result);

    IEnumerable<History> GetHistory(string number);
}