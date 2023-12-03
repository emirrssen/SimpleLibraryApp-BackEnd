using System.Data;
using Dapper;
using SimpleLibraryApp.Core.Aggregates.CarouselItemAggregates;

namespace SimpleLibraryApp.Repository;

public class CarouselItemRepository : ICarouselItemRepository
{
    private readonly IDbConnection _connection;

    public CarouselItemRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<CarouselItemDetails>> GetAllWithDetailsAsync()
    {
        var sql = $@"SELECT * FROM ""public"".""CarouselItems_GetAllWithDetails""()";
        var result = await _connection.QueryAsync<CarouselItemDetails>(sql);

        return result.ToList();
    }
}
