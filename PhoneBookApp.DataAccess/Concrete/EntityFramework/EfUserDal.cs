using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Entities.Concrete;
using PhoneBookApp.DataAccess.Context;
using PhoneBookApp.DataAccess.Abstract;

namespace PhoneBookApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, PostgreSqlDbContext>, IUserDal
    {
        public User GetByUser(Guid userId)
        {
            var context = new PostgreSqlDbContext();
            return context.Users.Include(x => x.Contacts).Where(p => p.Id == userId).SingleOrDefault();
        }

        public List<User> GetUserList()
        {
            var context = new PostgreSqlDbContext();
            return context.Users.Include(x => x.Contacts).ToList();
        }
    }
}