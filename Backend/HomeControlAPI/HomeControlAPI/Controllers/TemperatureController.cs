using HomeControlAPI.ApplicationServices.Abstractions;
using HomeControlAPI.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<ValuesController>
        [HttpGet]
        public List<TemperatureSensor> GetAllTemperatureSensors()
        {
            return _temperatureService.GetAll().ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetTemperatureSensor([FromQuery]Guid id)
        {
            try
            {
                var temperatureSensor = _temperatureService.GetTemperatureSensor(id);

                return Ok(temperatureSensor);
            }
            catch (InvalidOperationException)
            {
                // return NotFound(new ErrorResult() { Description = "Could not find the information associated with the curent user" });
                 return NotFound("Could not find any temperature sensor with this id.");
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
