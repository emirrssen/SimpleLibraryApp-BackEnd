using System.Data;
using MediatR;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Commands.ChangePasswordByUserId;

public class Handler : IRequestHandler<Command, BaseResponse>
{
    private readonly IAuthRepository _authRepository;
    private readonly IDbTransaction _transaction;

    public Handler(IAuthRepository authRepository, IDbTransaction transaction)
    {
        _authRepository = authRepository;
        _transaction = transaction;
    }

    public async Task<BaseResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        var currentUser = await _authRepository.GetById(request.UserId);
        if (currentUser is null)
        {   
            _transaction.Rollback();
            return ResponseFactory.FailResponse("Kullanıcı bulunamadı");
        }

        if (currentUser.Password != request.OldPassword)
        {
            _transaction.Rollback();
            return ResponseFactory.FailResponse("Eski şifreniz yanlış");
        }

        var updateResult = await _authRepository.ChangePasswordByUserIdAsync(request.UserId, request.NewPassword);
        if (updateResult == 0)
        {
            _transaction.Rollback();
            return ResponseFactory.FailResponse("Güncelleme işlemi başarısız");
        }

        _transaction.Commit();
        return ResponseFactory.SuccessResponse("Şifre başarıyla güncelleştirilmiştir");
    }
}
