using HomeControlAPI.ApplicationServices.Abstractions;
using HomeControlAPI.DataObjects;
using HomeControlAPI.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LEDController : ControllerBase
    {
        private readonly ILEDService _ledService;

        public LEDController(ILEDService ledService)
        {
            _ledService = ledService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LEDSensor>))]
        [SwaggerOperation(Summary = "Returns all LEDs.")]
        public async Task<IActionResult> GetAllLEDs()
        {
            try
            {
                var leds = await _ledService.GetAll();
                return Ok(leds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LEDSensor))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFound))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [SwaggerOperation(Summary = "Returns LED by id.")]
        public async Task<IActionResult> GetLED([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Device id can't be empty.");
            try
            {
                var led = await _ledService.GetLEDSensor(id);

                return Ok(led);
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
        [SwaggerOperation(Summary = "Removes LED by id.")]
        public async Task<IActionResult> RemoveLED([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Device id can't be empty.");
            try
            {
                await _ledService.RemoveLEDSensor(id);
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
        [SwaggerOperation(Summary = "Updates LED's state.")]
        public async Task<IActionResult> UpdateLED([FromRoute] Guid id, [FromBody] UpdateLEDDTO value)
        {
            if (id == Guid.Empty)
                return BadRequest("Device id can't be empty.");
            try
            {
                var led = await _ledService.UpdateLEDSensor(id, (Domain.Enums.Status)value.Status, value.Brightness);
                return Ok(led);
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
        [SwaggerOperation(Summary = "Creates a new LED.")]
        public async Task<IActionResult> AddLED([FromBody] AddLEDDTO value)
        {
            try
            {
                var led = await _ledService.AddLEDSensor(value.Location);
                return Created("Created", led);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
