using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetFavouriteCategoriesByUserId;

public class Query : IRequest<GenericDataResponse<List<string>>>
{
    public int UserId { get; set; }
}
