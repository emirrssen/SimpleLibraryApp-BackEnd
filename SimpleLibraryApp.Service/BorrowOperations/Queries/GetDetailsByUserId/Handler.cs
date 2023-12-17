using MediatR;
using SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.BorrowOperations.Queries.GetDetailsByUserId;

public class Handler : IRequestHandler<Query, GenericDataResponse<List<Dto>>>
{
    private readonly IBorrowOperationRepository _borrowOperationRepository;

    public Handler(IBorrowOperationRepository borrowOperationRepository)
    {
        _borrowOperationRepository = borrowOperationRepository;
    }

    public async Task<GenericDataResponse<List<Dto>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var borrowedBooks = await _borrowOperationRepository.GetBorrowedBookDetailsByUserIdAsync(request.UserId);

        if (!borrowedBooks.Any())
        {
            return ResponseFactory.FailResponse<List<Dto>>("Ödünç alınmış kitap bulunamadı");
        }

        var dataToReturn = borrowedBooks.Select(x => new Dto {
            Id = x.Id,
            BookId = x.BookId,
            BookName = x.BookName,
            BookImage = ImageHelper.CreateImageUrl(x.BookImage),
            BookCategory = x.BookCategory,
            Author = x.Author,
            BorrowedDate = x.BorrowedDate.ToString("dd.MM.yyyy"),
            ReturnedDate = x.ReturnedDate.ToString("dd.MM.yyyy"),
            PageNumber = x.PageNumber
        }).ToList();

        return ResponseFactory.SuccessResponse<List<Dto>>(dataToReturn, "Kitaplar başarıyla listelendi");
    }
}
