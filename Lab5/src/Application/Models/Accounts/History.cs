using Models.Operations;

namespace Models.Accounts;

public class History
{
    public History(string number, string operation, OperationResult result)
    {
        Number = number;
        Operation = operation;
        Result = result;
    }

    public string Number { get; private set; }
    public string Operation { get; private set; }
    public OperationResult Result { get; private set; }
}