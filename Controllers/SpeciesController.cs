using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        public readonly ServicesSpecies _ClienteSpecies;

        public SpeciesController(ServicesSpecies clienteSpecies) 
        {
            _ClienteSpecies = clienteSpecies;

        }

        [HttpGet]
        [Route("ListSpecies")]
        public async Task<ActionResult<IEnumerable<SpeciesDTOResponse>>> GetListSpecies()
        {
            return await _ClienteSpecies.GetListSpecies();
        }

    }
}
