using System.Data;
using MediatR;
using SimpleLibraryApp.Core;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Auth.Queries.LoadPersonelInfo;

public class Handler : IRequestHandler<Query, GenericDataResponse<Dto>>
{
    private readonly IAuthRepository _authRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IDbTransaction _transaction;

    public Handler(IAuthRepository authRepository, IDbTransaction transaction, IImageRepository imageRepository)
    {
        _authRepository = authRepository;
        _transaction = transaction;
        _imageRepository = imageRepository;
    }

    public async Task<GenericDataResponse<Dto>> Handle(Query request, CancellationToken cancellationToken)
    {
        var dtoToReturn = new Dto();
        var currentUser = await _authRepository.GetById(request.UserId);

        if (currentUser is null)
        {
            return ResponseFactory.FailResponse<Dto>(dtoToReturn, "Kullanıcı mevcut değil");
        }

        var imageName = await _imageRepository.GetByIdAsync(currentUser.ImageId);

        dtoToReturn.FirstName = currentUser.FirstName;
        dtoToReturn.LastName = currentUser.LastName;
        dtoToReturn.Age = DateTime.Now.Year - currentUser.DateOfBirth.Year;
        dtoToReturn.ProfileImageUrl = "http://localhost:5158/UserImages/" + imageName.ImageName;

        return ResponseFactory.SuccessResponse<Dto>(dtoToReturn, "Bilgiler başarılı bir şekilde yüklendi");
    }
}
