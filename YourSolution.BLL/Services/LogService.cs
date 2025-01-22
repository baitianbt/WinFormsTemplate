using Serilog;
using YourSolution.BLL.Interfaces;

namespace YourSolution.BLL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogger _logger;

        public LogService()
        {
            _logger = LoggerConfig.CreateLogger();
        }

        public void LogInfo(string message)
        {
            _logger.Information(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(Exception ex, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                _logger.Error(ex, "An error occurred");
            else
                _logger.Error(ex, message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }
    }
} 