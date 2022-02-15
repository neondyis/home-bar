using HotChocolate.Types;
using src.GraphQL.Types;

namespace src.GraphQL;

public class MutationType : ObjectType<Mutation>
{
  protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
  {
    descriptor
      .Field(f => f.AddCocktail(default!, default!))
      .Argument("input", a => a.Type<CocktailInputType>());
  }
}