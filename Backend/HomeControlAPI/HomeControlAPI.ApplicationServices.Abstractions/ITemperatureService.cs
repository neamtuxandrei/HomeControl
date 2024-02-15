using HomeControlAPI.Domain;
using HomeControlAPI.Domain.Enums;

namespace HomeControlAPI.ApplicationServices.Abstractions
{
    public interface ITemperatureService 
    {
        IEnumerable<TemperatureSensor> GetAll();
        TemperatureSensor GetTemperatureSensor(Guid id);
        Task AddTemperatureSensor(decimal value, TemperatureUnit unit, string location, DateTime lastUpdateTime);
        Task RemoveTemperatureSensor(Guid id);
        Task UpdateTemperatureSensor(Guid id, decimal value, TemperatureUnit unit, string location);
    }
}
