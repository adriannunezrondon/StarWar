﻿using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using RestSharp;

namespace PruebaTecnica.Services
{
    public class ServicesPlanets: ControllerBase
    {
        private readonly RestClient _planets;

        public ServicesPlanets()
        {
            _planets = new RestClient("https://swapi.dev/api");
        }

        public async Task<ActionResult<IEnumerable<PlanetsDTOResponse>>> GetListPlanets()
        {
            RestRequest request = new RestRequest("/planets/");
            var response = await _planets.ExecuteGetAsync<PlanetsDTOResponse>(request);

            if (!response.IsSuccessful)
                return BadRequest();

            return Ok(response.Data);

        }

    }
}
