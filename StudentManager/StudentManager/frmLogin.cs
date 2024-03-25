using BLL;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegister frmRegister = new frmRegister();
                frmRegister.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[btnRegister_Click:{ex.Message}]");
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                AccountBLL accountBLL = new AccountBLL();
                bool okLogin = accountBLL.HaveAccount(txtUsername.Text, txtPassword.Text);
                if (okLogin)
                {
                    lblNoticeLogin.Text = "Login successfully";
                    lblNoticeLogin.ForeColor = Color.Green;
                    // MessageBox.Show("Successfully login"); // dòng này có thể xóa
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    lblNoticeLogin.Text = "Invalid username or password";
                    lblNoticeLogin.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[btnLogin_Click:{ex.Message}]");
            }

        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                frmForgetPassword frmFgPassword = new frmForgetPassword();
                frmFgPassword.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[btnForgetPassword_Click:{ex.Message}]");
            }
            

        }
    }
}
