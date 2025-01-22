namespace YourSolution.WinForm.Forms
{
    partial class MainForm
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
            panelHeader = new Panel();
            labelTitle = new Label();
            panelAside = new Panel();
            treeViewMenu = new TreeView();
            panelMain = new Panel();
            panelFooter = new Panel();
            labelStatus = new Label();
            panelHeader.SuspendLayout();
            panelAside.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(0, 122, 204);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 4, 4, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1437, 80);
            panelHeader.TabIndex = 2;
            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(1437, 80);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "System Management";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAside
            // 
            panelAside.BackColor = Color.FromArgb(45, 45, 48);
            panelAside.Controls.Add(treeViewMenu);
            panelAside.Dock = DockStyle.Left;
            panelAside.Location = new Point(0, 80);
            panelAside.Margin = new Padding(4, 4, 4, 4);
            panelAside.Name = "panelAside";
            panelAside.Size = new Size(257, 794);
            panelAside.TabIndex = 1;
            // 
            // treeViewMenu
            // 
            treeViewMenu.BackColor = Color.FromArgb(45, 45, 48);
            treeViewMenu.BorderStyle = BorderStyle.None;
            treeViewMenu.Dock = DockStyle.Fill;
            treeViewMenu.Font = new Font("Segoe UI", 10F);
            treeViewMenu.ForeColor = Color.White;
            treeViewMenu.Indent = 20;
            treeViewMenu.ItemHeight = 30;
            treeViewMenu.Location = new Point(0, 0);
            treeViewMenu.Margin = new Padding(4, 4, 4, 4);
            treeViewMenu.Name = "treeViewMenu";
            treeViewMenu.ShowLines = false;
            treeViewMenu.Size = new Size(257, 794);
            treeViewMenu.TabIndex = 0;
            treeViewMenu.AfterSelect += treeViewMenu_AfterSelect;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(257, 80);
            panelMain.Margin = new Padding(4, 4, 4, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1180, 794);
            panelMain.TabIndex = 0;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(45, 45, 48);
            panelFooter.Controls.Add(labelStatus);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 874);
            panelFooter.Margin = new Padding(4, 4, 4, 4);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1437, 40);
            panelFooter.TabIndex = 3;
            // 
            // labelStatus
            // 
            labelStatus.Dock = DockStyle.Fill;
            labelStatus.Font = new Font("Segoe UI", 9F);
            labelStatus.ForeColor = Color.White;
            labelStatus.Location = new Point(0, 0);
            labelStatus.Margin = new Padding(4, 0, 4, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Padding = new Padding(13, 0, 0, 0);
            labelStatus.Size = new Size(1437, 40);
            labelStatus.TabIndex = 0;
            labelStatus.Text = "Ready";
            labelStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1437, 914);
            Controls.Add(panelMain);
            Controls.Add(panelAside);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1023, 784);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "System Management";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            panelHeader.ResumeLayout(false);
            panelAside.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelAside;
        private System.Windows.Forms.TreeView treeViewMenu;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label labelStatus;
    }
} 