using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Auth.Queries.LoadPersonelInfo;

public class Query : IRequest<GenericDataResponse<Dto>>
{
    public int UserId { get; set; }
}
