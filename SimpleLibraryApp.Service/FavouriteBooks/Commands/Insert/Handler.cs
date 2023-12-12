using System.Data;
using MediatR;
using SimpleLibraryApp.Core.Aggregates.FavouriteBookAggregates;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.FavouriteBooks.Commands.Insert;

public class Handler : IRequestHandler<Command, BaseResponse>
{
    private readonly IFavouriteBookRepository _favouriteBookRepository;
    private readonly IDbTransaction _transaction;

    public Handler(IFavouriteBookRepository favouriteBookRepository, IDbTransaction transaction)
    {
        _favouriteBookRepository = favouriteBookRepository;
        _transaction = transaction;
    }

    public async Task<BaseResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        var result = await _favouriteBookRepository.InsertFavouriteBookAsync(request.UserId, request.BookId);

        if (result == 0)
        {
            _transaction.Dispose();
            return ResponseFactory.FailResponse("Ekleme işlemi başarısız");
        }

        _transaction.Commit();
        return ResponseFactory.SuccessResponse("Ekleme işlemi başarılı");
    }
}
