using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.DTO.Entities.Films;

namespace PruebaTecnica.Interface
{
    public interface IFilmsRepository
    {
        Task<ActionResult<bool>> InsertFilms(Films filmes);
        
    }




}
