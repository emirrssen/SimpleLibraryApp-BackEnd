namespace SimpleLibraryApp.Core.Aggregates.BookAggregates;

public interface IBookRepository
{
    Task<List<BookDetailForSearch>> GetBookDetailsByNameAsync(string bookName);
    Task<List<ReleaseYearForFilter>> GetReleaseYearsForFilterAsync();
    Task<List<BookDetailForSearch>> GetBooksByFiltersAsync(int[]? categoryFilters, int[]? authorFilters, int[]? releaseYearFilters);
}
