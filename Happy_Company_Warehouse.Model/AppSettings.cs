using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Company_Warehouse.Model
{
    public class AppSettings
    {
        public TenantSettings TenantSettings { get; set; }
        public JWT JWT { get; set; }
    }

    public class TenantSettings
    {
        public Configuration Defaults { get; set; } = default!;
        public List<Tenant> Tenants { get; set; } = new();
    }
    public class Configuration
    {
        public string DBProvider { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
    }
    public class Tenant
    {
        public string Name { get; set; } = null!;
        public string TId { get; set; } = null!;
        public string? ConnectionString { get; set; }
    }
    public static class AppSettingsProvider
    {
        public static AppSettings Instance { get; private set; }

        
    }
    public class JWT
    {
        public string Key { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int DurationInDays { get; set; } 
    }
}
