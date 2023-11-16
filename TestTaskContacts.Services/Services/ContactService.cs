using AutoMapper;
using TestTaskContacts.DataAccess.Interfaces;
using TestTaskContacts.Domain.Models;
using TestTaskContacts.Services.Interfaces;
using TestTaskContacts.VeiwModels.Models;

namespace TestTaskContacts.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateContactViewModel model)
        {
            var contact = _mapper.Map<Contact>(model);

            await _contactRepository.Add(contact);
        }

        public List<ContactViewModel> GetAll(GetContactsVeiwModel model)
        {
            var contacts = _contactRepository
                            .Get()
                            .Skip((model.Page - 1) * model.PageLength)
                            .Take(model.PageLength)
                            .AsEnumerable()
                            .ToList();

            return _mapper.Map<List<ContactViewModel>>(contacts);
        }

        public ContactViewModel GetById(Guid Id)
        {
            var contact = _contactRepository.Get(contact =>  contact.Id == Id).FirstOrDefault();

            if (contact == null)
            {
                throw new Exception();
            }

            return _mapper.Map<ContactViewModel>(contact);
        }

        public async Task Update(UpdateContactViewModel model)
        {
            var contact = _mapper.Map<Contact>(model);

            await _contactRepository.Update(contact);
        }

        public async Task Delete(Guid Id)
        {
            var contact = _contactRepository.Get(contact => contact.Id == Id).FirstOrDefault();

            if (contact == null)
            {
                throw new Exception();
            }

            await _contactRepository.Remove(contact);
        }
    }
}
