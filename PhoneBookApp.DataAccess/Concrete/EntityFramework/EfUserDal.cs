using PhoneBookApp.Entities.Dtos;
using PhoneBookApp.Entities.Concrete;
using PhoneBookApp.DataAccess.Context;
using PhoneBookApp.DataAccess.Abstract;

namespace PhoneBookApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, PostgreSqlDbContext>, IUserDal
    {
        public UserListDto GetByUser(Guid userId)
        {
            var context = new PostgreSqlDbContext();
            var result = from user in context.Users.Where(p => p.Id == userId)
                         select new UserListDto
                         {
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Company = user.Company,
                             ContactList = context.Contacts.Where(p => p.UserId == user.Id).ToList()
                         };
            return result.FirstOrDefault();
        }

        public List<UserListDto> GetUserList()
        {
            var context = new PostgreSqlDbContext();
            var result = from user in context.Users
                         select new UserListDto
                         {
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Company = user.Company,
                             ContactList = context.Contacts.Where(p => p.UserId == user.Id).ToList()
                         };
            return result.ToList();
        }
    }
}