namespace SimpleLibraryApp.Core.Aggregates.ImageAggregates;

public interface IImageRepository
{
    Task<Image> GetByIdAsync(int id);
    Task<int> InsertAsync(Image image); 
}
