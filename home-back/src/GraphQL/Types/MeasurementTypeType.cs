
using HotChocolate.Types;

namespace src.GraphQL.Types;

public class MeasurementTypeType : ObjectType<Models.MeasurementType>
{
  protected override void Configure(IObjectTypeDescriptor<Models.MeasurementType> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor
      .Field(f => f.MeasurementTypeId)
      .Name("id")
      .Type<IdType>();

    descriptor
      .Field(f => f.Unit)
      .Type<StringType>();
  }
}