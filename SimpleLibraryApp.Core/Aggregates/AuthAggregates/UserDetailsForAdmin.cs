namespace SimpleLibraryApp.Core.Aggregates.AuthAggregates;

public class UserDetailsForAdmin
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string UserImage { get; set; }
    public long TotalReadedBooks { get; set; }
    public string? CurrentReadedBookName { get; set; }
    public DateTime AccountStartDate { get; set; }
    public string Email { get; set; }
}
