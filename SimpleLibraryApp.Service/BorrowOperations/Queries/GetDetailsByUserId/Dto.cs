namespace SimpleLibraryApp.Service.BorrowOperations.Queries.GetDetailsByUserId;

public class Dto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public string BookImage { get; set; }
    public string Author { get; set; }
    public short PageNumber { get; set; }
    public string BookCategory { get; set; }
    public string BorrowedDate { get; set; }
    public string ReturnedDate { get; set; }
}
