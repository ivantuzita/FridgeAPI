using AutoMapper;
using FridgeAPI.Data;
using FridgeAPI.Data.DTOs;
using FridgeAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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
    public IEnumerable<ReadIngredientDTO> getIngredients() { return _mapper.Map<List<ReadIngredientDTO>>(_context.Ingredients); }

    [HttpGet("{id}")]
    public IActionResult getIngredientById(int id) {
        var ingredient = _context.Ingredients.FirstOrDefault(Ingredient => Ingredient.Id == id);
        if (ingredient == null) return NotFound();
        var ingredientDTO = _mapper.Map<ReadIngredientDTO>(ingredient);
        return Ok(ingredientDTO);
    }

    [HttpPut("{id}")]
    public IActionResult updateIngredient(int id, [FromBody] UpdateIngredientDTO ingredientDTO) {
        var ingredient = _context.Ingredients.FirstOrDefault(ingredient => ingredient.Id == id);
        if (ingredient == null) return NotFound();
        _mapper.Map(ingredientDTO, ingredient);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult patchIngredient(int id, JsonPatchDocument<UpdateIngredientDTO> patch) {
        var ingredient = _context.Ingredients.FirstOrDefault(ingredient => ingredient.Id == id);
        if (ingredient == null) return NotFound();

        var ingredientToUpdate = _mapper.Map<UpdateIngredientDTO>(ingredient);

        patch.ApplyTo(ingredientToUpdate, ModelState);

        if (!TryValidateModel(ingredientToUpdate)) {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(ingredientToUpdate, ingredient);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteIngredient(int id)
    {
        var ingredient = _context.Ingredients.FirstOrDefault(ingredient => ingredient.Id == id);
        if (ingredient == null) return NotFound();
        _context.Remove(ingredient);
        _context.SaveChanges();
        return NoContent();
    }
}
