using Happy_Company_Warehouse.DataAccess.Services;
using Happy_Company_Warehouse.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Company_Warehouse.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {

        public string TenantId { get; set; }
        public string ConnectionString { get; set; }
        private readonly ITenantService _tenantService;
        private AppSettings? _appSettings;

        public ApplicationDbContext(DbContextOptions options, ITenantService tenantService,IOptions<AppSettings> appSettings) : base(options)
        {
            _tenantService = tenantService;
            TenantId = _tenantService.GetCurrentTenant()?.TId;
            ConnectionString = _tenantService.GetCurrentTenant()?.ConnectionString;
            _appSettings = appSettings.Value;
        }

        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<Item> Items => Set<Item>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var connString = ConnectionString ?? _appSettings.TenantSettings.Defaults.ConnectionString;
            optionsBuilder.UseSqlite(connString);

            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
            .HasIndex(account => account.Email)
            .IsUnique();
            var adminRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }, 
                new IdentityRole
                { 
                    Name = "Management",
                    NormalizedName = "Management".ToUpper()
                },  
                new IdentityRole
                { 
                    Name = "Auditor",
                    NormalizedName = "Auditor".ToUpper()
                }
            );

           
            var adminUserId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminUserId,
                    UserName = "Admin",
                    NormalizedUserName = "Admin".ToUpper(),
                    Email = "admin@happywarehouse.com",
                    NormalizedEmail = "admin@happywarehouse.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),  
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FullName="Admin",
                    TenantId= "Admin".ToUpper(),
                    Role= "Admin"  
                }
            );

          
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                }
            );

            //modelBuilder.Entity<ApplicationUser>().HasQueryFilter(e => e.TenantId == TenantId && e.Role != "Admin");
            base.OnModelCreating(modelBuilder);
        }


    }
}
