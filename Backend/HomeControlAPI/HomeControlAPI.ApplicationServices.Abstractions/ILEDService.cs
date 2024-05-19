using HomeControlAPI.Domain.Enums;
using HomeControlAPI.Domain;

namespace HomeControlAPI.ApplicationServices.Abstractions
{
    public interface ILEDService
    {
        Task<List<LEDSensor>> GetAll();
        Task<LEDSensor> GetLEDSensor(Guid id);
        Task<LEDSensor> AddLEDSensor(string location);
        Task RemoveLEDSensor(Guid id);
        Task<LEDSensor> UpdateLEDSensor(Guid id, Status status, int brightness);
    }
}
