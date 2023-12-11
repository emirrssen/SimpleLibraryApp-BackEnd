using FluentValidation;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.LoadPersonelInfo;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Id değeri zorunludur");
    }
}
