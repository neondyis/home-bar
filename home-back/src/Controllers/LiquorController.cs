using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class LiquorController :  BaseController
{
    [HttpGet]
    public List<Liquor> Get() => DbContext.Liquors.ToList();
    [HttpPut]
    public Liquor Put(int id) => DbContext.Liquors.Find(id);
    
    
}