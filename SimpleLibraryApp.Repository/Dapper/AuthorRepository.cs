using System.Data;
using Dapper;
using SimpleLibraryApp.Core.Aggregates.AuthorAggregates;

namespace SimpleLibraryApp.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public AuthorRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<List<AuthorForFilter>> GetAuthorsForFilterAsync()
    {
        var sql = $@"SELECT * FROM ""public"".""Authors_GetAll""()";
        var result = await _connection.QueryAsync<AuthorForFilter>(sql);

        return result.ToList();
    }
}
