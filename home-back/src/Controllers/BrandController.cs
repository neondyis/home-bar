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
    
    [HttpGet(Name = "GetBrands")]
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
    public async Task<ActionResult<Brand>> Post(Brand brand)
    {
        await _brandRepository.Add(brand);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = brand.BrandId }, brand);
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