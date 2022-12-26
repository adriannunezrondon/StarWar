using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {

        public readonly ServicesPlanets _ClientPlanets;

        public PlanetsController(ServicesPlanets clientPlanet) 
        { 

            _ClientPlanets= clientPlanet;
        }

        [HttpGet]
        [Route("ListPlanets")]
        public async Task<ActionResult<IEnumerable<PlanetsDTOResponse>>> GetListPlanets()
        {
            return await _ClientPlanets.GetListPlanets();
        }

   

    }
}
