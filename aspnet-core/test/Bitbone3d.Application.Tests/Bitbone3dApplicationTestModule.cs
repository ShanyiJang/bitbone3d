using Volo.Abp.Modularity;

namespace Bitbone3d;

[DependsOn(
    typeof(Bitbone3dApplicationModule),
    typeof(Bitbone3dDomainTestModule)
)]
public class Bitbone3dApplicationTestModule : AbpModule
{

}
