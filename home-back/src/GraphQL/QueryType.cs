using HotChocolate.Types;

namespace src.GraphQL;
public class QueryType : ObjectType<RootQuery>
{
  protected override void Configure(IObjectTypeDescriptor<RootQuery> descriptor)
  {
    descriptor
      .Field(f => f.GetCocktails(default!))
      .Type<ListType<CocktailType>>();
  }
}