using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleLibraryApp.API;

[Route("api/[controller]")]
[ApiController]
public class BookController
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetDetailsByBookName([FromQuery] Service.Book.Queries.GetDetailsByName.Query query)
        => new ObjectResult(await _mediator.Send(query));
}
