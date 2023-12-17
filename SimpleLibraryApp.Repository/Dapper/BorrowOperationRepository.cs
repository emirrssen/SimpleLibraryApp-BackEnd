using System.Data;
using Dapper;
using SimpleLibraryApp.Core;
using SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;

namespace SimpleLibraryApp.Repository;

public class BorrowOperationRepository : IBorrowOperationRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public BorrowOperationRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<List<BorrowOperationDetailsForBorrowedBooks>> GetBorrowedBookDetailsByUserIdAsync(int userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@user_id", userId, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""BorrowOperations_GetDetailsByUserId""(@user_id)";
        var result = await _connection.QueryAsync<BorrowOperationDetailsForBorrowedBooks>(sql, parameters);

        return result.ToList();
    }

    public async Task<List<BorrowOperationDetailsForUser>> GetDetailsForUserByUserIdAsync(int userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@user_id", userId, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""BorrowOperations_GetDetailsForUserByUserId""(@user_id)";
        var result = await _connection.QueryAsync<BorrowOperationDetailsForUser>(sql, parameters);

        return result.ToList();
    }

    public async Task<List<BorrowOperationDetailsForReadedBooksByUser>> GetReadedBooksByUserIdAsync(int userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@user_id", userId, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""BorrowOperations_GetReadedBooksByUserId""(@user_id)";
        var result = await _connection.QueryAsync<BorrowOperationDetailsForReadedBooksByUser>(sql, parameters);

        return result.ToList();
    }

    public async Task<List<BorrowOperationDetailsForFavouriteCategoriesByUser>> GetReadedBooksWithCategoryByUserIdAsync(int userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@user_id", userId, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""BorrowOperations_GetReadedBookDetailsByUserId""(@user_id)";
        var result = await _connection.QueryAsync<BorrowOperationDetailsForFavouriteCategoriesByUser>(sql, parameters);

        return result.ToList();
    }
}
