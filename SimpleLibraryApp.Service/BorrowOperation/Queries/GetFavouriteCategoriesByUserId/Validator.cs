using FluentValidation;

namespace SimpleLibraryApp.Service.BorrowOperation.Queries.GetFavouriteCategoriesByUserId;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Id değeri zorunludur");
    }
}
