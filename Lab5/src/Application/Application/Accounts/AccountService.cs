using System;
using System.Collections.Generic;
using Abstractions.Repositories;
using Contracts.Accounts;
using Contracts.OperationResults;
using Models.Accounts;
using Models.Operations;

namespace Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;
    private readonly IOperationsRepository _operationRepository;

    private Account? _curAccount;

    public AccountService(IAccountRepository repository, IOperationsRepository operationRepository)
    {
        _repository = repository;
        _operationRepository = operationRepository;
    }

    public void CreateAccount(long userId, string number, string pin)
    {
        _repository.CreateAccount(userId, number, pin);
        _operationRepository.WriteOperation(number, "Creation", OperationResult.Success);
    }

    public OperationRes LoginAccount(string number, string pin)
    {
        _curAccount = _repository.LoginAccount(number, pin);

        if (_curAccount is null)
        {
            _operationRepository.WriteOperation(number, "Loggined", OperationResult.Fail);
            return new NotFound();
        }

        _operationRepository.WriteOperation(number, "Loggined", OperationResult.Success);
        return new Success();
    }

    public long CheckAccountBalance()
    {
        if (_curAccount is not null)
        {
            return _repository.CheckAccountBalance(_curAccount.Number);
        }

        return -1;
    }

    public OperationRes DepositMoney(long amount)
    {
        if (_curAccount is null)
        {
            return new NotFound();
        }

        long curMoney = _repository.CheckAccountBalance(_curAccount.Number);

        _repository.ChangeBalance(_curAccount.Number, curMoney + amount);

        _operationRepository.WriteOperation(_curAccount.Number, "+" + amount, OperationResult.Success);

        return new Success();
    }

    public OperationRes WithdrawMoney(long amount)
    {
        if (_curAccount is null)
        {
            return new NotFound();
        }

        long curMoney = _repository.CheckAccountBalance(_curAccount.Number);

        if (curMoney < amount)
        {
            _operationRepository.WriteOperation(_curAccount.Number, "-" + amount, OperationResult.Fail);
            return new NotEnoughMoney();
        }

        _repository.ChangeBalance(_curAccount.Number, curMoney - amount);

        _operationRepository.WriteOperation(_curAccount.Number, "-" + amount, OperationResult.Success);

        return new Success();
    }

    public IEnumerable<History> GetAccountHistory()
    {
        if (_curAccount is not null)
        {
            return _operationRepository.GetHistory(_curAccount.Number);
        }

        return Array.Empty<History>();
    }
}