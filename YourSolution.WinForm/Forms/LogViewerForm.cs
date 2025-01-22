using System;
using System.IO;
using System.Windows.Forms;

namespace YourSolution.WinForm.Forms
{
    public partial class LogViewerForm : Form
    {
        private string _logBasePath;
        private string _currentLogFile;

        public LogViewerForm()
        {
            InitializeComponent();
            _logBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
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

                _currentLogFile = Path.Combine(logPath, $"{DateTime.Now:yyyy-MM-dd}.log");

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
    }
} 