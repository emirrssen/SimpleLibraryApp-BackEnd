using FluentValidation;

namespace SimpleLibraryApp.Service.PersonelInfo.Commands.ChangeEmailByUserId;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id değeri zorunludur");
        RuleFor(x => x.NewEmail).NotEmpty().WithMessage("Yeni email zorunludur");
    }
}
