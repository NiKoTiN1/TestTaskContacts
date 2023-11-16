using AutoMapper;
using TestTaskContacts.Domain.Models;
using TestTaskContacts.VeiwModels.Models;

namespace TestTaskContacts.VeiwModels.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactViewModel, Contact>()
                .ForMember(x => x.Id, options => options.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.Phone, options => options.MapFrom(x => x.Phone))
                .ForMember(x => x.BirthDate, options => options.MapFrom(x => x.BirthDate))
                .ForMember(x => x.JobTitle, options => options.MapFrom(x => x.JobTitle));

            CreateMap<UpdateContactViewModel, Contact>()
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.Phone, options => options.MapFrom(x => x.Phone))
                .ForMember(x => x.BirthDate, options => options.MapFrom(x => x.BirthDate))
                .ForMember(x => x.JobTitle, options => options.MapFrom(x => x.JobTitle));

            CreateMap<Contact, ContactViewModel>()
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.Phone, options => options.MapFrom(x => x.Phone))
                .ForMember(x => x.BirthDate, options => options.MapFrom(x => x.BirthDate))
                .ForMember(x => x.JobTitle, options => options.MapFrom(x => x.JobTitle));
        }
    }
}
