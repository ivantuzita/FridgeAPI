using FridgeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FridgeAPI.Data; 
public class IngredientContext: DbContext {

    public IngredientContext(DbContextOptions<IngredientContext> opts) : base(opts)
        {

        }

    public DbSet<Ingredient> Ingredients { get; set; }
}
