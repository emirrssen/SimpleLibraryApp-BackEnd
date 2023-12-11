namespace SimpleLibraryApp.Core.Aggregates.AuthorAggregates;

public interface IAuthorRepository
{
    Task<List<AuthorForFilter>> GetAuthorsForFilterAsync();
}
