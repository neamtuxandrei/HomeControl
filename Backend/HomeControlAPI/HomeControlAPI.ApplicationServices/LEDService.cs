using HomeControlAPI.Abstractions;
using HomeControlAPI.ApplicationServices.Abstractions;
using HomeControlAPI.Domain;
using HomeControlAPI.Domain.Enums;

namespace HomeControlAPI.ApplicationServices
{
    public class LEDService : ILEDService
    {
        private readonly ILEDRepository _ledRepository;

        public LEDService(ILEDRepository ledRepository)
        {
            _ledRepository = ledRepository;
        }

        public async Task<LEDSensor> AddLEDSensor(string location)
        {
            LEDSensor ledSensor = LEDSensor.Create(location);
            _ledRepository.Add(ledSensor);
            await _ledRepository.SaveChangesAsync();

            return ledSensor;
            // _logger.log Inserted with id : ... 
        }

        public async Task<List<LEDSensor>> GetAll()
        {
            return await _ledRepository.GetAll();
        }

        public async Task<LEDSensor> GetLEDSensor(Guid id)
        {
            LEDSensor? ledSensor = await _ledRepository.GetById(id);
            if (ledSensor == null)
                throw new InvalidOperationException();

            return ledSensor;
        }

        public async Task RemoveLEDSensor(Guid id)
        {
            LEDSensor? ledSensor = await _ledRepository.GetById(id);
            if (ledSensor == null)
                throw new InvalidOperationException();

            _ledRepository.Remove(ledSensor);
            await _ledRepository.SaveChangesAsync();

            // _logger.log Remove with id ...
        }

        public async Task<LEDSensor> UpdateLEDSensor(Guid id, Status status, int brightness)
        {
            LEDSensor? ledSensor = await _ledRepository.GetById(id);
            if (ledSensor == null)
                throw new InvalidOperationException();

            ledSensor.Status = status;
            ledSensor.Brightness = brightness;

            _ledRepository.Update(ledSensor);
            await _ledRepository.SaveChangesAsync();

            return ledSensor;

            // _logger.log led updated.
        }
    }
}
