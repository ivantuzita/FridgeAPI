using System.ComponentModel.DataAnnotations;

namespace FridgeAPI.Data.DTOs {
    public class ReadIngredientDTO {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Quantity { get; set; }
    }
}
