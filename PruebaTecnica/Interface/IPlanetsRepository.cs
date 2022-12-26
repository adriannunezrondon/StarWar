using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO.Entities.Planets;
using PruebaTecnica.Services;

namespace PruebaTecnica.Interface
{
    public interface IPlanetsRepository
    {

        Task<ActionResult<bool>> InsertPlanet(ServicesPlanets planeta);
        Task<ActionResult<Planets>> FinDPlanet(string url);


    }
}
