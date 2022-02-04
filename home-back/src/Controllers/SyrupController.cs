using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class SyrupController :  BaseController
{
    [HttpGet]
    public List<Syrup> Get() => DbContext.Syrups.ToList();
}