using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BrandController : ControllerBase
{ 
    private readonly IBrandRepository _brandRepository;
    
    public BrandController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    
    [HttpGet("/api/[controller]/all",Name = "GetBrands")]
    public IEnumerable<Brand> GetAll()
    {
        return _brandRepository.GetAll();
    }
    
    [HttpGet(Name = "GetBrandByID")]
    public IEnumerable<Brand> Get(int id)
    {
        return _brandRepository.Find(x => x.BrandId == id);
    }
    
    [HttpPost(Name = "PostBrand")]
    public async Task<ActionResult<Brand>> Post([FromBody] String brand)
    {
        await _brandRepository.Add(new Brand{BrandName = brand});

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return NoContent();
    }
    
    [HttpPut("{id}", Name = "PutBrand")]
    public async Task<IActionResult> PutTodoItem(long id, Brand brand)
    {
        if (id != brand.BrandId)
        {
            return BadRequest();
        }else
        {
            await _brandRepository.Put(brand);
        }
        return NoContent();
    }
}