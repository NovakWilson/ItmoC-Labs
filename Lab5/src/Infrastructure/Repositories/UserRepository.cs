using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Users;
using Npgsql;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByUsername(string username)
    {
        const string sql = """
           select user_id, user_name, user_role
           from users
           where user_name = :username;
           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default).AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            Role: reader.GetFieldValue<UserRole>(2));
    }

    public void CreateUser(string username, UserRole userRole)
    {
        const string sql = """
                           INSERT INTO users (user_name, user_role)
                           VALUES (:userName, :userRole)
                           RETURNING user_id;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default).AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("username", username);
        command.AddParameter("userRole", userRole);

        command.ExecuteNonQuery();
    }
}