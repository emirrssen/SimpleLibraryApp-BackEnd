using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsByBookId;

public class Query : IRequest<GenericDataResponse<Dto>>
{
    public int BookId { get; set; }
}
