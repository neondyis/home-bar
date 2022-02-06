using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class InstructionRepository: BaseRepository<Instruction>, IInstructionsRepository
{
    public InstructionRepository(BarContext context) : base(context)
    {
    }
}