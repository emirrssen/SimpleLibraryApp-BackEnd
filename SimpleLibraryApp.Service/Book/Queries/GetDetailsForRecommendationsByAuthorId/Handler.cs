using MediatR;
using SimpleLibraryApp.Core.Aggregates.BookAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsForRecommendationsByAuthorId;

public class Handler : IRequestHandler<Query, GenericDataResponse<List<Dto>>>
{
    private readonly IBookRepository _bookRepository;

    public Handler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GenericDataResponse<List<Dto>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetBookDetailByAuthorId(request.AuthorId);

        if (!books.Any())
        {
            return ResponseFactory.FailResponse<List<Dto>>("Veri bulunamadı");
        }

        var dataToReturn = books.Select(x => new Dto {
           Id = x.Id,
           BookName = x.BookName,
           BookImage = ImageHelper.CreateImageUrl(x.BookImage) 
        }).ToList();

        return ResponseFactory.SuccessResponse<List<Dto>>(dataToReturn, "Veriler başarıyla listelendi");
    }
}
