using src.GraphQL.DTOs;

namespace src.GraphQL.Types;

public class CocktailInputType : InputObjectType<CocktailInput>
{
  protected override void Configure(IInputObjectTypeDescriptor<CocktailInput> descriptor)
  {
    descriptor
      .Field(f => f.Name)
      .Type<StringType>();
    
    descriptor
      .Field(f => f.Strength)
      .Type<StringType>();
  }
}