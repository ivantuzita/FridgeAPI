using System.ComponentModel.DataAnnotations;

namespace FridgeAPI.Models; 
public class Ingredient
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required (ErrorMessage = "The ingredient name is required.")]
    public string Content { get; set; }
    [Required(ErrorMessage = "There must be a valid number on the 'quantity' field.")]
    public int Quantity { get; set; }
}
