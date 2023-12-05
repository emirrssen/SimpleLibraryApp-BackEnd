using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SimpleLibraryApp.API;

[Route("api/[controller]")]
[ApiController]
public class BorrowOperationController
{
    private readonly IMediator _mediator;

    public BorrowOperationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-readed-books-by-user-id")]
    public async Task<IActionResult> GetReadedBooksByUserIdAsync([FromQuery] Service.BorrowOperation.Queries.GetReadedBooksByUserId.Query query)
        => new ObjectResult(await _mediator.Send(query));
}
