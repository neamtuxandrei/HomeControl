using HomeControlAPI.Domain;
using HomeControlAPI.Domain.Enums;

namespace HomeControlAPI.ApplicationServices.Abstractions
{
    public interface ITemperatureService 
    {
        Task<List<TemperatureSensor>> GetAll();
        Task<TemperatureSensor> GetTemperatureSensor(Guid id);
        Task<TemperatureSensor> AddTemperatureSensor(decimal value, TemperatureUnit unit, string location);
        Task RemoveTemperatureSensor(Guid id);
        Task<TemperatureSensor> UpdateTemperatureSensor(Guid id, decimal value, TemperatureUnit unit, string location);
    }
}
