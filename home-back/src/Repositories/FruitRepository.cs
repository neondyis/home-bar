using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class FruitRepository: BaseRepository<FruitRepository>, IFruitRepository
{
    public FruitRepository(BarContext context) : base(context)
    {
    }
}