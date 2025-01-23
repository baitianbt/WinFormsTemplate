using System;
using System.Linq;
using System.Windows.Forms;
using YourSolution.BLL.Interfaces;
using YourSolution.Model;

namespace YourSolution.WinForm.Forms
{
    public partial class RoleManagementForm : Form
    {
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        private int? _selectedRoleId;

        public RoleManagementForm(IRoleService roleService, IPermissionService permissionService)
        {
            InitializeComponent();
            _roleService = roleService;
            _permissionService = permissionService;

            LoadRoles();
            InitializePermissionTree();
        }

        private void LoadRoles()
        {
            try
            {
                var roles = _roleService.GetAll();
                dgvRoles.DataSource = roles.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePermissionTree()
        {
            try
            {
                treePermissions.Nodes.Clear();
                var permissions = _permissionService.GetAll();
                var modules = permissions.Select(p => p.Module).Distinct();

                foreach (var module in modules)
                {
                    var moduleNode = treePermissions.Nodes.Add(module);
                    var modulePermissions = permissions.Where(p => p.Module == module);
                    foreach (var permission in modulePermissions)
                    {
                        var node = moduleNode.Nodes.Add(permission.Name);
                        node.Tag = permission;
                    }
                }

                treePermissions.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading permissions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                var role = (Role)dgvRoles.SelectedRows[0].DataBoundItem;
                _selectedRoleId = role.Id;
                LoadRolePermissions(role.Id);
            }
        }

        private void LoadRolePermissions(int roleId)
        {
            try
            {
                var rolePermissions = _roleService.GetRolePermissions(roleId);
                var permissionIds = rolePermissions.Select(p => p.Id).ToList();

                foreach (TreeNode moduleNode in treePermissions.Nodes)
                {
                    foreach (TreeNode permissionNode in moduleNode.Nodes)
                    {
                        var permission = (Permission)permissionNode.Tag;
                        permissionNode.Checked = permissionIds.Contains(permission.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading role permissions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSavePermissions_Click(object sender, EventArgs e)
        {
            if (!_selectedRoleId.HasValue)
            {
                MessageBox.Show("Please select a role first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedPermissions = new List<int>();
                foreach (TreeNode moduleNode in treePermissions.Nodes)
                {
                    foreach (TreeNode permissionNode in moduleNode.Nodes)
                    {
                        if (permissionNode.Checked)
                        {
                            var permission = (Permission)permissionNode.Tag;
                            selectedPermissions.Add(permission.Id);
                        }
                    }
                }

                _roleService.UpdateRolePermissions(_selectedRoleId.Value, selectedPermissions);
                MessageBox.Show("Permissions updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving permissions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new RoleEditDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        _roleService.Add(dialog.Role);
                        LoadRoles();
                        MessageBox.Show("Role added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding role: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            if (!_selectedRoleId.HasValue)
            {
                MessageBox.Show("Please select a role to edit.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var role = _roleService.GetById(_selectedRoleId.Value);
                using (var dialog = new RoleEditDialog(role))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        _roleService.Update(dialog.Role);
                        LoadRoles();
                        MessageBox.Show("Role updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating role: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            if (!_selectedRoleId.HasValue)
            {
                MessageBox.Show("Please select a role to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this role?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _roleService.Delete(_selectedRoleId.Value);
                    LoadRoles();
                    MessageBox.Show("Role deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting role: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
} 