using System.Data;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Npgsql;
using SimpleLibraryApp.Service;
using SimpleLibraryApp.Service.Auth.Commands.Login;

namespace SimpleLibraryApp.API;

public static class PackageConfigurationsExtensions
{
    public static void ConfigureDapper(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(
            configuration.GetConnectionString("PostgreSQL")
        ));
    }

    public static void ConfigureMediatR(this IServiceCollection services) {
        services.AddMediatR(typeof(AssemblyProvider).Assembly);
    }

    public static void ConfigureFluentValidation(this IServiceCollection services) {
        services.AddControllers(option => option.Filters.Add(new ValidationResponseFilter()))
            .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(typeof(AssemblyProvider).Assembly));
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
