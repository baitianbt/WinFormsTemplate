using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace YourSolution.WinForm.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userManagementForm = Program.ServiceProvider.GetRequiredService<UserManagementForm>();
            userManagementForm.MdiParent = this;
            userManagementForm.Show();
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logViewerForm = new LogViewerForm();
            logViewerForm.MdiParent = this;
            logViewerForm.Show();
        }
    }
} 