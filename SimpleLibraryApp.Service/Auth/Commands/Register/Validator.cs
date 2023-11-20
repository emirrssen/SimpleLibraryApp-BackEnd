using FluentValidation;

namespace SimpleLibraryApp.Service.Auth.Commands.Register;

public class Validator: AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur.");

        RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim zorunludur.")
            .MaximumLength(100).WithMessage("İsim karakter sınırını aşmaktadır.");

        RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim zorunludur.")
            .MaximumLength(100).WithMessage("Soyisim karakter sınırını aşmaktadır.");

        RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Doğum tarihi zorunludur.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta zorunludur.")
            .MaximumLength(100).WithMessage("E-posta karakter sınırını aşmaktadır.")
            .EmailAddress().WithMessage("Lütfen geçerli bir e-posta giriniz.");

        RuleFor(x => x.NationalityId).NotEmpty().WithMessage("TC kimlik numarası zorunludur.")
            .Length(11).WithMessage("TC kimlik numarası 11 haneli olmalıdır.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre zorunludur.")
            .MaximumLength(40).WithMessage("Şifre karakter sınırını aşmaktadır.");

        RuleFor(x => x.PasswordRepeat).NotEmpty().WithMessage("Şifre zorunludur.")
            .MaximumLength(40).WithMessage("Şifre karakter sınırını aşmaktadır.")
            .Equal(x => x.Password).WithMessage("Şifreler aynı olmalıdır.");
    }
}
