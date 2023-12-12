using MediatR;
using SimpleLibraryApp.Core.Aggregates.BookAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsByBookId;

public class Handler : IRequestHandler<Query, GenericDataResponse<Dto>>
{
    private readonly IBookRepository _bookRepository;

    public Handler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GenericDataResponse<Dto>> Handle(Query request, CancellationToken cancellationToken)
    {
        var bookDetails = await _bookRepository.GetBookDetailsByIdAsync(request.BookId);

        if (bookDetails is null)
        {
            return ResponseFactory.FailResponse<Dto>("Kayıt bulunamadı");
        }

        var dataToReturn = new Dto {
            Id = bookDetails.Id,
            AuthorId = bookDetails.AuthorId,
            Author = bookDetails.Author,
            BookImage = ImageHelper.CreateImageUrl(bookDetails.BookImage),
            BookName = bookDetails.BookName,
            Category = bookDetails.Category,
            Description = bookDetails.Description,
            PageNumber = bookDetails.PageNumber,
            Publisher = bookDetails.Publisher,
            ReleaseYear = bookDetails.ReleaseYear
        };

        return ResponseFactory.SuccessResponse<Dto>(dataToReturn, "Veri başarıyla listelendi");
    }
}
