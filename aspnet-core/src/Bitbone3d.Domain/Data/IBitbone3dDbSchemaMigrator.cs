using System.Threading.Tasks;

namespace Bitbone3d.Data;

public interface IBitbone3dDbSchemaMigrator
{
    Task MigrateAsync();
}
