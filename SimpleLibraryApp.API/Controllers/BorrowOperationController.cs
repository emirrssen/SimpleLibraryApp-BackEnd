using MediatR;
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

    [HttpGet("details")]
    public async Task<IActionResult> GetBorrowOperationDetailsForBorrowedBooksByUserIdAsync([FromQuery] Service.BorrowOperations.Queries.GetDetailsByUserId.Query query)
        => new ObjectResult(await _mediator.Send(query));
}
