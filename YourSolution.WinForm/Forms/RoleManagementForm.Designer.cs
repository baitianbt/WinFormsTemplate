namespace YourSolution.WinForm.Forms
{
    partial class RoleManagementForm
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
            splitContainer = new SplitContainer();
            // 左侧角色列表面板
            panelRoles = new Panel();
            dgvRoles = new DataGridView();
            panelRoleActions = new Panel();
            btnAddRole = new Button();
            btnEditRole = new Button();
            btnDeleteRole = new Button();
            // 右侧权限设置面板
            panelPermissions = new Panel();
            treePermissions = new TreeView();
            panelPermissionActions = new Panel();
            btnSavePermissions = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            panelRoleActions.SuspendLayout();
            panelPermissions.SuspendLayout();
            panelPermissionActions.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Width = 800;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelRoles);
            splitContainer.Panel1MinSize = 300;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelPermissions);
            splitContainer.Panel2MinSize = 300;
            // 
            // panelRoles
            // 
            panelRoles.Controls.Add(dgvRoles);
            panelRoles.Controls.Add(panelRoleActions);
            panelRoles.Dock = DockStyle.Fill;
            panelRoles.Padding = new Padding(10);
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.Dock = DockStyle.Fill;
            dgvRoles.MultiSelect = false;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.SelectionChanged += dgvRoles_SelectionChanged;
            // 
            // panelRoleActions
            // 
            panelRoleActions.Controls.Add(btnAddRole);
            panelRoleActions.Controls.Add(btnEditRole);
            panelRoleActions.Controls.Add(btnDeleteRole);
            panelRoleActions.Dock = DockStyle.Bottom;
            panelRoleActions.Height = 50;
            panelRoleActions.Padding = new Padding(0, 10, 0, 0);
            // 
            // btnAddRole
            // 
            btnAddRole.Text = "Add Role";
            btnAddRole.Width = 100;
            btnAddRole.Click += btnAddRole_Click;
            // 
            // btnEditRole
            // 
            btnEditRole.Text = "Edit Role";
            btnEditRole.Width = 100;
            btnEditRole.Left = 110;
            btnEditRole.Click += btnEditRole_Click;
            // 
            // btnDeleteRole
            // 
            btnDeleteRole.Text = "Delete Role";
            btnDeleteRole.Width = 100;
            btnDeleteRole.Left = 220;
            btnDeleteRole.Click += btnDeleteRole_Click;
            // 
            // panelPermissions
            // 
            panelPermissions.Controls.Add(treePermissions);
            panelPermissions.Controls.Add(panelPermissionActions);
            panelPermissions.Dock = DockStyle.Fill;
            panelPermissions.Padding = new Padding(10);
            // 
            // treePermissions
            // 
            treePermissions.CheckBoxes = true;
            treePermissions.Dock = DockStyle.Fill;
            treePermissions.ShowLines = true;
            // 
            // panelPermissionActions
            // 
            panelPermissionActions.Controls.Add(btnSavePermissions);
            panelPermissionActions.Dock = DockStyle.Bottom;
            panelPermissionActions.Height = 50;
            panelPermissionActions.Padding = new Padding(0, 10, 0, 0);
            // 
            // btnSavePermissions
            // 
            btnSavePermissions.Text = "Save Permissions";
            btnSavePermissions.Width = 120;
            btnSavePermissions.Click += btnSavePermissions_Click;
            // 
            // RoleManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer);
            Name = "RoleManagementForm";
            Text = "Role Management";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            panelRoleActions.ResumeLayout(false);
            panelPermissions.ResumeLayout(false);
            panelPermissionActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        private SplitContainer splitContainer;
        private Panel panelRoles;
        private DataGridView dgvRoles;
        private Panel panelRoleActions;
        private Button btnAddRole;
        private Button btnEditRole;
        private Button btnDeleteRole;
        private Panel panelPermissions;
        private TreeView treePermissions;
        private Panel panelPermissionActions;
        private Button btnSavePermissions;
    }
} 