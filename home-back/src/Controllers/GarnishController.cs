using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class GarnishController :  BaseController
{
    [HttpGet]
    public List<Garnish> Get() => DbContext.Garnishes.ToList();
}