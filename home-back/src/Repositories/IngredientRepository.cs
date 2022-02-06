using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class IngredientRepository: BaseRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(BarContext context) : base(context)
    {
    }
}