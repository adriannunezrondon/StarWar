
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.DTO.Entities.Films;
using PruebaTecnica.DTO.Entities.Planets;
using PruebaTecnica.Interface;


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
        public StarWarsController(FilmsController clientFilmsContoller,PlanetsController clientPlanetsContoller,IFilmsRepository IFilmsRepository,IPlanetsRepository IPlanetsRepository)
        {
            _clientFilmsContoller = clientFilmsContoller;
            _clientPlanetsContoller = clientPlanetsContoller;
            _IFilmsRepository = IFilmsRepository;
            _IPlanetsRepository = IPlanetsRepository;
        }

        [HttpGet]
        [Route("InsertFilms")]
        public async Task<ActionResult<IEnumerable<FilmsDTOResponse>>> InsertFimlsController()
        {

            var films = await _clientFilmsContoller.GetListFilms();
  

            List<Films> lista = ((films.Result as OkObjectResult).Value as FilmsDTOResponse).results.ToList();

            string[] subcadena;
            string IdPlaneta;
            

            foreach (Films film in lista)
            {
                List<string> listPlanetas = _IFilmsRepository.ListaPlanets(film);

                var idFilmeInsertado = await _IFilmsRepository.InsertFilms(film);

                foreach (string x in listPlanetas)
                {
                    subcadena = x.Split('/');
                    IdPlaneta = subcadena[5];
                    var planeta = await _clientPlanetsContoller.FindPlanets(x[21..]);
                    Planets plan = ((planeta.Result as OkObjectResult).Value as Planets);
                    var idPlanetaInsertado = await _IPlanetsRepository.InsertPlanet(plan, IdPlaneta);
                    var idFilms_Planets = await _IPlanetsRepository.InsertPlanetINFilms_Planet(idPlanetaInsertado, idFilmeInsertado);
                }
            }

            return Ok(films.Result);
        }

        [HttpDelete]
        [Route("DeleteFilms")]
        public async Task<ActionResult<int>> DeleteFimlsController(int id)
        {

            return await _IFilmsRepository.DeleteFimls(id);

        }




    }
}
