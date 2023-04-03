using PhoneBookApp.Business.Abstract;
using PhoneBookApp.Entities.Concrete;
using PhoneBookApp.DataAccess.Abstract;

namespace PhoneBookApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IContactService _contactService;

        public UserManager(IUserDal userDal, IContactService contactService)
        {
            _userDal = userDal;
            _contactService = contactService;
        }

        public void Add(User user)
        {
            user.IsActive = true;
            _userDal.Add(user);
            var getUser = GetByUser(user.Id);
            Contact contact = new()
            {
                Content = user.Contacts[0].Content,
                Type = user.Contacts[0].Type,
                UserId = getUser.Id,
                User = getUser,
                IsActive = true
            };
            _contactService.Add(contact);
        }

        public void ChangeStatus(Guid id)
        {
            var user = GetByUser(id);
            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
            _userDal.Update(user);
            var userContact = user.Contacts[0];
            if (userContact.IsActive == true)
            {
                userContact.IsActive = false;
            }
            else
            {
                userContact.IsActive = true;
            }
            _contactService.Update(userContact);
        }

        public void Delete(Guid id)
        {
            var user = GetByUser(id);
            if (user.Contacts[0].IsActive == false)
            {
                _contactService.Delete(user.Contacts[0]);
            }
            else
            {
                user.Contacts[0].IsActive = false;
                _contactService.Update(user.Contacts[0]);
            }
            if (user.IsActive == false)
            {
                _userDal.Delete(user);
            }
            else
            {
                user.IsActive = false;
                _userDal.Update(user);
            }
        }

        public User GetById(Guid id)
        {
            return _userDal.Get(p => p.Id == id);
        }

        public User GetByUser(Guid userId)
        {
            return _userDal.GetByUser(userId);
        }

        public List<User> GetDeletedUserList()
        {
            return _userDal.GetUserList().Where(p => p.IsActive == false).OrderBy(p => p.FirstName).ToList();
        }

        public List<User> GetList()
        {
            return _userDal.GetList(p => p.IsActive == true);
        }

        public List<User> GetUserList()
        {
            return _userDal.GetUserList().Where(p => p.IsActive == true).OrderBy(p => p.FirstName).ToList();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
            _contactService.Update(user.Contacts[0]);
        }
    }
}