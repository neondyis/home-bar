using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class GlassController : ControllerBase
{
    private readonly IGlassRepository _glassRepository;
    
    public GlassController(IGlassRepository glassRepository)
    {
        _glassRepository = glassRepository;
    }
    
    [HttpGet(Name = "GetGlasses")]
    public IEnumerable<Glass> GetAll()
    {
        return _glassRepository.GetAll();
    }
    
    [HttpGet(Name = "GetGlassByID")]
    public IEnumerable<Glass> Get(int id)
    {
        return _glassRepository.Find(x => x.GlassId == id);
    }
    
    [HttpPost(Name = "PostGlass")]
    public async Task<ActionResult<Glass>> Post(Glass glass)
    {
        await _glassRepository.Add(glass);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = glass.GlassId }, glass);
    }
    
    [HttpPut("{id}", Name = "PutGlass")]
    public async Task<IActionResult> Put(long id, Glass glass)
    {
        if (id != glass.GlassId)
        {
            return BadRequest();
        }else
        {
            await _glassRepository.Put(glass);
        }
        return NoContent();
    }
}