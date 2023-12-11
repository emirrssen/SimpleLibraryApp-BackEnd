using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsByFilters;

public class Query : IRequest<GenericDataResponse<List<Dto>>>
{
    public int[]? CategoryFilters { get; set; }
    public int[]? AuthorFilters { get; set; }
    public int[]? ReleaseYearFilters { get; set; }
}
