using MediatR;
using SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetFavouriteCategoriesByUserId;

public class QueryHandler : IRequestHandler<Query, GenericDataResponse<List<string>>>
{
    private readonly IBorrowOperationRepository _borrowOperationRepository;

    public QueryHandler(IBorrowOperationRepository borrowOperationRepository)
    {
        _borrowOperationRepository = borrowOperationRepository;
    }

    public async Task<GenericDataResponse<List<string>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var readedBooks = await _borrowOperationRepository.GetReadedBooksWithCategoryByUserId(request.UserId);
        if (!readedBooks.Any())
        {   
            return ResponseFactory.FailResponse<List<string>>("Okunmuş kitap bulunamadı");
        }

        var favouriteCategories = readedBooks
            .GroupBy(book => book.CategoryName)
            .OrderByDescending(group => group.Count())
            .Take(5)
            .Select(group => new { CategoryName = group.Key });
        
        return ResponseFactory.SuccessResponse<List<string>>(favouriteCategories.Select(x => x.CategoryName).ToList(), "Kategoriler başarılı bir şekilde listelendi");
    }
}
