
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.DTO.Entities.Planets;
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

        [HttpGet]
        [Route("UnPlanets")]
        public async Task<ActionResult<Planets>> FindPlanets(string url)
        { 
                return await _ClientPlanets.FindPlanets(url);
        }


  

    }
}
