using HotChocolate.Types;
using src.Models;

namespace src.GraphQL;

public class CocktailType : ObjectType<Cocktail>
{
  protected override void Configure(IObjectTypeDescriptor<Cocktail> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor
      .Field(f => f.CocktailId)
      .Name("id")
      .Type<IdType>();
    
    descriptor
      .Field(f => f.Name)
      .Type<StringType>();

    descriptor
      .Field(f => f.Strength)
      .Type<StringType>();

    descriptor
      .Field(f => f.Ingredients)
      .Type<ListType<RecipeIngredientType>>();

    descriptor
      .Field(f => f.Instructions)
      .Type<ListType<InstructionType>>();
  }
}