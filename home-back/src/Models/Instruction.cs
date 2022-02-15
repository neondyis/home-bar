namespace src.Models;

public class Instruction
{
    public int InstructionId { get; set; }
    public List<InstructionStep> Steps { get; set; }
}