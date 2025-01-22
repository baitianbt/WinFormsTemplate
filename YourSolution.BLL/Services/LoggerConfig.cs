using Serilog;
using Serilog.Events;
using System.IO;

namespace YourSolution.BLL.Services
{
    public static class LoggerConfig
    {
        public static ILogger CreateLogger()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string logPath = Path.Combine(baseDir, "Logs");
            string dbPath = Path.Combine(logPath, "logs.db");

            // 确保目录存在
            Directory.CreateDirectory(logPath);

            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(logPath, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.SQLite(
                    dbPath,
                    tableName: "Logs",
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .Enrich.FromLogContext()
                .CreateLogger();
        }
    }
} 