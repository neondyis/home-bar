using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models;

public class Instruction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InstructionId { get; set; }
    public List<InstructionStep> Steps { get; set; }
    
    public Cocktail? Cocktail { get; set; }
    
    public int CocktailId { get; set; }
}