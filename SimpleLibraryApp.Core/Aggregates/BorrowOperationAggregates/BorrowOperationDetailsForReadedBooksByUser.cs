namespace SimpleLibraryApp.Core;

public class BorrowOperationDetailsForReadedBooksByUser
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public string BookImage { get; set; }
}
