using Volo.Abp.Modularity;

namespace Bitbone3d;

/* Inherit from this class for your domain layer tests. */
public abstract class Bitbone3dDomainTestBase<TStartupModule> : Bitbone3dTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
