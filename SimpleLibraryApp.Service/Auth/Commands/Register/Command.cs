using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Auth.Commands.Register;

public class Command: IRequest<GenericDataResponse<int>>
{
    public int GenderId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string NationalityId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordRepeat { get; set; }
}
