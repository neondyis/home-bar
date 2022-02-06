using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class SyrupRepository: BaseRepository<Syrup>, ISyrupRepository
{
    public SyrupRepository(BarContext context) : base(context)
    {
    }
}