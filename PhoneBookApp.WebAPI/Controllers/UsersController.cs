using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PhoneBookApp.Business.Abstract;
using PhoneBookApp.Entities.Concrete;
using PhoneBookApp.Entities.Dtos;

namespace PhoneBookApp.WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Add")]
        public IActionResult Add(UserAddDto userAddDto)
        {
            _userService.Add(userAddDto);
            return Ok("Kişi eklendi");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(User user)
        {
            _userService.Delete(user);
            return Ok("Kişi silindi");
        }

        [HttpPut("Update")]
        public IActionResult Update(UserEditDto userEditDto)
        {
            _userService.Update(userEditDto);
            return Ok("Kişi güncellendi");
        }

        [HttpGet("GetByUser/{id}")]
        public IActionResult GetByUser(Guid id)
        {
            var result = _userService.GetByUser(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = _userService.GetList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetUserList")]
        public IActionResult GetUserList()
        {
            var result = _userService.GetUserList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}