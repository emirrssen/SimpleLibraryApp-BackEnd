using System.Data;
using Dapper;
using SimpleLibraryApp.Core.Aggregates.FavouriteBookAggregates;

namespace SimpleLibraryApp.Repository;

public class FavouriteBookRepository : IFavouriteBookRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public FavouriteBookRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<List<FavouriteBookDetailsForUser>> GetDetailsByUserIdAsync(int userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@user_id", userId, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""FavouriteBooks_GetDetailsByUserId""(@user_id)";
        var result = await _connection.QueryAsync<FavouriteBookDetailsForUser>(sql, parameters);

        return result.ToList();
    }
}
