using Autofac;
using PhoneBookApp.Business.Abstract;
using PhoneBookApp.Business.Concrete;
using PhoneBookApp.DataAccess.Abstract;
using PhoneBookApp.DataAccess.Concrete.EntityFramework;

namespace PhoneBookApp.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<EfContactDal>().As<IContactDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
        }
    }
}