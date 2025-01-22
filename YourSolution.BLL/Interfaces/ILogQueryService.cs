namespace YourSolution.BLL.Interfaces
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }

    public interface ILogQueryService
    {
        IEnumerable<LogEntry> QueryLogs(
            DateTime? startDate = null,
            DateTime? endDate = null,
            string level = null,
            string searchText = null);
    }
} 