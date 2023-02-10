using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace SmirnovaPR2.Controllers
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<WeatherData> weatherdatas = new()
        { 
            new WeatherData(){ Id = 1, Date ="21.01.2022",Degree=10,Location="Murmansk"},
            new WeatherData(){ Id =2,Date="10.08.2019",Degree=20,Location="Perm"},
            new WeatherData(){ Id=3,Date="07.02.2021",Degree=0,Location="Samara"},
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<WeatherData> GetAll()
        {
            return weatherdatas;
        }
        [HttpPost]
        public IActionResult Add(WeatherData data)
        {
            if (data.Id < 0)
            {
                return BadRequest("Id не должен быть меньше нул€");
            }
            for(int i = 0; i < weatherdatas.Count; i++)
            {
                if (weatherdatas[i].Id == data.Id)
                {
                    return BadRequest("«апись с таким Id уже есть");
                }
            }
            weatherdatas.Add(data);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(WeatherData data)
        {
            if (data.Id < 0)
            {
                return BadRequest("Id не должен быть меньше нул€");
            }
            for (int i = 0; i < weatherdatas.Count; i++)
            {
                if (weatherdatas[i].Id == data.Id)
                {
                    weatherdatas[i] = data;
                    return Ok();
                }
            }
            return BadRequest("“ака€ запись не обнаружена");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for(int i = 0; i < weatherdatas.Count; i++)
            {
                if (weatherdatas[i].Id == id)
                {
                    weatherdatas.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("“ака€ запись не обнаружена");
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            for(int i = 0; i < weatherdatas.Count; i++)
            {
                if (weatherdatas[i].Id == id)
                {
                    return Ok(weatherdatas[i]);
                }
            }
            return BadRequest("“ака€ запись не обнаружена");
        }
        [HttpGet("find-by-city")]
        public IActionResult GetByCityName(string location)
        {
            for(int i = 0; i < weatherdatas.Count; i++)
            {
                if (weatherdatas[i].Location == location)
                {
                    return Ok("«апись с указанным городом имеетс€ в нашем списке");
                }
            }
            return BadRequest("«апись с указанным городом не обнаружена");
        }
    }
}