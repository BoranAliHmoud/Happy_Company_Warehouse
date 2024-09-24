using Happy_Company_Warehouse.DataAccess.Settings;
using Happy_Company_Warehouse.Model;

namespace Happy_Company_Warehouse.DataAccess.Services;

public interface ITenantService
{
    string? GetDatabaseProvider();
    string? GetConnectionString();
    Tenant? GetCurrentTenant();
}