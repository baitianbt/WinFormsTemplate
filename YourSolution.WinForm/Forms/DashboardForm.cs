using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YourSolution.BLL.Interfaces;

namespace YourSolution.WinForm.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly IUserService _userService;
        private readonly ILogQueryService _logQueryService;
        private System.Windows.Forms.Timer _refreshTimer;

        public DashboardForm(IUserService userService, ILogQueryService logQueryService)
        {
            InitializeComponent();
            _userService = userService;
            _logQueryService = logQueryService;

            // 设置定时刷新
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 30000; // 30秒刷新一次
            _refreshTimer.Tick += (s, e) => RefreshData();

            this.Load += DashboardForm_Load;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            ConfigureLogTrendChart();
            ConfigureLogTypesChart();


            RefreshData();
            _refreshTimer.Start();
        }

        private void RefreshData()
        {
            try
            {
                // 更新统计数据
                UpdateStatistics();

                // 更新图表
                UpdateLogTrendChart();
                UpdateLogTypesChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            // 用户统计
            var users = _userService.GetAll().ToList();
            lblUserCount.Text = users.Count.ToString();
            lblActiveUsers.Text = users.Count(u => u.IsActive).ToString();

            // 日志统计
            var today = DateTime.Today;
            var logs = _logQueryService.QueryLogs(
                startDate: today,
                endDate: today.AddDays(1).AddSeconds(-1));
            
            lblTodayLogs.Text = logs.Count().ToString();

            var allLogs = _logQueryService.QueryLogs();
            lblLogCount.Text = allLogs.Count().ToString();
        }

        private void UpdateLogTrendChart()
        {
            var series = chartLogTrend.Series["Logs"];
            series.Points.Clear();

            // 获取最近7天的日志统计
            for (int i = 6; i >= 0; i--)
            {
                var date = DateTime.Today.AddDays(-i);
                var logs = _logQueryService.QueryLogs(
                    startDate: date,
                    endDate: date.AddDays(1).AddSeconds(-1));
                
                series.Points.AddXY(date.ToString("MM/dd"), logs.Count());
            }
        }

        private void UpdateLogTypesChart()
        {
            var series = chartLogTypes.Series["LogTypes"];
            series.Points.Clear();

            // 获取不同级别的日志统计
            var logs = _logQueryService.QueryLogs(
                startDate: DateTime.Today.AddDays(-30)); // 最近30天的数据

            var logGroups = logs.GroupBy(l => l.Level)
                              .Select(g => new { Level = g.Key, Count = g.Count() });

            foreach (var group in logGroups)
            {
                var pointIndex = series.Points.AddXY(group.Level, group.Count);
                var point = series.Points[pointIndex];
                point.Label = $"{group.Level}: {group.Count}";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _refreshTimer.Stop();
            base.OnFormClosing(e);
        }
    }
} 