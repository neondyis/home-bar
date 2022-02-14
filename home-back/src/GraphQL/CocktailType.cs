using src.Models;

namespace src.GraphQL;

public class CocktailType : ObjectType<Cocktail>
{
  protected override void Configure(IObjectTypeDescriptor<Cocktail> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor
      .Field(f => f.CocktailId)
      .Type<IdType>();


    descriptor
      .Field(f => f.Name)
      .Type<StringType>();

    descriptor
      .Field(f => f.Strength)
      .Type<StringType>();
    
    
  }
}
//
// Name = nameof(Cocktail);
// Description = "A cocktail";
//
// Field(cocktail => cocktail.CocktailId).Description("ID");
// Field(cocktail => cocktail.Name).Description("The Name");
//     
// Field(
//   name: "Ingredients",
//   description: "The ingredients needed for the cocktail",
//   type: typeof(ListGraphType<RecipeIngredientsType>),
//   resolve: m => m.Source.Ingredients);
//
// Field(
//   name: "Instructions",
//   type: typeof(ListGraphType<InstructionType>),
//   resolve: m=>m.Source.Instructions);