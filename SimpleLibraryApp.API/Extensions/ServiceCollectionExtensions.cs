using System.Data;
using Npgsql;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Repository;

namespace SimpleLibraryApp.API;

public static class ServiceCollectionExtensions
{
    public static void ConfigureDapper(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(
            configuration.GetConnectionString("PostgreSQL")
        ));
    }

    public static void ConfigureDependencies(this IServiceCollection services) {
        services.AddScoped<IAuthRepository, AuthRepository>();
    }
}
