namespace YourSolution.WinForm.Forms
{
    partial class LogViewerForm
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
            this.rtbLogContent = new System.Windows.Forms.RichTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tscboLogType = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.dtpStartDate = new DateTimePicker();
            this.dtpEndDate = new DateTimePicker();
            this.cboLogLevel = new ComboBox();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();

            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tscboLogType,
                this.tsbtnRefresh,
                this.tsbtnClear,
                new ToolStripControlHost(dtpStartDate),
                new ToolStripControlHost(dtpEndDate),
                new ToolStripControlHost(cboLogLevel),
                new ToolStripControlHost(txtSearch),
                new ToolStripControlHost(btnSearch)});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 0;

            // 
            // tscboLogType
            // 
            this.tscboLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscboLogType.Name = "tscboLogType";
            this.tscboLogType.Size = new System.Drawing.Size(121, 25);
            this.tscboLogType.Items.AddRange(new object[] { "General Log", "Error Log" });
            this.tscboLogType.SelectedIndexChanged += new System.EventHandler(this.tscboLogType_SelectedIndexChanged);

            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Image = System.Drawing.SystemIcons.Information.ToBitmap();
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);

            // 
            // tsbtnClear
            // 
            this.tsbtnClear.Image = System.Drawing.SystemIcons.Warning.ToBitmap();
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(54, 22);
            this.tsbtnClear.Text = "Clear";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);

            // 
            // rtbLogContent
            // 
            this.rtbLogContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogContent.Location = new System.Drawing.Point(0, 25);
            this.rtbLogContent.Name = "rtbLogContent";
            this.rtbLogContent.ReadOnly = true;
            this.rtbLogContent.Size = new System.Drawing.Size(800, 425);
            this.rtbLogContent.TabIndex = 1;
            this.rtbLogContent.WordWrap = false;
            this.rtbLogContent.Font = new System.Drawing.Font("Consolas", 9F);

            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new Point(10, 3);
            this.dtpStartDate.Size = new Size(100, 23);

            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new Point(120, 3);
            this.dtpEndDate.Size = new Size(100, 23);

            // 
            // cboLogLevel
            // 
            this.cboLogLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLogLevel.Items.AddRange(new object[] { "All", "Information", "Warning", "Error" });
            this.cboLogLevel.Location = new Point(230, 3);
            this.cboLogLevel.Size = new Size(100, 23);
            this.cboLogLevel.SelectedIndex = 0;

            // 
            // txtSearch
            // 
            this.txtSearch.Location = new Point(340, 3);
            this.txtSearch.Size = new Size(150, 23);

            // 
            // btnSearch
            // 
            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new Point(500, 3);
            this.btnSearch.Size = new Size(70, 23);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);

            // 
            // LogViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbLogContent);
            this.Controls.Add(this.toolStrip);
            this.Name = "LogViewerForm";
            this.Text = "Log Viewer";
            this.Load += new System.EventHandler(this.LogViewerForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RichTextBox rtbLogContent;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox tscboLogType;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cboLogLevel;
        private TextBox txtSearch;
        private Button btnSearch;
    }
} 