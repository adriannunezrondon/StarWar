using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PruebaTecnica.DataAcces;
using PruebaTecnica.DTO;
using PruebaTecnica.DTO.Entities.Films;
using PruebaTecnica.DTO.Entities.Planets;
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
        private readonly IPlanetsRepository _IPlanetsRepository;





        public StarWarsController(FilmsController clientFilmsContoller
                                 ,PlanetsController clientPlanetsContoller
                                 ,IFilmsRepository IFilmsRepository
                               //  ,IPlanetsRepository IPlanetsRepository
                                 )
        {
            _clientFilmsContoller = clientFilmsContoller;
            _clientPlanetsContoller = clientPlanetsContoller;
            _IFilmsRepository = IFilmsRepository;
           // _IPlanetsRepository = IPlanetsRepository;
        }

        [HttpGet]
        [Route("StarWars")]
        public async Task<ActionResult<IEnumerable<FilmsDTOResponse>>> InsertFimlsController()
        {

            var films = await _clientFilmsContoller.GetListFilms();
            var planet = await _clientPlanetsContoller.GetListPlanets();

            IEnumerable<Films> lista = ((films.Result as OkObjectResult).Value as FilmsDTOResponse).results;
            Films a = lista.First();

            List<string> listPlanetas = _IFilmsRepository.ListaPlanets(a);

            //foreach (string url in listPlanetas)
            //{
            //    var planet = _IPlanetsRepository.FinDPlanet(url);
            //}

            var val = await _IFilmsRepository.InsertFilms(a);

            return Ok(val);
        }







    }
}
