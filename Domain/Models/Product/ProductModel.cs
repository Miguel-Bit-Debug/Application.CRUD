using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Product
{
    public class ProductModel : BaseModel
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
    }
}
