using System.ComponentModel.DataAnnotations;

namespace HomeControlAPI.DataObjects
{
    public class AddTemperatureDTO
    {
        public decimal Temperature { get; set; }
        [EnumDataType(typeof(TemperatureUnitDTO), ErrorMessage = "Invalid unit. Valid values are Celsius, Fahrenheit, and Kelvin. (0,1 and 3)")]
        public TemperatureUnitDTO Unit { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
