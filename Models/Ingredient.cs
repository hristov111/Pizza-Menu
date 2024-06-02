using System.ComponentModel.DataAnnotations;

namespace Menu.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public ICollection<DishIngredient>? DishIngredients{ get; set; }
    }
}
