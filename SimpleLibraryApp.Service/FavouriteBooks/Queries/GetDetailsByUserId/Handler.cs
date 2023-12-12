using AutoMapper;
using MediatR;
using SimpleLibraryApp.Core.Aggregates.FavouriteBookAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.FavouriteBooks.Queries.GetDetailsByUserId;

public class Handler : IRequestHandler<Query, GenericDataResponse<List<Dto>>>
{
    private readonly IFavouriteBookRepository _favouriteBookRepository;

    public Handler(IFavouriteBookRepository favouriteBookRepository, IMapper mapper)
    {
        _favouriteBookRepository = favouriteBookRepository;
        
    }

    public async Task<GenericDataResponse<List<Dto>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var result = await _favouriteBookRepository.GetDetailsByUserIdAsync(request.UserId);

        if (!result.Any())
        {
            return ResponseFactory.FailResponse<List<Dto>>("Kullanıcı bulunamadı");
        }

        var resultToReturn = result.Select(x => new Dto {
            Id = x.Id,
            BookId = x.BookId,
            BookName = x.BookName,
            BookImage = ImageHelper.CreateImageUrl(x.BookImage)
        }).ToList();

        return ResponseFactory.SuccessResponse<List<Dto>>(resultToReturn, "Veriler başarılı bir şekilde yüklendi");
    }
}
