using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class SyrupController : ControllerBase
{
    private readonly ISyrupRepository _syrupRepository;
    
    public SyrupController(ISyrupRepository syrupRepository)
    {
        _syrupRepository = syrupRepository;
    }
    
    [HttpGet("/api/[controller]/all",Name = "GetSyrups")]
    public IEnumerable<Syrup> GetAll()
    {
        return _syrupRepository.GetAll();
    }
    
    [HttpGet(Name = "GetSyrupByID")]
    public IEnumerable<Syrup> Get(int id)
    {
        return _syrupRepository.Find(x => x.IngredientId == id);
    }
    
    [HttpPost(Name = "PostSyrup")]
    public async Task<ActionResult<Syrup>> Post([FromBody] Syrup syrup)
    {
        await _syrupRepository.Add(syrup);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = syrup.IngredientId }, syrup);
    }
    
    [HttpPut("{id}", Name = "PutSyrup")]
    public async Task<IActionResult> Put(long id,[FromBody] Syrup syrup)
    {
        if (id != syrup.IngredientId)
        {
            return BadRequest();
        }else
        {
            await _syrupRepository.Put(syrup);
        }
        return NoContent();
    }
}