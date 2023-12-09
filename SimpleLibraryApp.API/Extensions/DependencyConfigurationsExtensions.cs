using SimpleLibraryApp.Core.Aggregates.ImageAggregates;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Repository.Dapper;
using SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;
using SimpleLibraryApp.Repository;
using SimpleLibraryApp.Core.Aggregates.FavouriteBookAggregates;
using SimpleLibraryApp.Core.Aggregates.CarouselItemAggregates;
using SimpleLibraryApp.Core.Aggregates.BookAggregates;

namespace SimpleLibraryApp.API;

public static class DependencyConfigurationsExtensions
{
    public static void ConfigureDependencies(this IServiceCollection services) {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<IBorrowOperationRepository, BorrowOperationRepository>();
        services.AddScoped<IFavouriteBookRepository, FavouriteBookRepository>();
        services.AddScoped<ICarouselItemRepository, CarouselItemRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
    }
}
