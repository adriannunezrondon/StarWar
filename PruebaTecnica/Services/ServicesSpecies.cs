using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using RestSharp;

namespace PruebaTecnica.Services
{
    public class ServicesSpecies: ControllerBase
    {
        private readonly RestClient _species;
        public ServicesSpecies() 
        {
            _species = new RestClient("https://swapi.dev/api");
        }


        public async Task<ActionResult<IEnumerable<SpeciesDTOResponse>>> GetListSpecies()
        {
            RestRequest request = new RestRequest("/species/");
            var response = await _species.ExecuteGetAsync<SpeciesDTOResponse>(request);

            if (!response.IsSuccessful)
                return BadRequest();

            return Ok(response.Data);

        }

    }
}
