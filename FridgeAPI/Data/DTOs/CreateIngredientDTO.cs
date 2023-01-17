using System.ComponentModel.DataAnnotations;

namespace FridgeAPI.Data.DTOs; 
public class CreateIngredientDTO {
    [Required(ErrorMessage = "The ingredient name is required.")]
    [StringLength(30, ErrorMessage ="Ingredient name cannot exceed 30 characters.")]
    public string Content { get; set; }
    [Required(ErrorMessage = "There must be a valid number on the 'quantity' field.")]
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
