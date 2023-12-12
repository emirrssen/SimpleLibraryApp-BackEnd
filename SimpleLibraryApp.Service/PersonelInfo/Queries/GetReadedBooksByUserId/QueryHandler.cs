using AutoMapper;
using MediatR;
using SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetReadedBooksByUserId;

public class QueryHandler : IRequestHandler<Query, GenericDataResponse<List<Dto>>>
{
    private readonly IBorrowOperationRepository _borrowOperationRepository;

    public QueryHandler(IBorrowOperationRepository borrowOperationRepository)
    {
        _borrowOperationRepository = borrowOperationRepository;
    }

    public async Task<GenericDataResponse<List<Dto>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var readedBooks = await _borrowOperationRepository.GetReadedBooksByUserId(request.UserId);

        if (!readedBooks.Any())
        {
            return ResponseFactory.FailResponse<List<Dto>>("Kayıt bulunamadı");
        }

        return ResponseFactory.SuccessResponse<List<Dto>>(readedBooks.Select(x => new Dto {
            Id = x.Id,
            BookId = x.BookId,
            BookName = x.BookName,
            BookImage = ImageHelper.CreateImageUrl(x.BookImage)
        }).ToList(), "Kayıtlar başarıyla listelendi");
    }
}
