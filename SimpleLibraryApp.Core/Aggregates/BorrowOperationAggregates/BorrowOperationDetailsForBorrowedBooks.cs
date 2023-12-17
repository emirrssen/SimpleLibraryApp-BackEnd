namespace SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;

public class BorrowOperationDetailsForBorrowedBooks
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public string BookImage { get; set; }
    public string Author { get; set; }
    public short PageNumber { get; set; }
    public string BookCategory { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime ReturnedDate { get; set; }
}
