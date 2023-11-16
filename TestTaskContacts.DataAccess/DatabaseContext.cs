using Microsoft.EntityFrameworkCore;
using TestTaskContacts.Domain.Models;

namespace TestTaskContacts.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
