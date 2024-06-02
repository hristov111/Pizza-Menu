using System.ComponentModel.DataAnnotations;

namespace Menu.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public ICollection<DishIngredient>? DishIngredients { get; set; }
    }
}
