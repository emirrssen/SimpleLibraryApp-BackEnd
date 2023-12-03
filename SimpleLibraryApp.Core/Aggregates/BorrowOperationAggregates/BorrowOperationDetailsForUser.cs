namespace SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;

public class BorrowOperationDetailsForUser
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
