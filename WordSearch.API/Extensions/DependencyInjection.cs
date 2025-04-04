using WordSearch.Core.Logic;
using WordSearch.Core.Logic.Grid;
using WordSearch.Core.Logic.Locations;
using WordSearch.Core.Interfaces;

namespace WordSearch.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWordSearchServices(this IServiceCollection services)
        {
            services.AddScoped<ICreatePuzzle, CreatePuzzle>();
            services.AddScoped<CreateEmptyGrid>();
            services.AddScoped<FillEmptyGrid>();
            services.AddScoped<SetLocations>();
            services.AddScoped<AssignStartPoint>();
            services.AddScoped<AssignWordCoordinates>();
            services.AddScoped<CheckBoundary>();
            services.AddScoped<TryWordPlacement>();
            services.AddScoped<Random>();

            return services;
        }
    }
}
