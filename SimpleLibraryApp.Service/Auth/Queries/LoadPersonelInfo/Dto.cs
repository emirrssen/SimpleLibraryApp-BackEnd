namespace SimpleLibraryApp.Service.Auth.Queries.LoadPersonelInfo;

public class Dto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string ProfileImageUrl { get; set; }
    public int NumberOfBookReaded { get; set; }
    public string[] BookNamesCurrentlyReading { get; set; }
}
