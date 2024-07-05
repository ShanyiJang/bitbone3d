using Bitbone3d.Samples;
using Xunit;

namespace Bitbone3d.EntityFrameworkCore.Domains;

[Collection(Bitbone3dTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<Bitbone3dEntityFrameworkCoreTestModule>
{

}
