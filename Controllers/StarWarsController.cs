using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PruebaTecnica.DataAcces;
using PruebaTecnica.DTO;
using PruebaTecnica.DTO.Entities.Films;
using PruebaTecnica.Interface;
using PruebaTecnica.Repository;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StarWarsController : ControllerBase
    {

        private readonly FilmsController _clientFilmsContoller;
        private readonly PlanetsController _clientPlanetsContoller;
        private readonly IFilmsRepository _IFilmsRepository;





        public StarWarsController(FilmsController clientFilmsContoller
                                 ,PlanetsController clientPlanetsContoller
                                 ,IFilmsRepository IFilmsRepository)
        {
            _clientFilmsContoller = clientFilmsContoller;
            _clientPlanetsContoller = clientPlanetsContoller;
            _IFilmsRepository = IFilmsRepository;
        }

        [HttpGet]
        [Route("StarWars")]
        public async Task<ActionResult<IEnumerable<FilmsDTOResponse>>> InsertFimlsController()
        {

            var films = await _clientFilmsContoller.GetListFilms();
            IEnumerable<Films> lista = ((films.Result as OkObjectResult).Value as FilmsDTOResponse).results;
            Films a = lista.First();
            var val = await _IFilmsRepository.InsertFilms(a);
            return Ok(val);
        }







    }
}
