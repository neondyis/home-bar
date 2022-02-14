using HotChocolate.Types;
using src.Models;

namespace src.GraphQL;

public class InstructionStepType : ObjectType<InstructionStep>
{
  protected override void Configure(IObjectTypeDescriptor<InstructionStep> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor
      .Field(f => f.InstructionStepId)
      .Name("id")
      .Type<IdType>();

    descriptor
      .Field(f => f.Description)
      .Type<StringType>();
    
    descriptor
      .Field(f => f.Number)
      .Type<IntType>();
  }
}