namespace SimpleLibraryApp.Core.Aggregates.FavouriteBookAggregates;

public interface IFavouriteBookRepository
{
    Task<List<FavouriteBookDetailsForUser>> GetDetailsByUserIdAsync(int userId);
    Task<int> InsertFavouriteBookAsync(int userId, int bookId);
    Task<int> DeleteFavouriteBookByIdAsync(int idToDelete);
}
