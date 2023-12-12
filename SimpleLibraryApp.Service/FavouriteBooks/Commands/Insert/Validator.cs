using FluentValidation;

namespace SimpleLibraryApp.Service.FavouriteBooks.Commands.Insert;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Id değeri boş olamaz");
        RuleFor(x => x.BookId).NotEmpty().WithMessage("Kitap seçimi zorunludur");
    }
}
