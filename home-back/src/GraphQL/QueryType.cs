using HotChocolate.Types;
using src.GraphQL.Types;

namespace src.GraphQL;
public class QueryType : ObjectType<Query>
{
  protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
  {
    descriptor
      .Field(f => f.GetCocktails(default!))
      .Type<ListType<CocktailType>>();

    descriptor
      .Field(f => f.GetCocktailById(default!, default!))
      .Argument("id", arg=>arg.Type<NonNullType<IdType>>())
      .Type<CocktailType>();
  }
}