using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{ 
    private readonly IBrandRepository _brandRepository;
    
    public BrandController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    
    [HttpGet(Name = "GetBrands")]
    public IEnumerable<Brand> Get()
    {
        return _brandRepository.GetAll();
    }
}