namespace Models.Accounts;

public class Account
{
    public Account(long id, long userId, long money, string number, string pin)
    {
        Id = id;
        UserId = userId;
        Money = money;
        Number = number;
        Pin = pin;
    }

    public long Id { get; private set; }
    public long UserId { get; private set; }
    public long Money { get; private set; }
    public string Number { get; private set; }
    public string Pin { get; private set; }
}