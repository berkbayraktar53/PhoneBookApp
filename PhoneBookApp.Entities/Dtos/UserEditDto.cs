using PhoneBookApp.Entities.Abstract;

namespace PhoneBookApp.Entities.Dtos
{
    public class UserEditDto : IDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string ContactContent { get; set; }
        public string ContactType { get; set; }
    }
}