using System.Threading.Tasks;

namespace Ebda3.CRM.Data;

public interface ICRMDbSchemaMigrator
{
    Task MigrateAsync();
}
