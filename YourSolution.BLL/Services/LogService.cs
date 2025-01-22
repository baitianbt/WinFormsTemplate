using NLog;
using YourSolution.BLL.Interfaces;

namespace YourSolution.BLL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogger _logger;

        public LogService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(Exception ex, string message = null)
        {
            if (string.IsNullOrEmpty(message))
                _logger.Error(ex);
            else
                _logger.Error(ex, message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }
    }
} 