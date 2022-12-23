using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using RestSharp;

namespace PruebaTecnica.Services{
    
    public class ServicesStarship : ControllerBase
    {
        private readonly RestClient _starship;

        public ServicesStarship()
        {
            _starship = new RestClient("https://swapi.dev/api");
        }

        public async Task<ActionResult<IEnumerable<StarshipDTOResponse>>> GetListStarship()
        {
            RestRequest request = new RestRequest("/starships/");
            var response = await _starship.ExecuteGetAsync<StarshipDTOResponse>(request);

            if (!response.IsSuccessful)
                return BadRequest();

            return Ok(response.Data);

        }

    }
}
