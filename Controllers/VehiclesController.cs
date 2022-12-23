using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        public readonly ServicesVehicles _ClienteVehicles;

        public VehiclesController(ServicesVehicles clienteVehicles) 
        {
            _ClienteVehicles = clienteVehicles;


        }

        [HttpGet]
        [Route("ListVehicles")]
        public async Task<ActionResult<IEnumerable<VehicleDTOResponse>>> GetListVehicles()
        {
            return await _ClienteVehicles.GetListVehicles();
        }

    }
}
