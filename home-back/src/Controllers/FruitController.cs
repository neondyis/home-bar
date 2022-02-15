using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class FruitController : ControllerBase
{
    private readonly IFruitRepository _fruitRepository;
    
    public FruitController(IFruitRepository fruitRepository)
    {
        _fruitRepository = fruitRepository;
    }
    
    [HttpGet("/api/[controller]/all",Name = "GetFruits")]
    public IEnumerable<Fruit> GetAll()
    {
        return _fruitRepository.GetAll();
    }
    
    [HttpGet(Name = "GetFruitByID")]
    public IEnumerable<Fruit> Get(int id)
    {
        return _fruitRepository.Find(x => x.IngredientId == id);
    }
    
    [HttpPost(Name = "PostFruit")]
    public async Task<ActionResult<Fruit>> Post(Fruit fruit)
    {
        await _fruitRepository.Add(fruit);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = fruit.IngredientId }, fruit);
    }
    
    [HttpPut("{id}", Name = "PutFruit")]
    public async Task<IActionResult> Put(long id, Fruit fruit)
    {
        if (id != fruit.IngredientId)
        {
            return BadRequest();
        }else
        {
            await _fruitRepository.Put(fruit);
        }
        return NoContent();
    }
}