using PhoneBookApp.Entities.Abstract;

namespace PhoneBookApp.Entities.Concrete
{
    public class Contact : IEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }

        #region Table relationship
        public Guid UserId { get; set; }
        public User User { get; set; }
        #endregion
    }
}