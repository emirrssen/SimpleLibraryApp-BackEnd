namespace SimpleLibraryApp.Core.Aggregates.FavouriteBookAggregates;

public interface IFavouriteBookRepository
{
    Task<List<FavouriteBookDetailsForUser>> GetDetailsByUserIdAsync(int userId);
}
