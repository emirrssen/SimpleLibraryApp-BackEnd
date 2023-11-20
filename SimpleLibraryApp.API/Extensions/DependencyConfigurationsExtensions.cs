using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Repository;

namespace SimpleLibraryApp.API;

public static class DependencyConfigurationsExtensions
{
    public static void ConfigureDependencies(this IServiceCollection services) {
        services.AddScoped<IAuthRepository, AuthRepository>();
    }
}
