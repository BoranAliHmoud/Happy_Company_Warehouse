using Happy_Company_Warehouse.DataAccess.Data;
using Happy_Company_Warehouse.DataAccess.IRepository;
using Happy_Company_Warehouse.DataAccess.Services;
using Happy_Company_Warehouse.Middleware;
using Happy_Company_Warehouse.Model;
using Happy_Company_Warehouse.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using THappy_Company_Warehouse.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);
 
//Dependency injection Info:
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// End


// Get Data AppSettings  Info:
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
AppSettings appSettings = new();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);
TenantSettings options = appSettings.TenantSettings;
JWT jwtSetting = appSettings.JWT;
// End


//Configuraion and Tenant Data  Info:
var defaultDbProvider = options.Defaults.DBProvider;
if (defaultDbProvider.ToLower() == "mssql")
{
    builder.Services.AddDbContext<ApplicationDbContext>(m => m.UseSqlite());
}
foreach (var tenant in options.Tenants)
{
    var connectionString = tenant.ConnectionString ?? options.Defaults.ConnectionString;

    using var scope = builder.Services.BuildServiceProvider().CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    dbContext.Database.SetConnectionString(connectionString);

    if (dbContext.Database.GetPendingMigrations().Any())
    {
        dbContext.Database.Migrate();
    }
}
//End


// JWT Info :
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
               .AddJwtBearer(o =>
               {
                   o.RequireHttpsMetadata = false;
                   o.SaveToken = false;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidIssuer = jwtSetting.Issuer,
                       ValidAudience = jwtSetting.Audience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key))
                   };
               });
//End


// General Info 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var AllowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<List<string>>()!;
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
//End

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.UseTenancyMiddleware();
app.MapControllers();

app.Run();
