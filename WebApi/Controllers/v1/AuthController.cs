using Application.Features.AuthFeatures.Queries.UserLoginQuery;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1;

[ApiVersion("1.0")]
public class AuthController : BaseApiController
{
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await Mediator.Send(request);
        if(result.Success)
        {
            return Ok(result.Token);
        }

        return NotFound("User not found!");
    }
}
