using HomeControlAPI.Domain.Enums;

namespace HomeControlAPI.Domain
{
    public class LEDSensor : BaseEntity
    {
        public Status Status{ get; set; }
        public int Brightness { get; set; } // from 0 to 100.
        public string Location { get; set; } = string.Empty;

        private LEDSensor() { }

        public static LEDSensor Create()
        {
            return new LEDSensor();
        }
            
    }
}
