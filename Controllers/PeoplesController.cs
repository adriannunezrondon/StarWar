

using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Logger;
using PruebaTecnica.Services;



//namespace PruebaTecnica.Controllers
namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeoplesController : ControllerBase
    {

        private readonly ServicesPeoples _clientPeoples;
        //private readonly LoggerManager _logger;

        public PeoplesController(ServicesPeoples clientPeoples)
        {
            _clientPeoples = clientPeoples;
          //  _logger = logger;
            

        }


        [HttpGet]
        [Route("ListPeople")]
        public async Task<ActionResult<IEnumerable<PeopleDTOResponse>>> GetListPeoples()
        {
            
            return await _clientPeoples.GetListPeoples();
            

        }


    }
}
