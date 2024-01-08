using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Commands.ChangeEmailByUserId;

public class Command : IRequest<BaseResponse>
{
    public int UserId { get; set; }
    public string NewEmail { get; set; }
}
