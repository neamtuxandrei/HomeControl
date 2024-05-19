using HomeControlAPI.Abstractions;
using HomeControlAPI.ApplicationServices;
using HomeControlAPI.ApplicationServices.Abstractions;
using HomeControlAPI.DataAccess.Repositories;

namespace HomeControlAPI.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            //repos
            services.AddScoped<ITemperatureRepository, TemperatureRepository>();
            services.AddScoped<ILEDRepository, LEDRepository>();
            
            //services
            services.AddScoped<ITemperatureService, TemperatureService>();
            services.AddScoped<ILEDService, LEDService>();
        }
    }
}
