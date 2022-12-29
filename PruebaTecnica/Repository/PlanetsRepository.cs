using Dapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DataAcces;
using PruebaTecnica.DTO.Entities.Planets;
using PruebaTecnica.Interface;
using System.Data;

namespace PruebaTecnica.Repository
{
    public class PlanetsRepository: IPlanetsRepository
    {

        public async Task<ActionResult<int>> InsertPlanet(Planets planet, string idPlaneta)
        {
            using (var conn = DAO.MySqlConnection())
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    {
                        try
                        {
                            int id;
                            var queryParamts = new DynamicParameters();
                            queryParamts.Add("@idP", idPlaneta);
                            queryParamts.Add("@name", planet.name);
                            queryParamts.Add("@rotation_period", planet.rotation_period);
                            queryParamts.Add("@orbital_period", planet.orbital_period);
                            queryParamts.Add("@diameter", planet.diameter);
                            queryParamts.Add("@climate", planet.climate);
                            queryParamts.Add("@gravity", planet.gravity);
                            queryParamts.Add("@terrain",planet.terrain);
                            queryParamts.Add("@surface_water",planet.surface_water);
                            queryParamts.Add("@population", planet.population);
                            queryParamts.Add("@residents", " "/*planet.residents*/);
                            queryParamts.Add("@films", " "/*planet.films*/);
                            queryParamts.Add("@created", planet.created);
                            queryParamts.Add("@edited", planet.edited);
                            queryParamts.Add("@url", planet.url);


                            id = await conn.ExecuteScalarAsync<int>("adrian_starwars.InsertarPlaneta", queryParamts, commandType: CommandType.StoredProcedure, commandTimeout: 120);

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

        public async Task<ActionResult<int>> InsertPlanetINFilms_Planet(ActionResult<int> idPlaneta, ActionResult<int> idFilmes)
        {
            using (var conn = DAO.MySqlConnection())
            {
                conn.Open();
                //Int32.Parse(idFilmes)
                using (var tran = conn.BeginTransaction())
                {
                    {
                        try
                        {
                            int id;
                            var queryParamts = new DynamicParameters();
                            queryParamts.Add("@idFilms", idFilmes.Value);
                            queryParamts.Add("@idPlanets", idPlaneta.Value);

                            id = await conn.ExecuteScalarAsync<int>("adrian_starwars.InsertarFilms_Planets", queryParamts, commandType: CommandType.StoredProcedure, commandTimeout: 120);

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
