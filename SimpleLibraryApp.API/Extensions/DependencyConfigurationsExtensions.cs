using SimpleLibraryApp.Core;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Repository.Dapper;

namespace SimpleLibraryApp.API;

public static class DependencyConfigurationsExtensions
{
    public static void ConfigureDependencies(this IServiceCollection services) {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
    }
}
