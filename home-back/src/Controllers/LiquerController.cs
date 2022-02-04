using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class LiquerController :  BaseController
{
    [HttpGet]
    public List<Liqueur> Get() => DbContext.Liquers.ToList();
}