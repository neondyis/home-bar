using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class LiquorController : ControllerBase
{
    private readonly ILiquorRepository _liquorRepository;
    
    public LiquorController(ILiquorRepository liquorRepository)
    {
        _liquorRepository = liquorRepository;
    }
    
    [HttpGet(Name = "GetLiquors")]
    public IEnumerable<Liquor> GetAll()
    {
        return _liquorRepository.GetAll();
    }
    
    [HttpGet(Name = "GetLiquorByID")]
    public IEnumerable<Liquor> Get(int id)
    {
        return _liquorRepository.Find(x => x.IngredientId == id);
    }
    
    [HttpPost(Name = "PostLiquor")]
    public async Task<ActionResult<Liquor>> Post(Liquor liquor)
    {
        await _liquorRepository.Add(liquor);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = liquor.IngredientId }, liquor);
    }
    
    [HttpPut("{id}", Name = "PutLiquor")]
    public async Task<IActionResult> Put(long id, Liquor liquor)
    {
        if (id != liquor.IngredientId)
        {
            return BadRequest();
        }else
        {
            await _liquorRepository.Put(liquor);
        }
        return NoContent();
    }
}