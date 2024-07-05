using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bitbone3d.Data;
using Volo.Abp.DependencyInjection;

namespace Bitbone3d.EntityFrameworkCore;

public class EntityFrameworkCoreBitbone3dDbSchemaMigrator
    : IBitbone3dDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBitbone3dDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the Bitbone3dDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Bitbone3dDbContext>()
            .Database
            .MigrateAsync();
    }
}
