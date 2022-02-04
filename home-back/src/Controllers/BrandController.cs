using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class BrandController :  BaseController
{ 
    [HttpGet]
    public List<Brand> Get() => DbContext.Brands.ToList();
}