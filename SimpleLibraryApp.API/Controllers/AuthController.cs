using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;

namespace SimpleLibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {   
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetByEmailAsync(string email) 
            => new ObjectResult(await _repo.GetUserByEmailAsync(email));
    }
}