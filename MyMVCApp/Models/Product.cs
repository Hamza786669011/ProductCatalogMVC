using System.ComponentModel.DataAnnotations;

namespace MyMvcProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public required string Description { get; set; }

        public required string ImageUrl { get; set; }
    }
}
