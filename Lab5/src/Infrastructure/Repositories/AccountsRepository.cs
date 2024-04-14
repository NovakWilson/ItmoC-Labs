using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Accounts;
using Npgsql;

namespace Infrastructure.Repositories;

public class AccountsRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account CreateAccount(long userId, string number, string pin)
    {
        const string insertSql = """
            INSERT INTO accounts (user_id, money, account_number, account_pin)
            VALUES (:userId, :money, :number, :pin)
            RETURNING account_id;
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default).AsTask().GetAwaiter().GetResult();

        using var insertCommand = new NpgsqlCommand(insertSql, connection);

        insertCommand.AddParameter("userId", userId);
        insertCommand.AddParameter("money", 0);
        insertCommand.AddParameter("number", number);
        insertCommand.AddParameter("pin", pin);

        using NpgsqlDataReader reader = insertCommand.ExecuteReader();

        return new Account(
            id: reader.GetInt64(0),
            userId: reader.GetInt64(1),
            money: 0,
            number: reader.GetString(3),
            pin: reader.GetString(4));
    }

    public Account? LoginAccount(string number, string pin)
    {
        const string sql = """
           select account_id, user_id, money, account_number, account_pin
           from accounts
           where account_number = :number and account_pin = :pin;
           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default).AsTask().GetAwaiter().GetResult();

        using var сommand = new NpgsqlCommand(sql, connection);

        сommand.AddParameter("number", number);
        сommand.AddParameter("pin", pin);

        using NpgsqlDataReader reader = сommand.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            id: reader.GetInt64(0),
            userId: reader.GetInt64(1),
            money: reader.GetInt64(2),
            number: reader.GetString(3),
            pin: reader.GetString(4));
    }

    public long CheckAccountBalance(string number)
    {
        const string Sql = """
                                 select money
                                 from accounts
                                 where account_number = :number;
                                 """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default).AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(Sql, connection);

        command.AddParameter("number", number);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.GetInt64(0);
    }

    public void ChangeBalance(string number, long newBalance)
    {
        const string Sql = """
                           UPDATE accounts
                           SET money = :newBalance
                           WHERE account_number = :accountNumber;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default).AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(Sql, connection);

        command.AddParameter("newBalance", newBalance);
        command.AddParameter("accountNumber", number);

        command.ExecuteNonQuery();
    }
}