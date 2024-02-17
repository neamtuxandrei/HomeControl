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
        public async Task<TemperatureSensor> AddTemperatureSensor(decimal value, TemperatureUnit unit, string location)
        {
            TemperatureSensor temperatureSensor = TemperatureSensor.Create(value, unit, location);
            _temperatureRepository.Add(temperatureSensor);
            await _temperatureRepository.SaveChangesAsync();

            return temperatureSensor;
            // _logger.log Inserted with id : ... 
        }

        public async Task<List<TemperatureSensor>> GetAll()
        {
            return await _temperatureRepository.GetAll();
        }

        public async Task<TemperatureSensor> GetTemperatureSensor(Guid id)
        {
            TemperatureSensor? temperatureSensor = await _temperatureRepository.GetById(id);
            if (temperatureSensor == null)
                throw new InvalidOperationException();

            return temperatureSensor;
        }

        public async Task RemoveTemperatureSensor(Guid id)
        {
            TemperatureSensor? temperatureSensor = await _temperatureRepository.GetById(id);
            if(temperatureSensor == null)
                throw new InvalidOperationException();

            _temperatureRepository.Remove(temperatureSensor);
            await _temperatureRepository.SaveChangesAsync();

            // _logger.log Remove with id ...
        }

        public async Task<TemperatureSensor> UpdateTemperatureSensor(Guid id, decimal value, TemperatureUnit unit, string location)
        {
            TemperatureSensor? temperatureSensor = await _temperatureRepository.GetById(id);
            if (temperatureSensor == null)
                throw new InvalidOperationException();

            temperatureSensor.Temperature = value;
            temperatureSensor.Unit = unit;
            temperatureSensor.Location = location;
            temperatureSensor.LastUpdateTime = DateTime.UtcNow;

            _temperatureRepository.Update(temperatureSensor);
            await _temperatureRepository.SaveChangesAsync();

            return temperatureSensor;

            // _logger.log Temperature updated.
        }
    }
}
