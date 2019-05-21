using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using API.Controllers.Models;

namespace API.Controllers
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
