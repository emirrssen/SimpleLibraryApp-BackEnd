using System.Data;
using Dapper;
using SimpleLibraryApp.Core.Aggregates.BookAggregates;

namespace SimpleLibraryApp.Repository;

public class BookRepository : IBookRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public BookRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<List<BookDetailForRecommendation>> GetBookDetailByAuthorId(int authorId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@author_id", authorId, DbType.Int32);

        var sql = $@"SELECT * FROM  ""public"".""Books_GetDetailByAuthorId""(@author_id)";
        var result = await _connection.QueryAsync<BookDetailForRecommendation>(sql, parameters);

        return result.ToList();
    }

    public async Task<BookDetails> GetBookDetailsByIdAsync(int bookId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@book_id", bookId, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""Books_GetDetailsById""(@book_id)";
        var result = await _connection.QueryFirstOrDefaultAsync<BookDetails>(sql, parameters);

        return result;
    }

    public async Task<List<BookDetailForSearch>> GetBookDetailsByNameAsync(string bookName)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@book_name", bookName, DbType.String);

        var sql = $@"SELECT * FROM ""public"".""Books_GetByName""(@book_name)";
        var result = await _connection.QueryAsync<BookDetailForSearch>(sql, parameters);

        return result.ToList();
    }

    public async Task<List<BookDetailForSearch>> GetBooksByFiltersAsync(int[]? categoryFilters, int[]? authorFilters, int[]? releaseYearFilters)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@category_filters", categoryFilters, DbType.Object);
        parameters.Add("@author_filters", authorFilters, DbType.Object);
        parameters.Add("@release_year_filters", releaseYearFilters, DbType.Object);

        var sql = $@"SELECT * FROM ""public"".""Books_GetByFilters""(@category_filters, @author_filters, @release_year_filters)";
        var result = await _connection.QueryAsync<BookDetailForSearch>(sql, parameters);

        return result.ToList();
    }

    public async Task<List<ReleaseYearForFilter>> GetReleaseYearsForFilterAsync()
    {
        var sql = $@"SELECT * FROM ""public"".""Books_GetReleaseYears""()";
        var result = await _connection.QueryAsync<ReleaseYearForFilter>(sql);

        return result.ToList();
    }
}
