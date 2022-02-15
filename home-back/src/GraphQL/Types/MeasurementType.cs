using HotChocolate.Types;
using src.Models;

namespace src.GraphQL.Types;

public class MeasurementType : ObjectType<Measurement>
{
  protected override void Configure(IObjectTypeDescriptor<Measurement> descriptor)
  {
    descriptor.BindFieldsExplicitly();
    
    descriptor
      .Field(f => f.MeasurementId)
      .Name("id")
      .Type<IdType>();

    descriptor
      .Field(f => f.Type)
      .Type<MeasurementTypeType>();

    descriptor
      .Field(f => f.Value)
      .Type<FloatType>();
  }
}