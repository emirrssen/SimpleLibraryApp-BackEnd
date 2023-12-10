using MediatR;
using SimpleLibraryApp.Core.Aggregates.AuthorAggregates;
using SimpleLibraryApp.Core.Aggregates.BookAggregates;
using SimpleLibraryApp.Core.Aggregates.CategoryAggregates;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Book.Queries.GetFilters;

public class Handler : IRequestHandler<Query, GenericDataResponse<Dto>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IBookRepository _bookRepository;

    public Handler(IAuthorRepository authorRepository, ICategoryRepository categoryRepository, IBookRepository bookRepository)
    {
        _authorRepository = authorRepository;
        _categoryRepository = categoryRepository;
        _bookRepository = bookRepository;
    }

    public async Task<GenericDataResponse<Dto>> Handle(Query request, CancellationToken cancellationToken)
    {
        var authorFilters = await _authorRepository.GetAuthorsForFilterAsync();
        var categoryFilters = await _categoryRepository.GetCategoriesForFilterAsync();
        var releaseYearFilters = await _bookRepository.GetReleaseYearsForFilterAsync();

        var resultToReturn = new Dto {
            AuthorFilter = authorFilters.Select(x => new AuthorFilter { Id = x.Id, Name = x.Name }).ToList(),
            CategoryFilter = categoryFilters.Select(x => new CategoryFilter { Id = x.Id, Name = x.Name }).ToList(),
            ReleaseYearFilter = releaseYearFilters.Select(x => new ReleaseYearFilter { Id = x.Id, ReleaseYear = x.ReleaseYear }).ToList()
        };

        return ResponseFactory.SuccessResponse<Dto>(resultToReturn, "Filtreler başarıyla listelendi");
    }
}
