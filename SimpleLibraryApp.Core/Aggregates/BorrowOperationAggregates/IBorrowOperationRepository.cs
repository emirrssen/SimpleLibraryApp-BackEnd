namespace SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;

public interface IBorrowOperationRepository
{
    Task<List<BorrowOperationDetailsForUser>> GetDetailsForUserByUserIdAsync(int userId);
    Task<List<BorrowOperationDetailsForReadedBooksByUser>> GetReadedBooksByUserId(int userId);
}
