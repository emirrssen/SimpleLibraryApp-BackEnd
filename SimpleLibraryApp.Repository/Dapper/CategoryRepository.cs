using System.Data;
using Dapper;
using SimpleLibraryApp.Core.Aggregates.CategoryAggregates;

namespace SimpleLibraryApp.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public CategoryRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<List<CategoryForFilter>> GetCategoriesForFilterAsync()
    {
        var sql = $@"SELECT * FROM ""public"".""Categories_GetAll""()";
        var result = await _connection.QueryAsync<CategoryForFilter>(sql);

        return result.ToList();
    }
}
