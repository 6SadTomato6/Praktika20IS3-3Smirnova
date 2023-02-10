using Microsoft.AspNetCore.Mvc;

namespace SmirnovaPR1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            if(name == null||name==" ")
            {
                return BadRequest("Поле не должно быть пустым!");
            }
            Summaries.Add(name);
            return Ok();  
        }
        [HttpPut]
        public IActionResult Update(int index, string name) 
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!");
            }
            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!");
            }
            Summaries.RemoveAt(index);
            return Ok();   
        }
        [HttpGet("{index}")]
        public string Vivod(int index)
        {
            
            if (index < 0 || index >= Summaries.Count)
            {
                return "Такой индекс неверный";
            }
            return Summaries[index];
        }
        int x = 0;
    }
}