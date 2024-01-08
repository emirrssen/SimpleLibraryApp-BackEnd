using System.Data;
using MediatR;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Commands.DeleteAccountByUserId;

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
        var userToDelete = await _authRepository.GetByIdAsync(request.UserId);

        if (userToDelete is null)
        {
            _transaction.Rollback();
            return ResponseFactory.FailResponse("Kullanıcı bulunamadı");
        }

        if (userToDelete.AccountEndDate is not null)
        {
            _transaction.Rollback();
            return ResponseFactory.FailResponse("Kullanıcı hesabı zaten kapalı");
        }

        var result = await _authRepository.DeleteAccountByUserIdAsync(request.UserId);

        if (result == 0)
        {
            _transaction.Rollback();
            return ResponseFactory.FailResponse("Hesap kapatma işlemi başarısız");
        }

        _transaction.Commit();
        return ResponseFactory.SuccessResponse("Hesap kapatma işlemi başarılı");
    }
}
