using HomeControlAPI.Domain.Enums;

namespace HomeControlAPI.Domain
{
    public class TemperatureSensor : BaseEntity
    {
        public decimal Temperature { get; set; }
        public TemperatureUnit Unit { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTime LastUpdateTime { get; set; }

        private TemperatureSensor() { }

        public static TemperatureSensor Create(decimal temperature,TemperatureUnit unit,string location)
        {
            return new TemperatureSensor
            {
                Temperature = temperature,
                Unit = unit,
                Location = location,
                LastUpdateTime = DateTime.UtcNow
            };
        }

        public void ConvertUnitToCelsius()
        {
            // implement
        }
        public void ConvertUnitToFahrenheit()
        {
            // implement
        }
        public void ConvertUnitToKelvin()
        {
            // implement
        }
    }
}
