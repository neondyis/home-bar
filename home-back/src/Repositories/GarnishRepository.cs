using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class GarnishRepository: BaseRepository<Garnish>, IGarnishRepository
{
    public GarnishRepository(BarContext context) : base(context)
    {
    }
}