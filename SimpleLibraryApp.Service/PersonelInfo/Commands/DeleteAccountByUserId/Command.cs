using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Commands.DeleteAccountByUserId;

public class Command : IRequest<BaseResponse>
{
    public int UserId { get; set; }
}
