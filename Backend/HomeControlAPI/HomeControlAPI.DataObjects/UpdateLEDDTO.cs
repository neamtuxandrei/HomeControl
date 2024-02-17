using System.ComponentModel.DataAnnotations;

namespace HomeControlAPI.DataObjects
{
    public class UpdateLEDDTO
    {
        [EnumDataType(typeof(StatusDTO), ErrorMessage = "Invalid unit. Valid values are Off and On. (0 and 1)")]
        public StatusDTO Status { get; set; }
        [Range(0, 100, ErrorMessage = "Brightness must be between 0 and 100.")]
        public int Brightness { get; set; }
    }

    public enum StatusDTO
    {
        Off,
        On
    }
}
