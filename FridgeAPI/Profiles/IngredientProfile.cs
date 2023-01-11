using AutoMapper;
using FridgeAPI.Data.DTOs;
using FridgeAPI.Models;

namespace FridgeAPI.Profiles; 
public class IngredientProfile: Profile {

    public IngredientProfile() {
        CreateMap<CreateIngredientDTO, Ingredient>();
        CreateMap<UpdateIngredientDTO, Ingredient>();
    }
}
