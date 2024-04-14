using Itmo.Dev.Platform.Postgres.Plugins;
using Models.Operations;
using Models.Users;
using Npgsql;

namespace Infrastructure.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        if (builder is not null)
        {
            builder.MapEnum<UserRole>();
            builder.MapEnum<OperationResult>();
        }
    }
}