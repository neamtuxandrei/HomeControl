using HomeControlAPI.Domain.Enums;

namespace HomeControlAPI.Domain
{
    public class LEDSensor : BaseEntity
    {
        // test
        public Status Status{ get; set; }
        public int Brightness { get; set; } // from 0 to 100.
        public string Location { get; set; } = string.Empty;

        private LEDSensor() { }

        public static LEDSensor Create(string location)
        {
            return new LEDSensor()
            {
                Status = Status.Off,
                Brightness = 0,
                Location = location
            };
        }
            
    }
}
