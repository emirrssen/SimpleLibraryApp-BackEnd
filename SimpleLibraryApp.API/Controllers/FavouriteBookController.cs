using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleLibraryApp.API;

[Route("api/[controller]")]
[ApiController]
public class FavouriteBookController
{
    private readonly IMediator _mediator;

    public FavouriteBookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetDetailsByUserIdAsync([FromQuery] Service.FavouriteBooks.Queries.GetDetailsByUserId.Query query)
        => new ObjectResult(await _mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> InsertFavouriteBookAsync([FromBody] Service.FavouriteBooks.Commands.Insert.Command command)
        => new ObjectResult(await _mediator.Send(command));

    [HttpDelete]
    public async Task<IActionResult> DeleteFavouriteBookByIdAsync([FromQuery] Service.FavouriteBooks.Commands.Delete.Command command)
        => new ObjectResult(await _mediator.Send(command));
}
