using HomeControlAPI.Domain;
using HomeControlAPI.Domain.Enums;

namespace HomeControlAPI.ApplicationServices.Abstractions
{
    public interface ITemperatureService 
    {
        Task<List<TemperatureSensor>> GetAll();
        Task<TemperatureSensor> GetTemperatureSensor(Guid id);
        Task AddTemperatureSensor(decimal value, TemperatureUnit unit, string location);
        Task RemoveTemperatureSensor(Guid id);
        Task UpdateTemperatureSensor(Guid id, decimal value, TemperatureUnit unit, string location);
    }
}
