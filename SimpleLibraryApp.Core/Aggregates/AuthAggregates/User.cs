namespace SimpleLibraryApp.Core.Aggregates.AuthAggregates;

public class User
{
    public int GenderId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalityId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
