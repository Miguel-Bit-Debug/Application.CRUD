using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
