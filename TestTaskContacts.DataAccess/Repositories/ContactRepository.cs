using TestTaskContacts.DataAccess.Interfaces;
using TestTaskContacts.Domain.Models;

namespace TestTaskContacts.DataAccess.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
