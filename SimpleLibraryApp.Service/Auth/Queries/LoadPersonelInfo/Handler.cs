using System.Data;
using MediatR;
using SimpleLibraryApp.Core.Aggregates.ImageAggregates;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;
using SimpleLibraryApp.Core.Response;
using SimpleLibraryApp.Core.Aggregates.BorrowOperationAggregates;

namespace SimpleLibraryApp.Service.Auth.Queries.LoadPersonelInfo;

public class Handler : IRequestHandler<Query, GenericDataResponse<Dto>>
{
    private readonly IAuthRepository _authRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IBorrowOperationRepository _borrowOperationsRepository;
    private readonly IDbTransaction _transaction;

    public Handler(IAuthRepository authRepository, IDbTransaction transaction, IImageRepository imageRepository, IBorrowOperationRepository borrowOperationsRepository)
    {
        _authRepository = authRepository;
        _transaction = transaction;
        _imageRepository = imageRepository;
        _borrowOperationsRepository = borrowOperationsRepository;
    }

    public async Task<GenericDataResponse<Dto>> Handle(Query request, CancellationToken cancellationToken)
    {
        var dtoToReturn = new Dto();
        var currentUser = await _authRepository.GetById(request.UserId);

        if (currentUser is null)
        {
            return ResponseFactory.FailResponse<Dto>(dtoToReturn, "Kullanıcı mevcut değil");
        }

        var imageName = await _imageRepository.GetByIdAsync(currentUser.ImageId);

        if (imageName is not null)
        {
            dtoToReturn.ProfileImageUrl = "http://localhost:5158/UserImages/" + imageName.ImageName;
        }

        var bookBorrowDetails = await _borrowOperationsRepository.GetDetailsForUserByUserIdAsync(request.UserId);

        if (bookBorrowDetails is not null)
        {
            dtoToReturn.NumberOfBookReaded = bookBorrowDetails.Where(x => x.ReturnDate is not null).Count();
            dtoToReturn.BookNamesCurrentlyReading = bookBorrowDetails.Where(x => x.ReturnDate is null).Select(x => x.BookName).ToArray();
        }

        dtoToReturn.FirstName = currentUser.FirstName;
        dtoToReturn.LastName = currentUser.LastName;
        dtoToReturn.Age = DateTime.Now.Year - currentUser.DateOfBirth.Year;

        return ResponseFactory.SuccessResponse<Dto>(dtoToReturn, "Bilgiler başarılı bir şekilde yüklendi");
    }
}
