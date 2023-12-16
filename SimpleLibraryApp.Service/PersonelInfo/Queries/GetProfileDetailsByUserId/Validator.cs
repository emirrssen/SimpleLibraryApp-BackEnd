using FluentValidation;

namespace SimpleLibraryApp.Service.PersonelInfo.Queries.GetProfileDetailsByUserId;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Id değeri zorunludur");
    }
}
