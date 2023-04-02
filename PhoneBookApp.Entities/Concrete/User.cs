using PhoneBookApp.Entities.Abstract;

namespace PhoneBookApp.Entities.Concrete
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public bool IsActive { get; set; }

        #region Table relationship
        public List<Contact> Contacts { get; set; }
        #endregion
    }
}