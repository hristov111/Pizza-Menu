using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
    public class MenuDbContext: DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite primary key for the join entity
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId,
            });

            // Define relationships
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);

			// Seed data with primary keys
			modelBuilder.Entity<Dish>().HasData(
                new Dish { DishId = 1, Name = "Margherita", Price = 15.88, ImageUrl = "https://static.toiimg.com/photo/56868564.cms" }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId =1, Name = "Garlic" },
                new Ingredient { IngredientId = 2, Name = "Tomato sauce" }
            );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1},
                new DishIngredient { DishId = 1, IngredientId = 2}
                ); 

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes {  get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
