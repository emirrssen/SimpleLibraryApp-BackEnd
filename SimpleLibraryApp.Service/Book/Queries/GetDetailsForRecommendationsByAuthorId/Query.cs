using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsForRecommendationsByAuthorId;

public class Query : IRequest<GenericDataResponse<List<Dto>>>
{
    public int AuthorId { get; set; }
}
