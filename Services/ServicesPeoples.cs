using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using RestSharp;

namespace PruebaTecnica.Services
{
    public class ServicesPeoples: ControllerBase
    {
        private readonly RestClient _client;
        //private readonly ILoggerManager _logger;

        public ServicesPeoples()
        {
            _client = new RestClient("https://swapi.dev/api");
            //_logger = new ILoggerManager();
        }


        public async Task<ActionResult<IEnumerable<PeopleDTOResponse>>> GetListPeoples()
        {
           // _logger.LogInformation("Iniciando Carga de Personas");
            RestRequest request = new RestRequest("/people/");
            var response = await _client.ExecuteGetAsync<PeopleDTOResponse>(request);
            if (!response.IsSuccessful)
                return BadRequest();

           // _logger.LogInformation("Finalizada la Carga de Personas");
            return Ok(response.Data);
        }

    }
}
