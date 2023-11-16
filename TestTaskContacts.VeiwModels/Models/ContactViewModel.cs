using System.ComponentModel.DataAnnotations;

namespace TestTaskContacts.VeiwModels.Models
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string JobTitle { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = DateTime.Now;
    }
}
