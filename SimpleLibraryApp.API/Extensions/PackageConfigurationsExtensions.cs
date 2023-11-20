using System.Data;
using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Npgsql;
using SimpleLibraryApp.Service;

namespace SimpleLibraryApp.API;

public static class PackageConfigurationsExtensions
{
    public static void ConfigureDapper(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(
            configuration.GetConnectionString("PostgreSQL")
        ));
    }

    public static void ConfigureMediatR(this IServiceCollection services) {
        services.AddMediatR(Assembly.GetAssembly(typeof(AssemblyProvider)));
    }

    public static void ConfigureFluentValidation(this IServiceCollection services) {
        services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
    }

    public static void ConfigureAutoMapper(this IServiceCollection services) {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(AssemblyProvider)));
    }

    public static void ConfigureTransaction(this IServiceCollection services) {
        services.AddScoped<IDbTransaction>(sp => {
            var connection = sp.GetRequiredService<IDbConnection>();
            connection.Open();
            return connection.BeginTransaction();
        });
    }
}
