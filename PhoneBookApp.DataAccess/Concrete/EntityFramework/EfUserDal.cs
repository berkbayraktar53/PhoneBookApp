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

        public IQueryable GetRegisteredLocationCount()
        {
            var context = new PostgreSqlDbContext();
            var result = from user in context.Users
                         join contact in context.Contacts
                         on user.Id equals contact.UserId
                         where contact.Type == "Konum" && user.IsActive == true
                         group contact by contact.Content into contactcontent
                         select new
                         {
                             name = contactcontent.Key,
                             count = contactcontent.Select(p => p.Content).Distinct().Count()
                         };
            return result;
        }

        public IQueryable GetRegisteredPhoneCount()
        {
            var context = new PostgreSqlDbContext();
            var result = from user in context.Users
                         join contact in context.Contacts
                         on user.Id equals contact.UserId
                         where contact.Type == "Telefon" && user.IsActive == true
                         group contact by contact.Content into contactcontent
                         select new
                         {
                             name = contactcontent.Key,
                             count = contactcontent.Count()
                         };
            return result;
        }

        public IQueryable GetRegisteredUserCount()
        {
            var context = new PostgreSqlDbContext();
            var result = from user in context.Users
                         join contact in context.Contacts
                         on user.Id equals contact.UserId
                         where contact.Type == "Konum" && user.IsActive == true
                         group contact by contact.Content into contactcontent
                         select new
                         {
                             name = contactcontent.Key,
                             count = contactcontent.Count()
                         };
            return result;
        }

        public List<User> GetUserList()
        {
            var context = new PostgreSqlDbContext();
            return context.Users.Include(x => x.Contacts).ToList();
        }
    }
}