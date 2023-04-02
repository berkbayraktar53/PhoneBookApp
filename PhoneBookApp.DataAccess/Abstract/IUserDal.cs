using PhoneBookApp.Entities.Dtos;
using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        UserListDto GetByUser(Guid userId);
        List<UserListDto> GetUserList();
    }
}