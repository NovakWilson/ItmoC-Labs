using System.Collections.Generic;
using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Accounts;
using Models.Operations;
using Npgsql;

namespace Infrastructure.Repositories;

public class OperationsRepository : IOperationsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void WriteOperation(string number, string operation, OperationResult result)
    {
        const string insertSql = """
                                 INSERT INTO accounts_operations (account_number, operation, operation_result)
                                 VALUES (:number, :operation, :result)
                                 RETURNING operation_id;
                                 """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default).AsTask().GetAwaiter().GetResult();

        using var insertCommand = new NpgsqlCommand(insertSql, connection);

        insertCommand.AddParameter("number", number);
        insertCommand.AddParameter("operation", operation);
        insertCommand.AddParameter("result", result);

        insertCommand.ExecuteNonQuery();
    }

    public IEnumerable<History> GetHistory(string number)
    {
        const string sql = """
                           select account_number, operation, operation_result
                           from accounts_operations
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default).AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new History(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetFieldValue<OperationResult>(2));
        }
    }
}