using PhoneBookApp.Entities.Dtos;
using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.Business.Abstract
{
    public interface IUserService
    {
        void Add(UserAddDto userAddDto);
        void Delete(User user);
        void Update(UserEditDto userEditDto);
        User GetById(Guid id);
        UserListDto GetByUser(Guid userId);
        List<User> GetList();
        List<UserListDto> GetUserList();
    }
}