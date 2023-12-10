namespace SimpleLibraryApp.Core.Aggregates.CategoryAggregates;

public interface ICategoryRepository
{
    Task<List<CategoryForFilter>> GetCategoriesForFilterAsync();
}
