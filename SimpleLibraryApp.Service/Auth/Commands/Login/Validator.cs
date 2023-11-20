using FluentValidation;

namespace SimpleLibraryApp.Service.Auth.Commands.Login;

public class Validator: AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta zorunlu alandır.")
            .MaximumLength(100).WithMessage("E-posta karakter sınırını aşmaktadır.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre zorunlu alandır.")
            .MaximumLength(40).WithMessage("Şifre karakter sınırını aşmaktadır.");
    }
}
