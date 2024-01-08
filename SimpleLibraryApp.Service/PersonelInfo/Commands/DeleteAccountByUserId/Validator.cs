using FluentValidation;

namespace SimpleLibraryApp.Service.PersonelInfo.Commands.DeleteAccountByUserId;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Id değeri zorunludur");
    }
}
