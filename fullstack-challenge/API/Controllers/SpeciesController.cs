using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Core.Interfaces;
using Core.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SpeciesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSpecies([FromServices] ISpeciesService service, [FromQuery] SpeciesBindingModel model)
        {
            var species = new PaginatedSpecies();
            if(!string.IsNullOrEmpty(model.search))
                species = await service.GetSpeciesByName(model.search, model.page);
            
            else
                species = await service.GetAllSpecies(model.page);

            return Ok(species);
        }
    }
}