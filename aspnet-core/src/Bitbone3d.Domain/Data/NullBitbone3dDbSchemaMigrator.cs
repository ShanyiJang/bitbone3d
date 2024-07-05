using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Bitbone3d.Data;

/* This is used if database provider does't define
 * IBitbone3dDbSchemaMigrator implementation.
 */
public class NullBitbone3dDbSchemaMigrator : IBitbone3dDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
