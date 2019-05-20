using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fullstack_challenge.Services.Interfaces;

namespace fullstack_challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPeople([FromServices] IPeopleService service, [FromQuery] GetPeopleBindingModel query)
        {
            var people = await service.GetPeople(query.Page);
            return Ok(people);
        }
    }
}
