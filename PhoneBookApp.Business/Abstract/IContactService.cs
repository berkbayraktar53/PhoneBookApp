using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.Business.Abstract
{
    public interface IContactService
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
        Contact GetById(Guid id);
        List<Contact> GetList();
    }
}