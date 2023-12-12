namespace SimpleLibraryApp.Core.Aggregates.BookAggregates;

public class BookDetails
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public string Description { get; set; }
    public string BookImage { get; set; }
    public short PageNumber { get; set; }
    public string Author { get; set; }
    public string ReleaseYear { get; set; }
    public string Category { get; set; }
    public string Publisher { get; set; }
}
