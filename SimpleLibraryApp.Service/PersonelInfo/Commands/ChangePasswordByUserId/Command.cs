using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Commands.ChangePasswordByUserId;

public class Command : IRequest<BaseResponse>
{
    public int UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string NewPasswordRepeat { get; set; }
}
