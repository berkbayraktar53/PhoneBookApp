using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.DataAccess.Context
{
    public class PostgreSqlDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PhoneBookAppDb;User Id=postgres;Password=123456");
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}