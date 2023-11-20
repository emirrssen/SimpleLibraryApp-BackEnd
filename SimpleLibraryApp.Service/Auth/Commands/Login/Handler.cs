using MediatR;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Auth.Commands.Login;

public class Handler : IRequestHandler<Command, GenericDataResponse<int>>
{
    private IAuthRepository _repo;

    public Handler(IAuthRepository repo)
    {
        _repo = repo;
    }

    public async Task<GenericDataResponse<int>> Handle(Command request, CancellationToken cancellationToken)
    {
        var userToCheck = await _repo.GetUserByEmailAsync(request.Email);

        if (userToCheck is null)
        {
            return ResponseFactory.FailResponse<int>(0, "Kullanıcı bulunamadı");
        }

        var isPasswordCorrect = userToCheck.Password == request.Password;

        if (!isPasswordCorrect)
        {
            return ResponseFactory.FailResponse<int>(0, "Şifre hatalı");
        }

        return ResponseFactory.SuccessResponse<int>(userToCheck.Id, "Giriş başarılı");
    }
}
