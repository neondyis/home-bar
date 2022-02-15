using HotChocolate.Types;
using src.GraphQL.Types;
using src.Models;

namespace src.GraphQL.Types;

public class IngredientType : ObjectType<Ingredient>
{
  protected override void Configure(IObjectTypeDescriptor<Ingredient> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor
      .Field(f => f.IngredientId)
      .Name("id")
      .Type<IdType>();
    
    descriptor
      .Field(f => f.Type)
      .Type<StringType>();
    
    descriptor
      .Field(f => f.Name)
      .Type<StringType>();
    
    descriptor
      .Field(f => f.Brand)
      .Type<BrandType>();
  }
}