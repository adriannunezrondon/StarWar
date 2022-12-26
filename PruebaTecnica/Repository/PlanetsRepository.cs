using Dapper;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using PruebaTecnica.DataAcces;
using PruebaTecnica.DTO;
using PruebaTecnica.DTO.Entities.Planets;
using PruebaTecnica.Services;
using RestSharp;
using System.Data;

namespace PruebaTecnica.Repository
{
    public class PlanetsRepository
    {
       // private readonly RestClient _planets;

        //public PlanetsRepository()
        //{
        //   // _planets= new RestClient("https://swapi.dev/api");
            
        //}

        public async Task<ActionResult<bool>> InsertPlanet(Planets planet)
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
                            queryParamts.Add("@name", planet.name);
                            queryParamts.Add("@rotation_period", planet.rotation_period);
                            queryParamts.Add("@orbital_period", planet.orbital_period);
                            queryParamts.Add("@diameter", planet.diameter);
                            queryParamts.Add("@climate", planet.climate);
                            queryParamts.Add("@gravity", planet.gravity);
                            queryParamts.Add("@terrain", planet.terrain);
                            queryParamts.Add("@surface_water", planet.surface_water);
                            queryParamts.Add("@population", planet.population);
                            queryParamts.Add("@residents", planet.residents);
                            queryParamts.Add("@films", " "/*planet.films*/);
                            queryParamts.Add("@created", planet.created);
                            queryParamts.Add("@edited", planet.edited);
                            queryParamts.Add("@url", planet.url);


                            await conn.QueryAsync("pruebatecnica.InsertarPlaneta", queryParamts, commandType: CommandType.StoredProcedure, commandTimeout: 120);

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



        //public IEnumerable<Planets> FinDPlanet(string url)
        //{
        //    //_planets = new RestClient(url);
        //    RestRequest request = new RestRequest(url);
        //    var response =  _planets.ExecuteGetAsync<Planets>(request);

        //    return (IEnumerable<Planets>)response;

        //}

    }
}
