using System;
using System.ComponentModel.DataAnnotations;

namespace TestTaskContacts.Domain.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
