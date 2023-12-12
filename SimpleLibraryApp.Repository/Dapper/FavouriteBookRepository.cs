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

    public async Task<int> DeleteFavouriteBookByIdAsync(int idToDelete)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@id", idToDelete, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""FavouriteBooks_DeleteById""(@id)";
        var result = await _connection.QueryFirstOrDefaultAsync<int>(sql, parameters, _transaction);

        return result;
    }

    public async Task<List<FavouriteBookDetailsForUser>> GetDetailsByUserIdAsync(int userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@user_id", userId, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""FavouriteBooks_GetDetailsByUserId""(@user_id)";
        var result = await _connection.QueryAsync<FavouriteBookDetailsForUser>(sql, parameters);

        return result.ToList();
    }

    public async Task<int> InsertFavouriteBookAsync(int userId, int bookId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@user_id", userId, DbType.Int32);
        parameters.Add("@book_id", bookId, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""FavouriteBooks_Insert""(@user_id, @book_id)";
        var result = await _connection.QueryFirstOrDefaultAsync<int>(sql, parameters, _transaction);

        return result;
    }
}
