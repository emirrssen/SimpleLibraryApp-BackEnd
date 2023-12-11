using System.Reflection;
using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetReadedBooksByUserId;

public class Query : IRequest<GenericDataResponse<List<Dto>>>
{
    public int UserId { get; set; }
}
