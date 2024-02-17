using System.ComponentModel.DataAnnotations;

namespace HomeControlAPI.DataObjects
{
    public class UpdateTemperatureDTO
    {
        public decimal Temperature { get; set; }
        [EnumDataType(typeof(TemperatureUnitDTO), ErrorMessage = "Invalid unit. Valid values are Celsius, Fahrenheit, and Kelvin. (0,1 and 3)")]
        public TemperatureUnitDTO Unit { get; set; }
    }

    public enum TemperatureUnitDTO
    {
        Celsius,
        Fahrenheit,
        Kelvin
    }
}
