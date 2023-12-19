namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetUserDetailsByNameOrEmail;

public class Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public int Age { get; set; }
    public string UserImage { get; set; }
    public long TotalReadedBooks { get; set; }
    public string? CurrentReadedBookName { get; set; }
    public string AccountStartDate { get; set; }
    public string Email { get; set; }
}
