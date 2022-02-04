using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class CocktailController :  BaseController
{
    [HttpGet]
    public List<Cocktail> Get() => DbContext.Cocktails.ToList();
}