using src.Repositories.Interfaces;

namespace src.Repositories;

public class GarnishRepository: BaseRepository<GarnishRepository>, IGarnishRepository
{
    public GarnishRepository(BarContext context) : base(context)
    {
    }
}