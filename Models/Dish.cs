using System.ComponentModel.DataAnnotations;
using System;
namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required(ErrorMessage = "Got to name the dish!")]
        [MinLength(2, ErrorMessage = "Must have more than two character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The chef must be named!")]
        [MinLength(2, ErrorMessage = "Must have more than two character")]
        public string Chef { get; set; }

        [Required(ErrorMessage = "How does it taste!?")]
        public int? Tastiness { get; set; }

        [Required(ErrorMessage = "Hey fatty! How many calories!?")]
        public int? Calories { get; set; }

        [Required(ErrorMessage = "Tell me something about this!")]
        [MinLength(2, ErrorMessage = "Must have more than two character")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}