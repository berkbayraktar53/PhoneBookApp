using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PhoneBookApp.Business.Abstract;

namespace PhoneBookApp.WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IUserService _userService;

        public ReportsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetRegisteredLocationCount")]
        public IActionResult GetRegisteredLocationCount()
        {
            var result = _userService.GetRegisteredLocationCount();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetRegisteredUserCount")]
        public IActionResult GetRegisteredUserCount()
        {
            var result = _userService.GetRegisteredUserCount();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetRegisteredPhoneCount")]
        public IActionResult GetRegisteredPhoneCount()
        {
            var result = _userService.GetRegisteredPhoneCount();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}