using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        User GetByUser(Guid userId);
        List<User> GetUserList();
        IQueryable GetRegisteredUserCount();
        IQueryable GetRegisteredPhoneCount();
        IQueryable GetRegisteredLocationCount();
    }
}