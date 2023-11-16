using TestTaskContacts.VeiwModels.Models;

namespace TestTaskContacts.Services.Interfaces
{
    public interface IContactService
    {
        Task Create(CreateContactViewModel model);
        List<ContactViewModel> GetAll(GetContactsVeiwModel model);
        ContactViewModel GetById(Guid Id);
        Task Update(UpdateContactViewModel model);
        Task Delete(Guid Id);
    }
}
