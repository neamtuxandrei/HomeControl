using HomeControlAPI.Abstractions;
using HomeControlAPI.ApplicationServices.Abstractions;
using HomeControlAPI.Domain;
using HomeControlAPI.Domain.Enums;

namespace HomeControlAPI.ApplicationServices
{
    public class TemperatureService : ITemperatureService
    {
        private readonly ITemperatureRepository _temperatureRepository;
        public TemperatureService(ITemperatureRepository temperatureRepository)
        {
            _temperatureRepository = temperatureRepository;
        }
        public async Task AddTemperatureSensor(decimal value, TemperatureUnit unit, string location, DateTime lastUpdateTime)
        {
            TemperatureSensor temperatureSensor = TemperatureSensor.Create(value, unit, location, lastUpdateTime);
            _temperatureRepository.Add(temperatureSensor);
            await _temperatureRepository.SaveChangesAsync();

            // _logger.log Inserted with id : ... 

        }

        public IEnumerable<TemperatureSensor> GetAll()
        {
            return _temperatureRepository.GetAll();
        }

        public TemperatureSensor GetTemperatureSensor(Guid id)
        {
            TemperatureSensor? temperatureSensor = _temperatureRepository.GetById(id);
            if (temperatureSensor == null)
                throw new ArgumentException("This device wasn't found.");

            return temperatureSensor;
        }

        

        public async Task RemoveTemperatureSensor(Guid id)
        {
            TemperatureSensor? temperatureSensor = _temperatureRepository.GetById(id);
            if(temperatureSensor == null)
                throw new ArgumentException("This device wasn't found.");

            _temperatureRepository.Remove(temperatureSensor);
            await _temperatureRepository.SaveChangesAsync();

            // _logger.log Remove with id ...
        }

        public async Task UpdateTemperatureSensor(Guid id, decimal value, TemperatureUnit unit, string location)
        {
            TemperatureSensor? temperatureSensor = _temperatureRepository.GetById(id);
            if (temperatureSensor == null)
                throw new ArgumentException("This device wasn't found.");

            temperatureSensor.Temperature = value;
            temperatureSensor.Unit = unit;
            temperatureSensor.Location = location;
            temperatureSensor.LastUpdateTime = DateTime.UtcNow;

            _temperatureRepository.Update(temperatureSensor);
            await _temperatureRepository.SaveChangesAsync();

            // _logger.log Temperature updated.
        }
    }
}
