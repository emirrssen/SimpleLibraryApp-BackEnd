namespace SimpleLibraryApp.Service.Book.Queries.GetFilters;

public class Dto
{
    public List<CategoryFilter> CategoryFilter { get; set; }
    public List<AuthorFilter> AuthorFilter { get; set; }
    public List<ReleaseYearFilter> ReleaseYearFilter { get; set; }
}

public class CategoryFilter {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsSelected { get; set; }
}

public class AuthorFilter {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsSelected { get; set; }
}

public class ReleaseYearFilter {
    public int Id { get; set; }
    public string ReleaseYear { get; set; }
    public bool IsSelected { get; set; }
}
