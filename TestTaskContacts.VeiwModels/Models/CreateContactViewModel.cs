using System.ComponentModel.DataAnnotations;
namespace TestTaskContacts.VeiwModels.Models
{
    public class CreateContactViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(12)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}