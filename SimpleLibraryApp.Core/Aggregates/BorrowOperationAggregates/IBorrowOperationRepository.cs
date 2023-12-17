namespace SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;

public interface IBorrowOperationRepository
{
    Task<List<BorrowOperationDetailsForUser>> GetDetailsForUserByUserIdAsync(int userId);
    Task<List<BorrowOperationDetailsForReadedBooksByUser>> GetReadedBooksByUserIdAsync(int userId);
    Task<List<BorrowOperationDetailsForFavouriteCategoriesByUser>> GetReadedBooksWithCategoryByUserIdAsync(int userId);
    Task<List<BorrowOperationDetailsForBorrowedBooks>> GetBorrowedBookDetailsByUserIdAsync(int userId);
}
