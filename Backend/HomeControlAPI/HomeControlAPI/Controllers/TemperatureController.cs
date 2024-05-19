using HomeControlAPI.ApplicationServices.Abstractions;
using HomeControlAPI.DataObjects;
using HomeControlAPI.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeControlAPI.Controllers
{
    [Route("devices/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperatureService _temperatureService;
        public TemperatureController(ITemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TemperatureSensor>))]
        [SwaggerOperation(Summary = "Returns all temperature sensors.")]
        public async Task<IActionResult> GetAllTemperatureSensors()
        {
            try
            {
                var temperatureSensors = await _temperatureService.GetAll();
                return Ok(temperatureSensors);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemperatureSensor))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFound))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [SwaggerOperation(Summary = "Returns temperature sensor by id.")]
        public async Task<IActionResult> GetTemperatureSensor([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Device id can't be empty.");
            try
            {
                var temperatureSensor = await _temperatureService.GetTemperatureSensor(id);

                return Ok(temperatureSensor);
            }
            catch (InvalidOperationException)
            {
                return NotFound("Device not found.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ok))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFound))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [SwaggerOperation(Summary = "Removes temperature sensor by id.")]
        public async Task<IActionResult> RemoveTemperatureSensor([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Device id can't be empty.");
            try
            {
                await _temperatureService.RemoveTemperatureSensor(id);
                return Ok("Device removed successfully.");
            }
            catch (InvalidOperationException)
            {
                return NotFound("Device not found.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ok))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFound))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [SwaggerOperation(Summary = "Updates temperature sensor.")]
        public async Task<IActionResult> UpdateTemperatureSensor([FromRoute] Guid id, [FromBody] UpdateTemperatureDTO value)
        {
            if (id == Guid.Empty)
                return BadRequest("Device id can't be empty");
            try
            {
                var temperatureSensor = await _temperatureService.UpdateTemperatureSensor(id, value.Temperature, (Domain.Enums.TemperatureUnit)value.Unit);
                return Ok(temperatureSensor);
            }
            catch (InvalidOperationException)
            {
                return NotFound("Device not found.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Created))]
        [SwaggerOperation(Summary = "Creates a new temperature sensor.")]
        public async Task<IActionResult> AddTemperatureSensor([FromBody] AddTemperatureDTO value)
        {
            try
            {
                var temperatureSensor = await _temperatureService.AddTemperatureSensor(value.Temperature, (Domain.Enums.TemperatureUnit)value.Unit, value.Location);
                return Created("Created", temperatureSensor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
