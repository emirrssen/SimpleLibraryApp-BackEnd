using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.FavouriteBooks.Commands.Delete;

public class Command : IRequest<BaseResponse>
{
    public int IdToDelete { get; set; }
}
