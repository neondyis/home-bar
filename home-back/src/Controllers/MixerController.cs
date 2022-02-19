using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class MixerController : ControllerBase
{
    private readonly IMixerRepository _mixerRepository;
    
    public MixerController(IMixerRepository mixerRepository)
    {
        _mixerRepository = mixerRepository;
    }
    
    [HttpGet("/api/[controller]/all",Name = "GetMixers")]
    public IEnumerable<Mixer> GetAll()
    {
        return _mixerRepository.GetAll();
    }
    
    [HttpGet(Name = "GetMixerByID")]
    public IEnumerable<Mixer> Get(int id)
    {
        return _mixerRepository.Find(x => x.IngredientId == id);
    }
    
    [HttpPost(Name = "PostMixer")]
    public async Task<ActionResult<Mixer>> Post([FromBody] Mixer mixer)
    {
        await _mixerRepository.Add(mixer);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = mixer.IngredientId }, mixer);
    }
    
    [HttpPut("{id}", Name = "PutMixer")]
    public async Task<IActionResult> Put(long id,[FromBody] Mixer mixer)
    {
        if (id != mixer.IngredientId)
        {
            return BadRequest();
        }else
        {
            await _mixerRepository.Put(mixer);
        }
        return NoContent();
    }
}