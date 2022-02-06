using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class LiqueurRepository: BaseRepository<Liqueur>, ILiqueurRepository
{
    public LiqueurRepository(BarContext context) : base(context)
    {
    }
}