using MediatR;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using AutoMapper;
using System.Data;
using SimpleLibraryApp.Core.Response;
using System.Diagnostics;

namespace SimpleLibraryApp.Service.Auth.Commands.Register;

public class Handler : IRequestHandler<Command, GenericDataResponse<int>>
{
    private readonly IAuthRepository _repository;
    private readonly IMapper _mapper;
    private readonly IDbTransaction _transaction;

    public Handler(IAuthRepository repository, IMapper mapper, IDbTransaction transaction)
    {
        _repository = repository;
        _mapper = mapper;
        _transaction = transaction;
    }

    public async Task<GenericDataResponse<int>> Handle(Command request, CancellationToken cancellationToken)
    {
        var userToCheck = await _repository.GetUserByEmailAsync(request.Email);

        if (userToCheck is not null)
        {
            _transaction.Rollback();
            return ResponseFactory.FailResponse<int>(0, "Kullanıcı zaten mevcut");
        }

        var insertResult = await _repository.InsertUserAsync(_mapper.Map<User>(request));

        if (insertResult <= 0)
        {
            _transaction.Rollback();
            return ResponseFactory.FailResponse<int>(0, "Kullanıcı eklenemedi");
        }

        var defaultClaimInsertResult = await _repository.InsertUserRoleAssignmentAsync(new UserRoleAssignment() {
            UserId = insertResult,
            RoleId = 2,
            CreatedDate = DateTime.Now
        });

        if (defaultClaimInsertResult <= 0)
        {
            _transaction.Rollback();
            return ResponseFactory.FailResponse<int>(0, "Kayıt esnasında bir hata meydana geldi");
        }

        _transaction.Commit();
        return ResponseFactory.SuccessResponse<int>(insertResult, "Kayıt işlemi başarılı");
    }
}
