using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientRepository _ingredientRepository;
    
    public IngredientController(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    
    [HttpGet(Name = "GetIngredients")]
    public IEnumerable<Ingredient> GetAll()
    {
        return _ingredientRepository.GetAll();
    }
    
    [HttpGet(Name = "GetIngredientByID")]
    public IEnumerable<Ingredient> Get(int id)
    {
        return _ingredientRepository.Find(x => x.IngredientId == id);
    }
    
    [HttpPost(Name = "PostIngredient")]
    public async Task<ActionResult<Ingredient>> Post(Ingredient ingredient)
    {
        await _ingredientRepository.Add(ingredient);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = ingredient.IngredientId }, ingredient);
    }
    
    [HttpPut("{id}", Name = "PutIngredient")]
    public async Task<IActionResult> Put(long id, Ingredient ingredient)
    {
        if (id != ingredient.IngredientId)
        {
            return BadRequest();
        }else
        {
            await _ingredientRepository.Put(ingredient);
        }
        return NoContent();
    }
}