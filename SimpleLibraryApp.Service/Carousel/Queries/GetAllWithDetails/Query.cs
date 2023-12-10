using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Carousel.Queries.GetAllWithDetails;

public class Query: IRequest<GenericDataResponse<List<Dto>>>
{
}
