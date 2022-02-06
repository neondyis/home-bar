using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class GlassRepository: BaseRepository<Glass>, IGlassRepository
{
    public GlassRepository(BarContext context) : base(context)
    {
    }
}