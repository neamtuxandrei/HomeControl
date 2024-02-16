using HomeControlAPI.Domain.Enums;
using HomeControlAPI.Domain;

namespace HomeControlAPI.ApplicationServices.Abstractions
{
    public interface ILEDService
    {
            LEDSensor GetLEDSensor(Guid id);
            Task AddLEDSensor(Status status, int brightness, string location);
            Task RemoveLEDSensor(Guid id);
            Task UpdateLEDSensor(Guid id, Status status, int brightness, string location);
    }
}
