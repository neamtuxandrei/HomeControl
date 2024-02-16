using HomeControlAPI.Domain;

namespace HomeControlAPI.DataAccess
{
    public class HomeControlSeedData
    {
        public static async Task SeedDataAsync(HomeControlDbContext context)
        {
            var temperatureSensorList = new List<TemperatureSensor>()
            {
                TemperatureSensor.Create(21.3M,Domain.Enums.TemperatureUnit.Celsius,"Sufragerie"),
                TemperatureSensor.Create(13.93M,Domain.Enums.TemperatureUnit.Celsius,"Baie"),
            };
            var ledSensorList = new List<LEDSensor>()
            {
                LEDSensor.Create("Sufragerie"),
                LEDSensor.Create("Sufragerie"),
                LEDSensor.Create("Dormitor"),
                LEDSensor.Create("Baie")
            };

            context.TemperatureSensors.AddRange(temperatureSensorList);
            context.LEDSensors.AddRange(ledSensorList);

            await context.SaveChangesAsync();
        }
    }
}
