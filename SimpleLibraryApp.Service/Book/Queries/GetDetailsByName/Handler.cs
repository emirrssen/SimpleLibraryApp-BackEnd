using MediatR;
using SimpleLibraryApp.Core.Aggregates.BookAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsByName;

public class Handler : IRequestHandler<Query, GenericDataResponse<List<Dto>>>
{
    private readonly IBookRepository _bookRepository;

    public Handler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GenericDataResponse<List<Dto>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var searchedBooks = await _bookRepository.GetBookDetailsByNameAsync(request.BookName);
        if (!searchedBooks.Any())
        {
            return ResponseFactory.FailResponse<List<Dto>>("Aradığınız isimde kitap bulunamadı");
        }

        var dataToReturn = searchedBooks.Select(x => new Dto {
            Id = x.Id,
            BookName = x.BookName,
            BookImage = ImageHelper.CreateImageUrl(x.BookImage),
            PageNumber = x.PageNumber,
            Description = x.Description
        }).ToList();

        return ResponseFactory.SuccessResponse<List<Dto>>(dataToReturn, "Kitaplar başarıyla listelendi");
    }
}
