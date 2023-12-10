using AutoMapper;
using MediatR;
using SimpleLibraryApp.Core.Aggregates.CarouselItemAggregates;
using SimpleLibraryApp.Core.Helpers;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.Carousel.Queries.GetAllWithDetails;

public class Handler : IRequestHandler<Query, GenericDataResponse<List<Dto>>>
{
    private readonly ICarouselItemRepository _carouselItemRepository;
    private readonly IMapper _mapper;

    public Handler(ICarouselItemRepository carouselItemRepository, IMapper mapper)
    {
        _carouselItemRepository = carouselItemRepository;
        _mapper = mapper;
    }

    public async Task<GenericDataResponse<List<Dto>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var result = await _carouselItemRepository.GetAllWithDetailsAsync();

        if (!result.Any())
        {
            return ResponseFactory.FailResponse<List<Dto>>("Veri bulunamadı");
        }

        var resultToReturn = result.Select(x => new Dto{
            Id = x.Id,
            Image = ImageHelper.CreateImageUrl(x.Image),
            IsVisible = x.IsVisible,
            QueueNumber = x.QueueNumber
        }).ToList();
        
        return ResponseFactory.SuccessResponse<List<Dto>>(resultToReturn, "Veriler başarılı bir şekilde listelendi");
    }
}
