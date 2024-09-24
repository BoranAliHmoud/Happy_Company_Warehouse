using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using ILogger = Serilog.ILogger;



namespace Happy_Company_Warehouse
{
    public static class LogsServices
    {
        private static readonly ILogger _logger;

        static LogsServices()
        {

            _logger = Log.Logger;
        } 
       
        public static void LogError(Exception e,string message = "Catch Error")
        {
            _logger.Information("----------- Start Error -------------------");
            _logger.Error(e, message);
            _logger.Information("------------- End Error -----------------");
        }
         
    }
}
