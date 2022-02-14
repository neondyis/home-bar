using HotChocolate.Types;
using src.Models;

namespace src.GraphQL.Types;

public class RecipeIngredientType : ObjectType<RecipeIngredient>
{
  protected override void Configure(IObjectTypeDescriptor<RecipeIngredient> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor
      .Field(f => f.RecipeIngredientId)
      .Type<IdType>();

    descriptor
      .Field(f => f.Ingredient)
      .Type<IngredientType>();

    descriptor
      .Field(f => f.Measurement)
      .Type<MeasurementType>();

    descriptor
      .Field(f => f.RecipeIngredientId)
      .Type<IdType>();
  }
}