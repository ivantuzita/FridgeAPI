using FridgeAPI.Data;
using FridgeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FridgeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FridgeController: ControllerBase
{

    private IngredientContext _context;

    public FridgeController(IngredientContext context) {
        _context = context;
    }

    [HttpPost]
    public IActionResult addIngredient([FromBody] Ingredient ingredient) {
        _context.Ingredients.Add(ingredient);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getIngredientById), new {id = ingredient.Id}, ingredient);
    }

    [HttpGet]
    public IEnumerable<Ingredient> getIngredients() { return _context.Ingredients; }

    [HttpGet("{id}")]
    public IActionResult getIngredientById(int id) {
        var ingredient = _context.Ingredients.FirstOrDefault(Ingredient => Ingredient.Id == id);
        if (ingredient == null) return NotFound();
        return Ok(ingredient);
    }
}
