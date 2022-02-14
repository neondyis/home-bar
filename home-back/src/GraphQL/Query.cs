using HotChocolate;
using src.Models;
using src.Repositories.Interfaces;

namespace src.GraphQL
{
  public class RootQuery
  {

    public IEnumerable<Cocktail> GetCocktails([Service] ICocktailRepository cocktailRepository)
    {
      return cocktailRepository.GetAll();
    }
  }
}