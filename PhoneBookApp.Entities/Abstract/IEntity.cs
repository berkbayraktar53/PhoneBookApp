namespace PhoneBookApp.Entities.Abstract
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}