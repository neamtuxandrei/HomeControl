using HomeControlAPI.ApplicationServices.Abstractions;
using HomeControlAPI.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeControlAPI.Controllers
{
    [Route("api/[controller]")]
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
        [SwaggerOperation(Summary = "Returns all of the temperature sensors.")]
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
        [SwaggerOperation(Summary = "Returns temperature sensor by id")]
        public async Task<IActionResult> GetTemperatureSensor([FromRoute]Guid id)
        {
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

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
