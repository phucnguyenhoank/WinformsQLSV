using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnCancelOfRegisterForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegisterOfRegisterForm_Click(object sender, EventArgs e)
        {
            if (txtNewUsername.Text.Length < 6 || txtNewPassword.Text.Length < 6)
            {
                lblNoticeRegister.Text = "username and password must be at least 6 characters";
                lblNoticeRegister.ForeColor = Color.Tomato;
                return;
            }

            if (String.Compare(txtNewPassword.Text, txtVerifyPassword.Text) != 0)
            {
                lblNoticeRegister.Text = "be careful, wrong verify password";
                lblNoticeRegister.ForeColor = Color.Tomato;
                return;
            }

            ManagerStudentDatabase managerStudentDatabase = new ManagerStudentDatabase();

            if (managerStudentDatabase.HaveUsernameInTheDB(txtNewUsername.Text))
            {
                lblNoticeRegister.Text = "the username has already existed";
                lblNoticeRegister.ForeColor = Color.Tomato;
                return;
            }

            managerStudentDatabase.AddAccount(txtNewUsername.Text, txtNewPassword.Text);
            lblNoticeRegister.Text = "Register successfully";
            lblNoticeRegister.ForeColor = Color.Green;

        }

        private void btnLoginOfRegisterForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
