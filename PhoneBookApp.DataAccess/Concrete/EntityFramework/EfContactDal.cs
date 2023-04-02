using PhoneBookApp.Entities.Concrete;
using PhoneBookApp.DataAccess.Context;
using PhoneBookApp.DataAccess.Abstract;

namespace PhoneBookApp.DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact, PostgreSqlDbContext>, IContactDal
    {

    }
}