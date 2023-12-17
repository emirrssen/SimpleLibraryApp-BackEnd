using FluentValidation;

namespace SimpleLibraryApp.Service.BorrowOperations.Queries.GetDetailsByUserId;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Id değeri zorunludur");
    }
}
