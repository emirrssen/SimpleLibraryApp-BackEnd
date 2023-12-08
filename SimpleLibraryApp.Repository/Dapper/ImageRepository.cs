using System.Data;
using Dapper;
using SimpleLibraryApp.Core.Aggregates.ImageAggregates;

namespace SimpleLibraryApp.Repository.Dapper;

public class ImageRepository : IImageRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public ImageRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<Image> GetByIdAsync(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@id", id, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""Images_GetById""(@id)";
        var result = await _connection.QuerySingleOrDefaultAsync<Image>(sql, parameters);

        return result;
    }

    public async Task<int> InsertAsync(Image image)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@image_name", image.ImageName, DbType.String);

        var sql = $@"SELECT * FROM ""public"".""Images_Insert""(@image_name)";
        var result = await _connection.QuerySingleOrDefaultAsync<int>(sql, parameters, transaction: _transaction);

        return result;
    }
}
