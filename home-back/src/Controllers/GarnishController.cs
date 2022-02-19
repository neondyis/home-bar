using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class GarnishController : ControllerBase
{
    private readonly IGarnishRepository _garnishRepository;
    
    public GarnishController(IGarnishRepository garnishRepository)
    {
        _garnishRepository = garnishRepository;
    }
    
    [HttpGet("/api/[controller]/all",Name = "GetGarnishes")]
    public IEnumerable<Garnish> GetAll()
    {
        return _garnishRepository.GetAll();
    }
    
    [HttpGet(Name = "GetGarnishByID")]
    public IEnumerable<Garnish> Get(int id)
    {
        return _garnishRepository.Find(x => x.IngredientId == id);
    }
    
    [HttpPost(Name = "PostGarnish")]
    public async Task<ActionResult<Garnish>> Post([FromBody] Garnish garnish)
    {
        await _garnishRepository.Add(garnish);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = garnish.IngredientId }, garnish);
    }
    
    [HttpPut("{id}", Name = "PutGarnish")]
    public async Task<IActionResult> Put(long id, [FromBody] Garnish garnish)
    {
        if (id != garnish.IngredientId)
        {
            return BadRequest();
        }else
        {
            await _garnishRepository.Put(garnish);
        }
        return NoContent();
    }
}