using Bitbone3d.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Bitbone3d.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Bitbone3dEntityFrameworkCoreModule),
    typeof(Bitbone3dApplicationContractsModule)
    )]
public class Bitbone3dDbMigratorModule : AbpModule
{
}
