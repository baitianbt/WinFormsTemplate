using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using YourSolution.BLL.Interfaces;

namespace YourSolution.WinForm.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly ILogService _logService;

        public LoginForm(IUserService userService, ILogService logService)
        {
            InitializeComponent();
            _userService = userService;
            _logService = logService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                _logService.LogWarning($"Login attempt with empty username or password");
                MessageBox.Show("Please enter username and password.", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_userService.ValidateUser(txtUsername.Text, txtPassword.Text))
                {
                    _logService.LogInfo($"User '{txtUsername.Text}' logged in successfully");
                    var mainForm = Program.ServiceProvider.GetRequiredService<MainForm>();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    _logService.LogWarning($"Failed login attempt for user '{txtUsername.Text}'");
                    MessageBox.Show("Invalid username or password.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex, $"Login error for user '{txtUsername.Text}'");
                MessageBox.Show($"Login error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 