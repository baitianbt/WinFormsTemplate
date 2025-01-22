using System;
using System.Drawing;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            // 系统管理
            var systemNode = treeViewMenu.Nodes.Add("系统管理");
            systemNode.Tag = "SYSTEM";
            systemNode.Nodes.Add("用户管理").Tag = "USER_MANAGEMENT";
            systemNode.Nodes.Add("日志查看").Tag = "LOG_VIEWER";
            
            // 展开所有节点
            treeViewMenu.ExpandAll();
        }

        private void treeViewMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;

            Form form = null;
            switch (e.Node.Tag.ToString())
            {
                case "USER_MANAGEMENT":
                    form = Program.ServiceProvider.GetRequiredService<UserManagementForm>();
                    break;
                case "LOG_VIEWER":
                    form = Program.ServiceProvider.GetRequiredService<LogViewerForm>();
                    break;
            }

            if (form != null)
            {
                // 清除主面板中的所有控件
                panelMain.Controls.Clear();

                // 设置子窗体属性
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;

                // 将子窗体添加到主面板并显示
                panelMain.Controls.Add(form);
                form.Show();

                // 更新状态栏
                labelStatus.Text = $"当前位置：{e.Node.Parent.Text} > {e.Node.Text}";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("确定要退出系统吗？", "确认", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }
    }
} 