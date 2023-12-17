using FluentValidation;

namespace SimpleLibraryApp.Service.PersonelInfo.Commands.ChangePasswordByUserId;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Id değeri zorunludur");
        RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Eski şifre zorunludur");
        RuleFor(x => x.NewPasswordRepeat)
            .MaximumLength(40).WithMessage("Şifre tekrarı maksimum karakter sınırını aşmaktadır")
            .NotEmpty().WithMessage("Şifre tekrarı zorunludur");
        RuleFor(x => x.NewPassword)
            .MaximumLength(40).WithMessage("Şifre maksimum karakter sınırını aşmaktadır")
            .Equal(x => x.NewPasswordRepeat).WithMessage("İki şifre de aynı olmalıdır")
            .NotEmpty().WithMessage("Yeni şifre zorunludur");
    }
}
