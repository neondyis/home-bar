using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class CocktailController : ControllerBase
{
    private readonly ICocktailRepository _cocktailRepository;
    
    public CocktailController(ICocktailRepository cocktailRepository)
    {
        _cocktailRepository = cocktailRepository;
    }
    
    [HttpGet("/api/[controller]/all",Name = "GetCocktails")]
    public IEnumerable<Cocktail> GetAll()
    {
        return _cocktailRepository.GetAll();
    }
    
    [HttpGet(Name = "GetCocktailByID")]
    public IEnumerable<Cocktail> Get(int id)
    {
        return _cocktailRepository.Find(x => x.CocktailId == id);
    }
    
    [HttpPost(Name = "PostCocktail")]
    public async Task<ActionResult<Cocktail>> Post(Cocktail cocktail)
    {
        await _cocktailRepository.Add(cocktail);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = cocktail.CocktailId }, cocktail);
    }
    
    [HttpPut("{id}", Name = "PutCocktail")]
    public async Task<IActionResult> Put(long id, Cocktail cocktail)
    {
        if (id != cocktail.CocktailId)
        {
            return BadRequest();
        }else
        {
            await _cocktailRepository.Put(cocktail);
        }
        return NoContent();
    }
}