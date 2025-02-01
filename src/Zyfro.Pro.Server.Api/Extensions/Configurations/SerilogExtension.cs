using Serilog;
using Serilog.Sinks.PostgreSQL;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class SerilogExtension
    {
        public static void AddSerilogConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Logs");

            var columnWriters = new Dictionary<string, ColumnWriterBase>
            {
                { "Timestamp", new TimestampColumnWriter() },
                { "Level", new LevelColumnWriter() },
                { "Message", new RenderedMessageColumnWriter() },
                { "Exception", new ExceptionColumnWriter() },
                { "Properties", new LogEventSerializedColumnWriter() },
                { "MachineName", new SinglePropertyColumnWriter("MachineName") },
                { "ThreadId", new SinglePropertyColumnWriter("ThreadId") }
            };

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .WriteTo.PostgreSQL(
                    connectionString,
                    tableName: "ErrorLogs",
                    columnOptions: columnWriters,
                    needAutoCreateTable: true
                )
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}
