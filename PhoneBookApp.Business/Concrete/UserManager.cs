using PhoneBookApp.Entities.Dtos;
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

        public void Add(UserAddDto userAddDto)
        {
            User user = new()
            {
                FirstName = userAddDto.FirstName,
                LastName = userAddDto.LastName,
                Company = userAddDto.Company,
                IsActive = true
            };
            _userDal.Add(user);
            if (userAddDto.ContactType != null)
            {
                Contact contact = new()
                {
                    UserId = _userDal.GetList().TakeLast(1).Select(p => p.Id).FirstOrDefault(),
                    Content = userAddDto.ContactContent,
                    Type = userAddDto.ContactType,
                    IsActive = true
                };
                _contactService.Add(contact);
            }
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(Guid id)
        {
            return _userDal.Get(p => p.Id == id);
        }

        public UserListDto GetByUser(Guid userId)
        {
            return _userDal.GetByUser(userId);
        }

        public List<User> GetList()
        {
            return _userDal.GetList(p => p.IsActive == true);
        }

        public List<UserListDto> GetUserList()
        {
            return _userDal.GetUserList();
        }

        public void Update(UserEditDto userEditDto)
        {
            User user = new()
            {
                Id = userEditDto.UserId,
                FirstName = userEditDto.FirstName,
                LastName = userEditDto.LastName,
                Company = userEditDto.Company,
                IsActive = true
            };
            _userDal.Update(user);
            if (userEditDto.ContactType != null)
            {
                Contact contact = new()
                {
                    UserId = userEditDto.UserId,
                    Content = userEditDto.ContactContent,
                    Type = userEditDto.ContactType,
                    IsActive = true
                };
                _contactService.Update(contact);
            }
            _userDal.Update(user);
        }
    }
}