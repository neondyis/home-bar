using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class FruitController :  BaseController
{
    [HttpGet]
    public List<Fruit> Get() => DbContext.Fruits.ToList();
}