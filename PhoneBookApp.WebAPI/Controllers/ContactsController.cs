using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PhoneBookApp.Business.Abstract;
using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Contact contact)
        {
            _contactService.Add(contact);
            return Ok("İletişim bilgisi eklendi");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Contact contact)
        {
            _contactService.Delete(contact);
            return Ok("İletişim bilgisi silindi");
        }

        [HttpPut("Update")]
        public IActionResult Update(Contact contact)
        {
            _contactService.Update(contact);
            return Ok("İletişim bilgisi güncellendi");
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = _contactService.GetList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}