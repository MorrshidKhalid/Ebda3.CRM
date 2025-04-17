using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ebda3.CRM.Data;

/* This is used if database provider does't define
 * ICRMDbSchemaMigrator implementation.
 */
public class NullCRMDbSchemaMigrator : ICRMDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
