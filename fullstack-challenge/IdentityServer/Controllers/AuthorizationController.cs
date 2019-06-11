using System;
using System.Threading.Tasks;
using IdentityServer.Interfaces;
using IdentityServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetAccessToken([FromServices] IAuthorizationService service, [FromBody] AccessTokenBindingModel model)
        {
            if(string.IsNullOrEmpty(model.ClientId) || string.IsNullOrEmpty(model.ClientSecret) || string.IsNullOrEmpty(model.Scope))
                return BadRequest();

            var tokenResponse = await service.GetAccessToken(model.ClientId, model.ClientSecret, model.Scope);
            return Ok(tokenResponse);
        }
        
    }
}