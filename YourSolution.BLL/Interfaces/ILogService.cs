using System;

namespace YourSolution.BLL.Interfaces
{
    public interface ILogService
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogError(Exception ex, string message = null);
        void LogDebug(string message);
    }
} 