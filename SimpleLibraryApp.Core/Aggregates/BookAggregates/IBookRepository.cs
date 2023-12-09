namespace SimpleLibraryApp.Core.Aggregates.BookAggregates;

public interface IBookRepository
{
    Task<List<BookDetailForSearch>> GetBookDetailsByNameAsync(string bookName);
}
