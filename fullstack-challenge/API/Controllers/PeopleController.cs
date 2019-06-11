using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPeople([FromServices] IPeopleService service, [FromQuery] PeopleBindingModel query)
        {
            var people = await service.GetPeople(query.Page);
            return Ok(people);
        }
    }
}
