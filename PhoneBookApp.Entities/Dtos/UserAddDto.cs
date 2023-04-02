using PhoneBookApp.Entities.Abstract;

namespace PhoneBookApp.Entities.Dtos
{
    public class UserAddDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string ContactContent { get; set; }
        public string ContactType { get; set; }
    }
}