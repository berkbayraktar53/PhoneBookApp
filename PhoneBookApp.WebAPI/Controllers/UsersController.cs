using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PhoneBookApp.Business.Abstract;
using PhoneBookApp.Entities.Concrete;

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
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return Ok("Kişi eklendi");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok("Kişi silindi");
        }

        [HttpPut("Update")]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
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

        [HttpPut("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(Guid id)
        {
            _userService.ChangeStatus(id);
            return Ok("Durum değiştirildi");
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

        [HttpGet("GetDeletedUserList")]
        public IActionResult GetDeletedUserList()
        {
            var result = _userService.GetDeletedUserList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}