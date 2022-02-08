using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories.Interfaces;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class InstructionController : ControllerBase
{
    private readonly IInstructionsRepository _instructionRepository;
    
    public InstructionController(IInstructionsRepository instructionRepository)
    {
        _instructionRepository = instructionRepository;
    }
    
    [HttpGet(Name = "GetInstructions")]
    public IEnumerable<Instruction> GetAll()
    {
        return _instructionRepository.GetAll();
    }
    
    [HttpGet(Name = "GetInstructionByID")]
    public IEnumerable<Instruction> Get(int id)
    {
        return _instructionRepository.Find(x => x.InstructionId == id);
    }
    
    [HttpPost(Name = "PostInstruction")]
    public async Task<ActionResult<Instruction>> Post(Instruction instruction)
    {
        await _instructionRepository.Add(instruction);

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(Get), new { id = instruction.InstructionId }, instruction);
    }
    
    [HttpPut("{id}", Name = "PutInstruction")]
    public async Task<IActionResult> Put(long id, Instruction instruction)
    {
        if (id != instruction.InstructionId)
        {
            return BadRequest();
        }else
        {
            await _instructionRepository.Put(instruction);
        }
        return NoContent();
    }
}