using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class BrandRepository: BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(BarContext context) : base(context)
    {
    }
}