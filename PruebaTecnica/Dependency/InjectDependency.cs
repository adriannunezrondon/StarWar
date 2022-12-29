using PruebaTecnica.Controllers;
using PruebaTecnica.Interface;
using PruebaTecnica.Repository;
using PruebaTecnica.Services;

namespace PruebaTecnica.Inject
{
    public static class InjectDependency
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<PeoplesController>();
            services.AddScoped<ServicesPeoples>();

            services.AddScoped<StarshipController>();
            services.AddScoped<ServicesStarship>();

            services.AddScoped<FilmsController>();
            services.AddScoped<ServicesFilms>();

            services.AddScoped<PlanetsController>();
            services.AddScoped<ServicesPlanets>();

            services.AddScoped<SpeciesController>();
            services.AddScoped<ServicesSpecies>();

            services.AddScoped<VehiclesController>();
            services.AddScoped<ServicesVehicles>();

            services.AddScoped<StarWarsController>();

            services.AddTransient<IFilmsRepository,FilmsRepository>();
            services.AddTransient<IPlanetsRepository, PlanetsRepository>();


            return services;
        }

    }
}
