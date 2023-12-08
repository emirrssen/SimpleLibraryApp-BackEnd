using FluentValidation;

namespace SimpleLibraryApp.Service.FavouriteBook.Queries.GetDetailsByUserId;

public class Validator: AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id değeri zorunludur");
    }
}
