using System.Reflection;
using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.BorrowOperation.Queries.GetReadedBooksByUserId;

public class Query : IRequest<GenericDataResponse<List<Dto>>>
{
    public int UserId { get; set; }
}
