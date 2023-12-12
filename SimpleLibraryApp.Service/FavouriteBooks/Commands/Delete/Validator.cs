using FluentValidation;

namespace SimpleLibraryApp.Service.FavouriteBooks.Commands.Delete;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.IdToDelete).NotEmpty().WithMessage("Id değeri zorunludur");
    }
}
