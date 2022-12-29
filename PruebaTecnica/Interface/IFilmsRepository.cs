using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO.Entities.Films;

namespace PruebaTecnica.Interface
{
    public interface IFilmsRepository
    {
        Task<ActionResult<int>> InsertFilms(Films filmes);
        List<string> ListaPlanets(Films filmes);
        Task<ActionResult<int>> DeleteFimls(int idFilme);


    }




}
