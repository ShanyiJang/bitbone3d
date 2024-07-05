using Volo.Abp.Modularity;

namespace Bitbone3d;

public abstract class Bitbone3dApplicationTestBase<TStartupModule> : Bitbone3dTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
