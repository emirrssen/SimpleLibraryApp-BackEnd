using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.CarouselItem.Queries.GetAllWithDetails;

public class Query: IRequest<GenericDataResponse<List<Dto>>>
{
}
