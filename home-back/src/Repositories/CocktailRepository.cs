using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class CocktailRepository: BaseRepository<Cocktail>, ICocktailRepository
{
    public CocktailRepository(BarContext context) : base(context)
    {
    }
}