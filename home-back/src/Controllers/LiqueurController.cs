using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class LiqueurController : ControllerBase
{
    private readonly ILiqueurRepository _liqueurRepository;
    
    public LiqueurController(ILiqueurRepository liqueurRepository)
    {
        _liqueurRepository = liqueurRepository;
    }
    
    [HttpGet(Name = "GetLiqueurs")]
    public IEnumerable<Liqueur> GetAll()
    {
        return _liqueurRepository.GetAll();
    }
    
    [HttpGet(Name = "GetLiqueurByID")]
    public IEnumerable<Liqueur> Get(int id)
    {
        return _liqueurRepository.Find(x => x.IngredientId == id);
    }
    
    [HttpPost(Name = "PostLiqueur")]
    public async Task<ActionResult<Liqueur>> Post(Liqueur liqueur)
    {
        await _liqueurRepository.Add(liqueur);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = liqueur.IngredientId }, liqueur);
    }
    
    [HttpPut("{id}", Name = "PutLiqueur")]
    public async Task<IActionResult> Put(long id, Liqueur liqueur)
    {
        if (id != liqueur.IngredientId)
        {
            return BadRequest();
        }else
        {
            await _liqueurRepository.Put(liqueur);
        }
        return NoContent();
    }
}