using HotChocolate.Types;
using src.Models;

namespace src.GraphQL.Types;

public class InstructionType : ObjectType<Instruction>
{
  protected override void Configure(IObjectTypeDescriptor<Instruction> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor
      .Field(f => f.InstructionId)
      .Name("id")
      .Type<IdType>();

    descriptor
      .Field(f => f.Steps)
      .Type<ListType<InstructionStepType>>();
  }
}