using PhoneBookApp.Business.Abstract;
using PhoneBookApp.Entities.Concrete;
using PhoneBookApp.DataAccess.Abstract;

namespace PhoneBookApp.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact GetById(Guid id)
        {
            return _contactDal.Get(p => p.Id == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetList();
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}