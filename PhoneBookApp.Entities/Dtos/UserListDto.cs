using PhoneBookApp.Entities.Abstract;
using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.Entities.Dtos
{
    public class UserListDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<Contact> ContactList { get; set; }
    }
}