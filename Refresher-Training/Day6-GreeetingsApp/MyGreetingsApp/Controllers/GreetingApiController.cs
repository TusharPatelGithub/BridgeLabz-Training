using Microsoft.AspNetCore.Mvc;
using MyGreetingsApp.Models;

namespace MyGreetingsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreetingApiController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<GreetingResponse> GetGreeting(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name is required.");
            }

            var now = DateTime.Now;
            string timeOfDay = GetTimeOfDay(now.Hour);

            var response = new GreetingResponse
            {
                Message = $"Good {timeOfDay}, {name}!",
                TimeOfDay = timeOfDay,
                ServerTime = now
            };

            return Ok(response);
        }

        private string GetTimeOfDay(int hour)
        {
            if (hour >= 5 && hour < 12) return "Morning";
            if (hour >= 12 && hour < 17) return "Afternoon";
            if (hour >= 17 && hour < 21) return "Evening";
            return "Night";
        }
    }
}