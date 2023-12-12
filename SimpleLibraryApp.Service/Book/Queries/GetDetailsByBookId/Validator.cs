using FluentValidation;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsByBookId;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.BookId).NotEmpty().WithMessage("Kitap Id değeri zorunludur");
    }
}
