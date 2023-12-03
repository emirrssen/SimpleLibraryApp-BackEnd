namespace SimpleLibraryApp.Core.Aggregates.CarouselItemAggregates;

public interface ICarouselItemRepository
{
    Task<List<CarouselItemDetails>> GetAllWithDetailsAsync();
}
