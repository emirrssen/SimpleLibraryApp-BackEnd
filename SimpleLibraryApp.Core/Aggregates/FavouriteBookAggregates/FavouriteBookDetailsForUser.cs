namespace SimpleLibraryApp.Core.Aggregates.FavouriteBookAggregates;

public class FavouriteBookDetailsForUser
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public string BookImage { get; set; }
}
