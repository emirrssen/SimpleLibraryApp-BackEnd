namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetProfileDetailsByUserId;

public class Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProfileImage { get; set; }
    public string Email { get; set; }
    public string DateOfBirth { get; set; }
    public string AccountStartDate { get; set; }
    public long ReadedBookNumber { get; set; }
    public long FavouriteBookNumber { get; set; }
}
