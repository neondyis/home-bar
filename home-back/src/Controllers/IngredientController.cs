using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class IngredientController :  BaseController
{
    [HttpGet]
    public List<Ingredient> Get() => DbContext.Ingredients.ToList();
}