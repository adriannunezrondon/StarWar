using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO.Entities.Planets;
using PruebaTecnica.Services;

namespace PruebaTecnica.Interface
{
    public interface IPlanetsRepository
    {

        Task<ActionResult<int>> InsertPlanet(Planets planet, string id);
        Task<ActionResult<int>> InsertPlanetINFilms_Planet(ActionResult<int> idPlaneta, ActionResult<int> idFilmes);


    }
}
