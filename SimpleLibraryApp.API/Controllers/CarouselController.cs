using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleLibraryApp.API;

[Route("api/[controller]")]
[ApiController]
public class CarouselItemController
{
    private readonly IMediator _mediator;

    public CarouselItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithDetailsAsync([FromQuery] Service.Carousel.Queries.GetAllWithDetails.Query query)
        => new ObjectResult(await _mediator.Send(query));
}
