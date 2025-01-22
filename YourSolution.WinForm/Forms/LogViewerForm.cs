using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YourSolution.BLL.Interfaces;

namespace YourSolution.WinForm.Forms
{
    public partial class LogViewerForm : Form
    {
        private readonly ILogQueryService _logQueryService;
        private string _logBasePath;
        private string _currentLogFile;

        public LogViewerForm(ILogQueryService logQueryService)
        {
            InitializeComponent();
            _logQueryService = logQueryService;
            _logBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            
            // 设置日期选择器的初始值
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
        }

        private void LogViewerForm_Load(object sender, EventArgs e)
        {
            tscboLogType.SelectedIndex = 0;
            LoadLogContent();
        }

        private void tscboLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLogContent();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogContent();
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the log file?", "Confirm Clear",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(_currentLogFile))
                    {
                        File.WriteAllText(_currentLogFile, string.Empty);
                        rtbLogContent.Clear();
                        MessageBox.Show("Log file cleared successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing log file: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadLogContent()
        {
            try
            {
                string logPath = _logBasePath;
                if (tscboLogType.SelectedIndex == 1) // Error Log
                {
                    logPath = Path.Combine(logPath, "Error");
                }

                _currentLogFile = Path.Combine(logPath, $"log-{DateTime.Now:yyyyMMdd}.txt");

                if (!File.Exists(_currentLogFile))
                {
                    rtbLogContent.Text = "No log file found for today.";
                    return;
                }

                using (var stream = new FileStream(_currentLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(stream))
                {
                    rtbLogContent.Text = reader.ReadToEnd();
                }

                // 滚动到底部
                rtbLogContent.SelectionStart = rtbLogContent.Text.Length;
                rtbLogContent.ScrollToCaret();

                // 高亮显示错误和警告
                HighlightText("ERROR", Color.Red);
                HighlightText("WARN", Color.Orange);
                HighlightText("INFO", Color.Green);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading log file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightText(string searchText, Color color)
        {
            int start = 0;
            while (start < rtbLogContent.TextLength)
            {
                int index = rtbLogContent.Text.IndexOf(searchText, start, StringComparison.OrdinalIgnoreCase);
                if (index == -1)
                    break;

                rtbLogContent.SelectionStart = index;
                rtbLogContent.SelectionLength = searchText.Length;
                rtbLogContent.SelectionColor = color;
                start = index + searchText.Length;
            }
            rtbLogContent.SelectionStart = rtbLogContent.TextLength;
            rtbLogContent.SelectionLength = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var logs = _logQueryService.QueryLogs(
                    startDate: dtpStartDate.Value,
                    endDate: dtpEndDate.Value,
                    level: cboLogLevel.SelectedIndex == 0 ? null : cboLogLevel.Text,
                    searchText: string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text
                );

                DisplayLogs(logs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error querying logs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayLogs(IEnumerable<LogEntry> logs)
        {
            rtbLogContent.Clear();
            foreach (var log in logs)
            {
                rtbLogContent.SelectionStart = rtbLogContent.TextLength;
                rtbLogContent.SelectionLength = 0;

                // 添加时间戳
                rtbLogContent.SelectionColor = Color.Black;
                rtbLogContent.AppendText($"{log.Timestamp:yyyy-MM-dd HH:mm:ss} ");

                // 添加日志级别（带颜色）
                Color levelColor = log.Level switch
                {
                    "ERROR" => Color.Red,
                    "WARNING" => Color.Orange,
                    "INFORMATION" => Color.Green,
                    _ => Color.Black
                };
                rtbLogContent.SelectionColor = levelColor;
                rtbLogContent.AppendText($"[{log.Level}] ");

                // 添加消息
                rtbLogContent.SelectionColor = Color.Black;
                rtbLogContent.AppendText($"{log.Message}\n");

                // 如果有异常，添加异常信息
                if (!string.IsNullOrEmpty(log.Exception))
                {
                    rtbLogContent.SelectionColor = Color.Red;
                    rtbLogContent.AppendText($"{log.Exception}\n");
                }
            }

            rtbLogContent.SelectionStart = 0;
            rtbLogContent.ScrollToCaret();
        }
    }
} 