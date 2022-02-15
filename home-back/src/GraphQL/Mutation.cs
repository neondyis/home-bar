using HotChocolate;
using src.GraphQL.DTOs;
using src.Models;
using src.Repositories.Interfaces;

namespace src.GraphQL;

public class Mutation
{
  public Task<Cocktail> AddCocktail([Service] ICocktailRepository cocktailRepository, CocktailInput input)
  {
    Cocktail cocktail = new Cocktail
    {
      Name = input.Name,
      Strength = input.Strength
    };

   cocktailRepository.Add(cocktail);

    return Task.FromResult(cocktail);
  }
}