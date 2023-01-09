using FridgeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FridgeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FridgeController: ControllerBase
{
    private static List<Ingredient> ingredients = new List<Ingredient>();
    private static int id = 0;

    [HttpPost]
    public IActionResult addIngredient([FromBody] Ingredient ingredient) {
        ingredient.Id = id++;
        ingredients.Add(ingredient);
        return CreatedAtAction(nameof(getIngredientById), new {id = ingredient.Id}, ingredient);
    }

    [HttpGet]
    public IEnumerable<Ingredient> getIngredients() { return ingredients; }

    [HttpGet("{id}")]
    public IActionResult getIngredientById(int id) {
        var ingredient = ingredients.FirstOrDefault(Ingredient => Ingredient.Id == id);
        if (ingredient == null) return NotFound();
        return Ok(ingredient);
    }
}
