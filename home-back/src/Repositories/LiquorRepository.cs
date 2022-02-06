using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class LiquorRepository: BaseRepository<Liquor>, ILiquorRepository
{
    public LiquorRepository(BarContext context) : base(context)
    {
    }
}