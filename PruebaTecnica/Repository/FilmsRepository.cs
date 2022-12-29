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
        int id;
        public async Task<ActionResult<int>> InsertFilms(Films filme)
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
                            queryParamts.Add("@episode_id", filme.episode_id);
                            queryParamts.Add("@opening_crawl", filme.opening_crawl);
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

                             id = await conn.ExecuteScalarAsync<int>("adrian_starwars.InsertarFilms", queryParamts, commandType: CommandType.StoredProcedure, commandTimeout: 120);
                           
                            tran.Commit();
                            return id;

                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            return 0;
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
        public async Task<ActionResult<int>> DeleteFimls(int idFilm)
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
                            queryParamts.Add("@idFilms", idFilm);

                            id = await conn.ExecuteScalarAsync<int>("adrian_starwars.DeleteFilms", queryParamts, commandType: CommandType.StoredProcedure, commandTimeout: 120);

                            tran.Commit();
                            return id;

                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            return 0;
                        }
                        finally
                        {
                            conn.Close();

                        }

                    }

                }


            }

        }

    }
}
