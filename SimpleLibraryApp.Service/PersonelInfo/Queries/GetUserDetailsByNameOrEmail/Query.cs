using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetUserDetailsByNameOrEmail;

public class Query : IRequest<GenericDataResponse<List<Dto>>>
{
    public string? SearchText { get; set; }
}
