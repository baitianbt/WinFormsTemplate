using System;
using System.Windows.Forms;
using YourSolution.Model;

namespace YourSolution.WinForm.Forms
{
    public partial class RoleEditDialog : Form
    {
        public Role Role { get; private set; }

        public RoleEditDialog(Role role = null)
        {
            InitializeComponent();
            if (role != null)
            {
                Role = role;
                txtName.Text = role.Name;
                txtDescription.Text = role.Description;
                chkIsActive.Checked = role.IsActive;
            }
            else
            {
                Role = new Role { IsActive = true };
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Role name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Role.Name = txtName.Text;
            Role.Description = txtDescription.Text;
            Role.IsActive = chkIsActive.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 