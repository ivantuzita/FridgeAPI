using AutoMapper;
using FridgeAPI.Data;
using FridgeAPI.Data.DTOs;
using FridgeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FridgeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FridgeController: ControllerBase
{

    private IngredientContext _context;
    private IMapper _mapper;

    public FridgeController(IngredientContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult addIngredient([FromBody] CreateIngredientDTO ingredientDTO) {
        Ingredient ingredient = _mapper.Map<Ingredient>(ingredientDTO);
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
