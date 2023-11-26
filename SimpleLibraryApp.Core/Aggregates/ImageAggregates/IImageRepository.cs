namespace SimpleLibraryApp.Core;

public interface IImageRepository
{
    Task<Image> GetByIdAsync(int id);
    Task<int> InsertAsync(Image image); 
}
