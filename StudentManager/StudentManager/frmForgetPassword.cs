﻿using System;
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
    public partial class frmForgetPassword : Form
    {
        private EmailVerificationService evs;

        public frmForgetPassword()
        {
            InitializeComponent();
        }


        /*
        private void btnSendCode_Click(object sender, EventArgs e)
        {

            btnSendCode.Enabled = false;

            lblForgetPasswordNotice.Text = "Sending...";
            lblForgetPasswordNotice.ForeColor = System.Drawing.Color.Yellow;
            

            evs = new EmailVerificationService();
            if (evs.SendOTP(txtForgetPasswordEmail.Text))
            {
                lblForgetPasswordNotice.Text = "Send OTP successfully";
                lblForgetPasswordNotice.ForeColor = System.Drawing.Color.Green;

                txtUserOTP.ReadOnly = false;
                btnVerifyOTP.Enabled = true;
            }
            else
            {
                lblForgetPasswordNotice.Text = "Send OTP fail";
                lblForgetPasswordNotice.ForeColor = System.Drawing.Color.Red;
            }

            btnSendCode.Enabled = true;
        }
        */

        private async void btnSendCode_Click(object sender, EventArgs e)
        {
            btnSendCode.Enabled = false;
            txtForgetPasswordEmail.ReadOnly = true;

            lblForgetPasswordNotice.Text = "Sending...";
            lblForgetPasswordNotice.ForeColor = System.Drawing.Color.Yellow;

            evs = new EmailVerificationService();
            if (await Task.Run(() => evs.SendOTP(txtForgetPasswordEmail.Text)))
            {
                lblForgetPasswordNotice.Text = "Send OTP successfully";
                lblForgetPasswordNotice.ForeColor = System.Drawing.Color.Green;

                btnSendCode.Enabled = false;
                txtUserOTP.ReadOnly = false;
                btnVerifyOTP.Enabled = true;
            }
            else
            {
                lblForgetPasswordNotice.Text = "Send OTP fail";
                lblForgetPasswordNotice.ForeColor = System.Drawing.Color.Red;
            }

            btnSendCode.Enabled = true;
        }

        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            if (evs.VerifyOTP(txtUserOTP.Text))
            {
                lblForgetPasswordNotice.Text = "Verify successfully";
                lblForgetPasswordNotice.ForeColor = System.Drawing.Color.Green;

                frmResetPassword frmRsPass = new frmResetPassword(txtForgetPasswordEmail.Text);
                frmRsPass.ShowDialog();
                this.Close();
            }
            else
            {
                lblForgetPasswordNotice.Text = "Verify failed";
                lblForgetPasswordNotice.ForeColor = System.Drawing.Color.Red;
                txtUserOTP.ReadOnly = true;
                btnVerifyOTP.Enabled = false;
            }
        }

        private void btnCancelForgerPasswordForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmForgetPassword_Load(object sender, EventArgs e)
        {
            txtUserOTP.ReadOnly = true;
            btnVerifyOTP.Enabled = false;
            txtForgetPasswordEmail_TextChanged(sender, e);

        }

        private void txtForgetPasswordEmail_TextChanged(object sender, EventArgs e)
        {
            this.btnSendCode.Enabled = false;
            BLL.AccountBLL accountBLL = new BLL.AccountBLL();

            if (String.IsNullOrEmpty(txtForgetPasswordEmail.Text))
            {
                errorProviderForgetPassword.SetError(txtForgetPasswordEmail, "do not let empty");
            }
            else if (!accountBLL.HaveEmail(txtForgetPasswordEmail.Text))
            {
                errorProviderForgetPassword.SetError(txtForgetPasswordEmail, "this email have never used for registration");
            }
            else
            {
                errorProviderForgetPassword.SetError(txtForgetPasswordEmail, "");
                this.btnSendCode.Enabled = true;
            }
        }
    }
}
