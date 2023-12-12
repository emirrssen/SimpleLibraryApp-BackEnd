using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.FavouriteBooks.Commands.Insert;

public class Command : IRequest<BaseResponse>
{
    public int UserId { get; set; }
    public int BookId { get; set; }
}
