using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using RestSharp;

namespace PruebaTecnica.Services
{
    public class ServicesVehicles: ControllerBase
    {
        private readonly RestClient _vehicle;

        public ServicesVehicles() 
        {
            _vehicle = new RestClient("https://swapi.dev/api");


        }

        public async Task<ActionResult<IEnumerable<VehicleDTOResponse>>> GetListVehicles()
        {
            RestRequest request = new RestRequest("/vehicles/");
            var response = await _vehicle.ExecuteGetAsync<VehicleDTOResponse>(request);

            if (!response.IsSuccessful)
                return BadRequest();

            return Ok(response.Data);

        }

    }
}
