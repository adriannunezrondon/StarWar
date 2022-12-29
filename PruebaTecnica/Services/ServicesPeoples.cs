using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using RestSharp;

namespace PruebaTecnica.Services
{
    public class ServicesPeoples: ControllerBase
    {
        private readonly RestClient _client;


        public ServicesPeoples()
        {
            _client = new RestClient("https://swapi.dev/api");

        }


        public async Task<ActionResult<IEnumerable<PeopleDTOResponse>>> GetListPeoples()
        {

            RestRequest request = new RestRequest("/people/");
            var response = await _client.ExecuteGetAsync<PeopleDTOResponse>(request);
            if (!response.IsSuccessful)
                return BadRequest();

;
            return Ok(response.Data);
        }

    }
}
