using System.ComponentModel.DataAnnotations;

namespace SwaggerDemo.Models
{
    public class ProductModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
