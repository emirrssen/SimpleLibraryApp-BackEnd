namespace SimpleLibraryApp.Core.Aggregates.BookAggregates;

public class BookDetailForSearch
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public string BookImage { get; set; }
    public short PageNumber { get; set; }
    public string Description { get; set; }
}
