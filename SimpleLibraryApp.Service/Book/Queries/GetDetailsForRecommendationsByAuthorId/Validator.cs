using FluentValidation;

namespace SimpleLibraryApp.Service.Book.Queries.GetDetailsForRecommendationsByAuthorId;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Yazar Id değeri zorunludur");
    }
}
