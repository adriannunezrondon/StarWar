using Dapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DataAcces;
using PruebaTecnica.DTO.Entities.Films;
using PruebaTecnica.Interface;
using System.Data;

namespace PruebaTecnica.Repository
{
    public class FilmsRepository : IFilmsRepository
    {

        public async Task<ActionResult<bool>> InsertFilms(Films filme)
        {
            using (var conn = DAO.MySqlConnection())
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    {
                        try
                        {

                            var queryParamts = new DynamicParameters();
                            queryParamts.Add("@title", filme.title);
                            queryParamts.Add("@opening_crawl",filme.episode_id);
                            queryParamts.Add("@episode_id",filme.opening_crawl);
                            queryParamts.Add("@director",filme.director);
                            queryParamts.Add("@producer",filme.producer);
                            queryParamts.Add("@release_date"," "/*filme.release_date*/);
                            queryParamts.Add("@characters"," "/*filme.characters*/);
                            queryParamts.Add("@planets", " "/*filme.planets*/);
                            queryParamts.Add("@starships", " "/*filme.starships*/);
                            queryParamts.Add("@vehicles", " "/*filme.vehicles*/);
                            queryParamts.Add("@species", " "/*filme.species*/);
                            queryParamts.Add("@created", filme.created);
                            queryParamts.Add("@edited", filme.edited);
                            queryParamts.Add("@url",filme.url);

 
                           await conn.QueryAsync("pruebatecnica.InsertarFilms", queryParamts, commandType: CommandType.StoredProcedure, commandTimeout: 120);

                            tran.Commit();
                            return true;

                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            return false;
                        }
                        finally
                        {
                            conn.Close();

                        }

                    }

                }


            }


        }


        public List<string> ListaPlanets(Films filmes)
        {
            List<string> listaPlanetas = filmes.planets.ToList();

            return listaPlanetas;

        
        }

        


    }
}
