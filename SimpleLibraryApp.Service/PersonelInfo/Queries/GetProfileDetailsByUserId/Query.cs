using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetProfileDetailsByUserId;

public class Query : IRequest<GenericDataResponse<Dto>>
{
    public int UserId { get; set; }
}
