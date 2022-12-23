
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipController : ControllerBase
    {

        private readonly ServicesStarship _clientStarship;

        public StarshipController(ServicesStarship starship)
        {
            _clientStarship = starship;
        }

        [HttpGet]
        [Route("ListStarship")]
        public async Task<ActionResult<IEnumerable<StarshipDTOResponse>>>GetListStarship()
        {
            return await _clientStarship.GetListStarship();
        }

    }
}
