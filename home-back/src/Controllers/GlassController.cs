using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class GlassController :  BaseController
{
    [HttpGet]
    public List<Glass> Get() => DbContext.Glasses.ToList();
}