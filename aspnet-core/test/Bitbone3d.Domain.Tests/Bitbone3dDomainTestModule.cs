using Volo.Abp.Modularity;

namespace Bitbone3d;

[DependsOn(
    typeof(Bitbone3dDomainModule),
    typeof(Bitbone3dTestBaseModule)
)]
public class Bitbone3dDomainTestModule : AbpModule
{

}
