using MediatR;
using SimpleLibraryApp.Core.Aggregates.BookAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsByFilters;

public class Handler : IRequestHandler<Query, GenericDataResponse<List<Dto>>>
{
    private readonly IBookRepository _bookRepository;

    public Handler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GenericDataResponse<List<Dto>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var categoryFilters = request.CategoryFilters?.Length > 0 ? request.CategoryFilters : null;
        var authorFilters = request.AuthorFilters?.Length > 0 ? request.AuthorFilters : null;
        var releaseYearFilters = request.ReleaseYearFilters?.Length > 0 ? request.ReleaseYearFilters : null;

        var filteredBooks = await _bookRepository.GetBooksByFiltersAsync(categoryFilters, authorFilters, releaseYearFilters);

        if (!filteredBooks.Any())
        {
            return ResponseFactory.FailResponse<List<Dto>>("Kayıt bulunamadı");
        }

        var dataToReturn = filteredBooks.Select(x => new Dto {
            Id = x.Id,
            BookName = x.BookName,
            BookImage = ImageHelper.CreateImageUrl(x.BookImage),
            PageNumber = x.PageNumber,
            Description = x.Description
        }).ToList();

        return ResponseFactory.SuccessResponse<List<Dto>>(dataToReturn, "Veriler başarıyla listelendi");
    }
}
