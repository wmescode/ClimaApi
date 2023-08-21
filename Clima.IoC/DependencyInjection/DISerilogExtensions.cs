using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima.IoC.DependencyInjection
{
    public static class DISerilogExtensions
    {
        public static void AddSerilog(string applicationName, string connectionString)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Warning()
               .Enrich.WithProperty("Application", "ClimaApi")
               .Enrich.FromLogContext()
               .WriteTo.Console()
               .WriteTo.MSSqlServer(
                       connectionString: connectionString,
                       sinkOptions: new MSSqlServerSinkOptions { TableName = "LogError", AutoCreateSqlTable = true },
                       restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
                       columnOptions: new ColumnOptions
                       {
                           AdditionalColumns = new Collection<SqlColumn>
                           {
                                new SqlColumn
                                    {ColumnName = "Application", PropertyName = "Application", DataType = SqlDbType.NVarChar, DataLength = 64},
                           }
                       })
               .CreateLogger();
        }
    }
}
