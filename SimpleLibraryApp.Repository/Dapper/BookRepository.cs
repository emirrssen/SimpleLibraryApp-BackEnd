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

    public async Task<List<BookDetailForSearch>> GetBookDetailsByNameAsync(string bookName)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@book_name", bookName, DbType.String);

        var sql = $@"SELECT * FROM ""public"".""Books_GetByName""(@book_name)";
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
