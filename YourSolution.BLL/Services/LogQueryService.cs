using Microsoft.Data.Sqlite;
using YourSolution.BLL.Interfaces;
using System.Data;
using System.Text;

namespace YourSolution.BLL.Services
{
    public class LogQueryService : ILogQueryService
    {
        private readonly string _connectionString;

        public LogQueryService()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(baseDir, "Logs", "logs.db");
            _connectionString = $"Data Source={dbPath};Mode=ReadOnly;";
        }

        public IEnumerable<LogEntry> QueryLogs(
            DateTime? startDate = null,
            DateTime? endDate = null,
            string level = null,
            string searchText = null)
        {
            var logs = new List<LogEntry>();
            var query = new StringBuilder("SELECT Id, Timestamp, Level, RenderedMessage, Exception FROM Logs WHERE 1=1");
            var parameters = new List<SqliteParameter>();

            if (startDate.HasValue)
            {
                query.Append(" AND Timestamp >= @StartDate");
                parameters.Add(new SqliteParameter("@StartDate", startDate.Value.ToString("O")));
            }

            if (endDate.HasValue)
            {
                query.Append(" AND Timestamp <= @EndDate");
                parameters.Add(new SqliteParameter("@EndDate", endDate.Value.ToString("O")));
            }

            if (!string.IsNullOrEmpty(level))
            {
                query.Append(" AND Level = @Level");
                parameters.Add(new SqliteParameter("@Level", level));
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                query.Append(" AND (RenderedMessage LIKE @SearchText OR Exception LIKE @SearchText)");
                parameters.Add(new SqliteParameter("@SearchText", $"%{searchText}%"));
            }

            query.Append(" ORDER BY Timestamp DESC");

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(query.ToString(), connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new LogEntry
                            {
                                Id = reader.GetInt32(0),
                                Timestamp = DateTime.Parse(reader.GetString(1)),
                                Level = reader.GetString(2),
                                Message = reader.GetString(3),
                                Exception = reader.IsDBNull(4) ? null : reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return logs;
        }
    }
} 