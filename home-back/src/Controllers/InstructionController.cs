using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class InstructionController :  BaseController
{
    [HttpGet]
    public List<Instruction> Get() => DbContext.Instructions.ToList();
}