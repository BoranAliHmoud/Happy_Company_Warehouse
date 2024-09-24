using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace Happy_Company_Warehouse.Middleware
{
    public class TenancyMiddleware
    {
        private readonly RequestDelegate _next;

        public TenancyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    // الوصول إلى بيانات الـ JWT من Claims
                    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var username = context.User.Identity.Name;
                    var roles = context.User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
                    var tenantId = context.User.FindFirst("TenantId")?.Value;

                    // يمكنك إضافة بيانات إضافية إلى الـ HttpContext أو القيام بعمليات أخرى
                    context.Items["UserId"] = userId;
                    context.Items["Username"] = username;
                    context.Items["Roles"] = roles;
                    context.Items.Add("accessToken", tenantId);
                    

                }
                else if (context.Request.Method == "POST")
                {
                    context.Request.EnableBuffering();
                    var stream = context.Request.Body;

                    using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true))
                    {
                       var requestBody = await reader.ReadToEndAsync();
                     var requestData = JsonConvert.DeserializeObject<TenancyData>(requestBody);
                        if (requestBody == null)
                        {
                            //result.SetResult(false, "Looks up a localized string similar to Invalid Access Token.");
                            //LogsServices.LogError($"IDM | CAA |  request Body is error    ");
                            context.Response.StatusCode = 401;
                            return;
                        }

                        context.Request.Body.Position = 0;
                        context.Items.Add("accessToken", requestData.tenantId);
                    }
                
                    

                }

                // الانتقال إلى Middleware التالي في السلسلة
                await _next(context);
            }
            catch (Exception ex)
            {
              //  LogsServices.LogError($"IDM | CAA |General Server Error :{ex.Message}");
                throw;
            }
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TenancyMiddlewareExtensions
    {
        public static IApplicationBuilder UseTenancyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenancyMiddleware>();
        }
    }
    public class TenancyData 
    {
        public string tenantId { get; set; }
    }


}
