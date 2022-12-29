using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.DTO.Entities.Films;
using RestSharp;

namespace PruebaTecnica.Services
{
    public class ServicesFilms : ControllerBase
    {

        private readonly RestClient _films;

        public ServicesFilms()
        {
            _films = new RestClient("https://swapi.dev/api");
        }

        public async Task<ActionResult<IEnumerable<FilmsDTOResponse>>> GetListFilms()
        {

            RestRequest request = new RestRequest("/films/");
            var response = await _films.ExecuteGetAsync<FilmsDTOResponse>(request);
            if (!response.IsSuccessful)
                return BadRequest();


            return Ok(response.Data);
        }
        






    }
}
