using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(Guid id);
        void ChangeStatus(Guid id);
        User GetById(Guid id);
        User GetByUser(Guid userId);
        List<User> GetList();
        List<User> GetUserList();
        List<User> GetDeletedUserList();
        List<User> Get5LastAddedUsers();
        IQueryable GetRegisteredUserCount();
        IQueryable GetRegisteredPhoneCount();
        IQueryable GetRegisteredLocationCount();
    }
}