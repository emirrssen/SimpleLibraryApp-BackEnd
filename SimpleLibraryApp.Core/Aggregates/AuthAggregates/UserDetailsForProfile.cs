namespace SimpleLibraryApp.Core.Aggregates.AuthAggregates;

public class UserDetailsForProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProfileImage { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime AccountStartDate { get; set; }
    public long ReadedBookNumber { get; set; }
    public long FavouriteBookNumber { get; set; }
}
