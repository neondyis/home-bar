using src.Models;
using src.Repositories.Interfaces;

namespace src.GraphQL
{
  public class Query
  {
    public IEnumerable<Cocktail> GetCocktails([Service] ICocktailRepository cocktailRepository)
    {
      return cocktailRepository.GetAll();
    }
    
    public Cocktail GetCocktailById([Service] ICocktailRepository cocktailRepository, int id)
    {
      return cocktailRepository.GetById(id);
    }
  }
}