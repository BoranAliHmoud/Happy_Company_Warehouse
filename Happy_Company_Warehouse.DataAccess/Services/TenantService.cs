using Happy_Company_Warehouse.DataAccess.Settings;
using Happy_Company_Warehouse.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Happy_Company_Warehouse.DataAccess.Services;

public class TenantService : ITenantService
{
  
    private HttpContext? _httpContext;
    private Tenant? _currentTenant;
    private AppSettings? _appSettings;

    public TenantService(IHttpContextAccessor contextAccessor,   IOptions<AppSettings> appSettings)
    {
        try {
        _httpContext = contextAccessor.HttpContext;
     
        _appSettings = appSettings.Value;
        
        if(_httpContext is not null)
        {
            if (_httpContext.Items.ContainsKey("accessToken"))
            {
                var tenantId = _httpContext.Items["accessToken"]!.ToString();
                SetCurrentTenant(tenantId!);
            }
            else
            {
              
                throw new Exception("No tenant provided!");
            }

            }
        }
        catch (Exception e)
        {
            LogsServices.LogError(e, "Catch Error:"); 
             

        }

    }

    public string? GetConnectionString()
    {
        var currentConnectionString = _currentTenant is null 
            ? _appSettings.TenantSettings.Defaults.ConnectionString
            : _currentTenant.ConnectionString;

        return currentConnectionString;
    }

    public Tenant? GetCurrentTenant()
    {
        return _currentTenant;
    }

    public string? GetDatabaseProvider()
    {
        return _appSettings.TenantSettings.Defaults.DBProvider;
    }

    private void SetCurrentTenant(string tenantId)
    {
        try
        {
            _currentTenant = _appSettings.TenantSettings.Tenants.FirstOrDefault(t => t.TId == tenantId);

            if (_currentTenant is null)
            {

                throw new Exception("Invalid tenant ID");
            }

            if (string.IsNullOrEmpty(_currentTenant.ConnectionString))
            {
                _currentTenant.ConnectionString = _appSettings.TenantSettings.Defaults.ConnectionString;
            }
        }
        catch (Exception e)
        {
            LogsServices.LogError(e, "Catch Error:"); 
 
        }
    }
}