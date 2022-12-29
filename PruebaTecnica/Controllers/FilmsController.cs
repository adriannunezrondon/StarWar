
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {

        private readonly ServicesFilms _clientFilms;



        public FilmsController(ServicesFilms clientFilms)
        {
            _clientFilms = clientFilms;

        }

        [HttpGet]
        [Route("ListFilms")]
        public async Task<ActionResult<IEnumerable<FilmsDTOResponse>>> GetListFilms()
        {
            return await _clientFilms.GetListFilms();
        }





       








    }
}
