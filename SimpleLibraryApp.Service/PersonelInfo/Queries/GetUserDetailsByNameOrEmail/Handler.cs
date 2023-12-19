using MediatR;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetUserDetailsByNameOrEmail;

public class Handler : IRequestHandler<Query, GenericDataResponse<List<Dto>>>
{
    private readonly IAuthRepository _authRepository;

    public Handler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<GenericDataResponse<List<Dto>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var searchResult = await _authRepository.GetUserDetailsByNameOrEmail(request.SearchText);
        if (!searchResult.Any())
        {
            return ResponseFactory.FailResponse<List<Dto>>("Arama sonucu bulunamadı");
        }

        var dataToReturn = searchResult.Select(x => new Dto {
            Id = x.Id,
            Name = x.Name,
            Age = DateTime.Now.Year - x.DateOfBirth.Year,
            UserImage =  x.UserImage is not null ? ImageHelper.CreateImageUrl(x.UserImage) : "",
            AccountStartDate = x.AccountStartDate.ToString("dd.MM.yyyy"),
            CurrentReadedBookName = x.CurrentReadedBookName,
            DateOfBirth = x.DateOfBirth.ToString("dd.MM.yyyy"),
            Email = x.Email,
            TotalReadedBooks = x.TotalReadedBooks
        }).ToList();

        return ResponseFactory.SuccessResponse<List<Dto>>(dataToReturn, "Arama sonuçları başarıyla listelendi");
    }
}
