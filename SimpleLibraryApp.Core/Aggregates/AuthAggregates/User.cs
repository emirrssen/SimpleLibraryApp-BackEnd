namespace SimpleLibraryApp.Core.Aggregates.AuthAggregates;

public class User
{
    public int Id { get; set; }
    public int GenderId { get; set; }
    public int ImageId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalityId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime AccountStartDate { get; set; }
    public DateTime? AccountEndDate { get; set; }
}
