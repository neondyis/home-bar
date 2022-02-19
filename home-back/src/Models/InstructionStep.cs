using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models;

public class InstructionStep
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InstructionStepId { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }
    
    public Instruction Instruction { get; set; }
    
    public int InstructionId { get; set; }
}