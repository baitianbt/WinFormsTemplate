using System;
using System.Linq;
using System.Windows.Forms;
using YourSolution.BLL.Interfaces;
using YourSolution.Model;

namespace YourSolution.WinForm.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly IUserService _userService;
        private int? _selectedUserId;

        public UserManagementForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            LoadUsers();
        }

        private void LoadUsers()
        {
            dataGridViewUsers.DataSource = _userService.GetAll().ToList();
        }

        private void ClearForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            chkIsActive.Checked = false;
            _selectedUserId = null;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                var user = (User)dataGridViewUsers.SelectedRows[0].DataBoundItem;
                _selectedUserId = user.Id;
                txtUsername.Text = user.Username;
                txtPassword.Text = user.Password;
                txtEmail.Text = user.Email;
                chkIsActive.Checked = user.IsActive;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    IsActive = chkIsActive.Checked
                };

                _userService.Add(user);
                LoadUsers();
                ClearForm();
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!_selectedUserId.HasValue) return;

            try
            {
                var user = new User
                {
                    Id = _selectedUserId.Value,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    IsActive = chkIsActive.Checked
                };

                _userService.Update(user);
                LoadUsers();
                ClearForm();
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedUserId.HasValue) return;

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _userService.Delete(_selectedUserId.Value);
                    LoadUsers();
                    ClearForm();
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
} 