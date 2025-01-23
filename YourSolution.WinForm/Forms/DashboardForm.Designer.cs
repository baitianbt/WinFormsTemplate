namespace YourSolution.WinForm.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            panelUserStats = new Panel();
            panelLogStats = new Panel();
            panelActiveUsers = new Panel();
            panelTodayLogs = new Panel();
            lblUserCount = new Label();
            lblUserCountTitle = new Label();
            lblLogCount = new Label();
            lblLogCountTitle = new Label();
            lblActiveUsers = new Label();
            lblActiveUsersTitle = new Label();
            lblTodayLogs = new Label();
            lblTodayLogsTitle = new Label();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Controls.Add(panelUserStats, 0, 0);
            tableLayoutPanel.Controls.Add(panelLogStats, 1, 0);
            tableLayoutPanel.Controls.Add(panelActiveUsers, 2, 0);
            tableLayoutPanel.Controls.Add(panelTodayLogs, 3, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(1978, 589);
            tableLayoutPanel.TabIndex = 0;
            // 
            // panelUserStats
            // 
            panelUserStats.Location = new Point(3, 3);
            panelUserStats.Name = "panelUserStats";
            panelUserStats.Size = new Size(200, 100);
            panelUserStats.TabIndex = 0;
            // 
            // panelLogStats
            // 
            panelLogStats.Location = new Point(497, 3);
            panelLogStats.Name = "panelLogStats";
            panelLogStats.Size = new Size(200, 100);
            panelLogStats.TabIndex = 1;
            // 
            // panelActiveUsers
            // 
            panelActiveUsers.Location = new Point(991, 3);
            panelActiveUsers.Name = "panelActiveUsers";
            panelActiveUsers.Size = new Size(200, 100);
            panelActiveUsers.TabIndex = 2;
            // 
            // panelTodayLogs
            // 
            panelTodayLogs.Location = new Point(1485, 3);
            panelTodayLogs.Name = "panelTodayLogs";
            panelTodayLogs.Size = new Size(200, 100);
            panelTodayLogs.TabIndex = 3;
            // 
            // lblUserCount
            // 
            lblUserCount.Location = new Point(0, 0);
            lblUserCount.Name = "lblUserCount";
            lblUserCount.Size = new Size(100, 23);
            lblUserCount.TabIndex = 0;
            // 
            // lblUserCountTitle
            // 
            lblUserCountTitle.Location = new Point(0, 0);
            lblUserCountTitle.Name = "lblUserCountTitle";
            lblUserCountTitle.Size = new Size(100, 23);
            lblUserCountTitle.TabIndex = 0;
            // 
            // lblLogCount
            // 
            lblLogCount.Location = new Point(0, 0);
            lblLogCount.Name = "lblLogCount";
            lblLogCount.Size = new Size(100, 23);
            lblLogCount.TabIndex = 0;
            // 
            // lblLogCountTitle
            // 
            lblLogCountTitle.Location = new Point(0, 0);
            lblLogCountTitle.Name = "lblLogCountTitle";
            lblLogCountTitle.Size = new Size(100, 23);
            lblLogCountTitle.TabIndex = 0;
            // 
            // lblActiveUsers
            // 
            lblActiveUsers.Location = new Point(0, 0);
            lblActiveUsers.Name = "lblActiveUsers";
            lblActiveUsers.Size = new Size(100, 23);
            lblActiveUsers.TabIndex = 0;
            // 
            // lblActiveUsersTitle
            // 
            lblActiveUsersTitle.Location = new Point(0, 0);
            lblActiveUsersTitle.Name = "lblActiveUsersTitle";
            lblActiveUsersTitle.Size = new Size(100, 23);
            lblActiveUsersTitle.TabIndex = 0;
            // 
            // lblTodayLogs
            // 
            lblTodayLogs.Location = new Point(0, 0);
            lblTodayLogs.Name = "lblTodayLogs";
            lblTodayLogs.Size = new Size(100, 23);
            lblTodayLogs.TabIndex = 0;
            // 
            // lblTodayLogsTitle
            // 
            lblTodayLogsTitle.Location = new Point(0, 0);
            lblTodayLogsTitle.Name = "lblTodayLogsTitle";
            lblTodayLogsTitle.Size = new Size(100, 23);
            lblTodayLogsTitle.TabIndex = 0;
            // 
            // DashboardForm
            // 
            ClientSize = new Size(1978, 589);
            Controls.Add(tableLayoutPanel);
            Name = "DashboardForm";
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigureStatsPanel(Panel panel, Label countLabel, Label titleLabel, string title, Color color)
        {
            panel.BackColor = color;
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(10);
            panel.Padding = new Padding(10);

            countLabel.Dock = DockStyle.Top;
            countLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            countLabel.ForeColor = Color.White;
            countLabel.TextAlign = ContentAlignment.MiddleCenter;
            countLabel.Height = 50;

            titleLabel.Dock = DockStyle.Bottom;
            titleLabel.Font = new Font("Segoe UI", 12F);
            titleLabel.ForeColor = Color.White;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Text = title;
            titleLabel.Height = 30;

            panel.Controls.Add(countLabel);
            panel.Controls.Add(titleLabel);
        }

        private void ConfigureLogTrendChart()
        {
            chartLogTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartLogTrend.Dock = DockStyle.Fill;
            chartLogTrend.Margin = new Padding(10);
            tableLayoutPanel.SetColumnSpan(chartLogTrend, 2);

            var chartArea = chartLogTrend.ChartAreas.Add("Default");
            chartArea.AxisX.Title = "Date";
            chartArea.AxisY.Title = "Log Count";

            var series = chartLogTrend.Series.Add("Logs");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chartLogTrend.Titles.Add("Log Trend (Last 7 Days)");
        }

        private void ConfigureLogTypesChart()
        {
            chartLogTypes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartLogTypes.Dock = DockStyle.Fill;
            chartLogTypes.Margin = new Padding(10);
            tableLayoutPanel.SetColumnSpan(chartLogTypes, 2);

            var chartArea = chartLogTypes.ChartAreas.Add("Default");
            chartArea.Area3DStyle.Enable3D = true;

            var series = chartLogTypes.Series.Add("LogTypes");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            chartLogTypes.Titles.Add("Log Distribution by Level");
        }

        private TableLayoutPanel tableLayoutPanel;
        private Panel panelUserStats;
        private Label lblUserCount;
        private Label lblUserCountTitle;
        private Panel panelLogStats;
        private Label lblLogCount;
        private Label lblLogCountTitle;
        private Panel panelActiveUsers;
        private Label lblActiveUsers;
        private Label lblActiveUsersTitle;
        private Panel panelTodayLogs;
        private Label lblTodayLogs;
        private Label lblTodayLogsTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLogTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLogTypes;
    }
} 