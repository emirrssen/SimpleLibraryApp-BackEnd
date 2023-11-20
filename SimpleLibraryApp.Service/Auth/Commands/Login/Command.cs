using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Auth.Commands.Login;

public class Command: IRequest<GenericDataResponse<int>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
