using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleLibraryApp.API;

[Route("api/[controller]")]
[ApiController]
public class PersonelInfoController
{
    private readonly IMediator _mediator;

    public PersonelInfoController(IMediator mediator)
    {   
        _mediator = mediator;
    }

    [HttpGet("load-personel-info")]
    public async Task<IActionResult> LoadPersonelInfoAsync([FromQuery] Service.PersonelInfo.Queries.LoadPersonelInfo.Query query)
        => new ObjectResult(await _mediator.Send(query));

    [HttpGet("get-readed-books-by-user-id")]
    public async Task<IActionResult> GetReadedBooksByUserIdAsync([FromQuery] Service.PersonelInfo.Queries.GetReadedBooksByUserId.Query query)
        => new ObjectResult(await _mediator.Send(query));

    [HttpGet("get-favourite-categories-by-user-id")]
    public async Task<IActionResult> GetFavouriteCategoriesByUserIdAsync([FromQuery] Service.PersonelInfo.Queries.GetFavouriteCategoriesByUserId.Query query)
        => new ObjectResult(await _mediator.Send(query));

    [HttpGet("get-details-for-profile")]
    public async Task<IActionResult> GetDetailsForProfileByUserIdAsync([FromQuery] Service.PersonelInfo.Queries.GetProfileDetailsByUserId.Query query)
        => new ObjectResult(await _mediator.Send(query));

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordByUserIdAsync([FromBody] Service.PersonelInfo.Commands.ChangePasswordByUserId.Command command)
        => new ObjectResult(await _mediator.Send(command));
}
