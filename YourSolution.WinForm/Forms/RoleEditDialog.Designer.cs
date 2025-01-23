namespace YourSolution.WinForm.Forms
{
    partial class RoleEditDialog
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
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            chkIsActive = new CheckBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 15);
            lblName.Size = new Size(45, 15);
            lblName.Text = "Name:";

            // 
            // txtName
            // 
            txtName.Location = new Point(92, 12);
            txtName.Size = new Size(200, 23);

            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 44);
            lblDescription.Size = new Size(70, 15);
            lblDescription.Text = "Description:";

            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(92, 41);
            txtDescription.Multiline = true;
            txtDescription.Size = new Size(200, 60);

            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(92, 107);
            chkIsActive.Size = new Size(74, 19);
            chkIsActive.Text = "Is Active";

            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(92, 132);
            btnOK.Size = new Size(90, 25);
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;

            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(202, 132);
            btnCancel.Size = new Size(90, 25);
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            // 
            // RoleEditDialog
            // 
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 171);
            Controls.AddRange(new Control[] {
                lblName, txtName,
                lblDescription, txtDescription,
                chkIsActive,
                btnOK, btnCancel
            });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Role";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private CheckBox chkIsActive;
        private Button btnOK;
        private Button btnCancel;
    }
} 