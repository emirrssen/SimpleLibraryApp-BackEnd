using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetFilters;

public class Query : IRequest<GenericDataResponse<Dto>>
{
}
