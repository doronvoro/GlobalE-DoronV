using GlobalE.BL;
using Microsoft.AspNetCore.Mvc;

namespace GlobalE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimerController : ControllerBase
    {
        private readonly TimerService _timerService;

        public TimerController(TimerService timerService)
        {
            _timerService = timerService;
        }

        [HttpPost("SetTimer")]
        public ActionResult<TimerResponse> SetTimer([FromBody] TimerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _timerService.SetTimer(request);
            return Ok(response);
        }

        [HttpGet("GetTimerStatus/{id}")]
        public ActionResult<TimerStatusResponse> GetTimerStatus(Guid id)
        {
            var response = _timerService.GetTimerStatus(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}