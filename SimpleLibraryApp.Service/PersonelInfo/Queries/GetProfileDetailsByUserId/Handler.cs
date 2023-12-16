using MediatR;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetProfileDetailsByUserId;

public class Handler : IRequestHandler<Query, GenericDataResponse<Dto>>
{
    private readonly IAuthRepository _authRepository;

    public Handler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<GenericDataResponse<Dto>> Handle(Query request, CancellationToken cancellationToken)
    {
        var profileDetails = await _authRepository.GetDetailsForProfileById(request.UserId);

        if (profileDetails is null)
        {
            return ResponseFactory.FailResponse<Dto>("İlgili kullanıcı için kayıt bulunamadı");
        }

        var dataToReturn = new Dto {
            Id = profileDetails.Id,
            Email = profileDetails.Email,
            Name = profileDetails.Name,
            ProfileImage = ImageHelper.CreateImageUrl(profileDetails.ProfileImage),
            AccountStartDate = profileDetails.AccountStartDate.ToString("dd.MM.yyyy"),
            DateOfBirth = profileDetails.DateOfBirth.ToString("dd.MM.yyyy"),
            FavouriteBookNumber = profileDetails.FavouriteBookNumber,
            ReadedBookNumber = profileDetails.ReadedBookNumber
        };

        return ResponseFactory.SuccessResponse<Dto>(dataToReturn, "Veriler başarıyla listelendi");
    }
}
