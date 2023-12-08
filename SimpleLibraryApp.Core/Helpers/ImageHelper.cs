namespace SimpleLibraryApp.Core.Helpers;

public static class ImageHelper
{
    public static string CreateImageUrl(string imageName) => "http://localhost:5158/UserImages/" + imageName;
}
