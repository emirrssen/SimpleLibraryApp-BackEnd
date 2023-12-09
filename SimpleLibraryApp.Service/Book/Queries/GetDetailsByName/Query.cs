using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsByName;

public class Query : IRequest<GenericDataResponse<List<Dto>>>
{
    public string? BookName { get; set; }
}
