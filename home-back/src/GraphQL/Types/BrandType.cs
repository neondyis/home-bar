using HotChocolate.Types;
using src.Models;

namespace src.GraphQL.Types;

public class BrandType : ObjectType<Brand>
{
  protected override void Configure(IObjectTypeDescriptor<Brand> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor
      .Field(f => f.BrandId)
      .Name("id")
      .Type<IdType>();

    descriptor
      .Field(f => f.BrandName)
      .Type<StringType>();
  }
}