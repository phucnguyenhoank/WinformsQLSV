namespace StudentManager
{
    partial class frmAddStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNoticeLogin = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnCancelAddStudent = new System.Windows.Forms.Button();
            this.txtStudentFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentLastName = new System.Windows.Forms.TextBox();
            this.lblStudentLastname = new System.Windows.Forms.Label();
            this.txtStudentPhoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStudentBirthday = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStudentAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUploadStudentPicture = new System.Windows.Forms.Button();
            this.radioBtnStudentGender = new System.Windows.Forms.RadioButton();
            this.picboxStudentImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxStudentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoticeLogin
            // 
            this.lblNoticeLogin.AutoSize = true;
            this.lblNoticeLogin.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoticeLogin.Location = new System.Drawing.Point(199, 430);
            this.lblNoticeLogin.Name = "lblNoticeLogin";
            this.lblNoticeLogin.Size = new System.Drawing.Size(0, 21);
            this.lblNoticeLogin.TabIndex = 17;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnAddStudent.FlatAppearance.BorderSize = 0;
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.ForeColor = System.Drawing.Color.White;
            this.btnAddStudent.Location = new System.Drawing.Point(144, 652);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(145, 56);
            this.btnAddStudent.TabIndex = 6;
            this.btnAddStudent.Text = "Add";
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnCancelAddStudent
            // 
            this.btnCancelAddStudent.BackColor = System.Drawing.Color.Gray;
            this.btnCancelAddStudent.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelAddStudent.FlatAppearance.BorderSize = 0;
            this.btnCancelAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAddStudent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAddStudent.ForeColor = System.Drawing.Color.White;
            this.btnCancelAddStudent.Location = new System.Drawing.Point(496, 652);
            this.btnCancelAddStudent.Name = "btnCancelAddStudent";
            this.btnCancelAddStudent.Size = new System.Drawing.Size(145, 56);
            this.btnCancelAddStudent.TabIndex = 7;
            this.btnCancelAddStudent.Text = "Cancel";
            this.btnCancelAddStudent.UseVisualStyleBackColor = false;
            this.btnCancelAddStudent.Click += new System.EventHandler(this.btnCancelAddStudent_Click);
            // 
            // txtStudentFirstName
            // 
            this.txtStudentFirstName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentFirstName.Location = new System.Drawing.Point(264, 293);
            this.txtStudentFirstName.Name = "txtStudentFirstName";
            this.txtStudentFirstName.Size = new System.Drawing.Size(377, 31);
            this.txtStudentFirstName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(108, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "First name:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.Location = new System.Drawing.Point(264, 237);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(377, 31);
            this.txtStudentID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(108, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Student ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.label1.Location = new System.Drawing.Point(469, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 54);
            this.label1.TabIndex = 10;
            this.label1.Text = "Add Student";
            // 
            // txtStudentLastName
            // 
            this.txtStudentLastName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentLastName.Location = new System.Drawing.Point(264, 353);
            this.txtStudentLastName.Name = "txtStudentLastName";
            this.txtStudentLastName.Size = new System.Drawing.Size(377, 31);
            this.txtStudentLastName.TabIndex = 2;
            // 
            // lblStudentLastname
            // 
            this.lblStudentLastname.AutoSize = true;
            this.lblStudentLastname.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentLastname.ForeColor = System.Drawing.Color.Gray;
            this.lblStudentLastname.Location = new System.Drawing.Point(110, 353);
            this.lblStudentLastname.Name = "lblStudentLastname";
            this.lblStudentLastname.Size = new System.Drawing.Size(117, 23);
            this.lblStudentLastname.TabIndex = 18;
            this.lblStudentLastname.Text = "Last name:";
            // 
            // txtStudentPhoneNumber
            // 
            this.txtStudentPhoneNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentPhoneNumber.Location = new System.Drawing.Point(264, 408);
            this.txtStudentPhoneNumber.Name = "txtStudentPhoneNumber";
            this.txtStudentPhoneNumber.Size = new System.Drawing.Size(377, 31);
            this.txtStudentPhoneNumber.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(69, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Phone number:";
            // 
            // dtpStudentBirthday
            // 
            this.dtpStudentBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStudentBirthday.Location = new System.Drawing.Point(264, 463);
            this.dtpStudentBirthday.Name = "dtpStudentBirthday";
            this.dtpStudentBirthday.Size = new System.Drawing.Size(305, 27);
            this.dtpStudentBirthday.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(127, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 23);
            this.label7.TabIndex = 23;
            this.label7.Text = "Birth day:";
            // 
            // txtStudentAddress
            // 
            this.txtStudentAddress.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentAddress.Location = new System.Drawing.Point(264, 531);
            this.txtStudentAddress.Multiline = true;
            this.txtStudentAddress.Name = "txtStudentAddress";
            this.txtStudentAddress.Size = new System.Drawing.Size(377, 65);
            this.txtStudentAddress.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(128, 531);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Address:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(688, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 23);
            this.label9.TabIndex = 26;
            this.label9.Text = "Picture:";
            // 
            // btnUploadStudentPicture
            // 
            this.btnUploadStudentPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnUploadStudentPicture.FlatAppearance.BorderSize = 0;
            this.btnUploadStudentPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadStudentPicture.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadStudentPicture.ForeColor = System.Drawing.Color.White;
            this.btnUploadStudentPicture.Location = new System.Drawing.Point(983, 559);
            this.btnUploadStudentPicture.Name = "btnUploadStudentPicture";
            this.btnUploadStudentPicture.Size = new System.Drawing.Size(127, 37);
            this.btnUploadStudentPicture.TabIndex = 5;
            this.btnUploadStudentPicture.Text = "Upload";
            this.btnUploadStudentPicture.UseVisualStyleBackColor = false;
            this.btnUploadStudentPicture.Click += new System.EventHandler(this.btnUploadStudentPicture_Click);
            // 
            // radioBtnStudentGender
            // 
            this.radioBtnStudentGender.AutoSize = true;
            this.radioBtnStudentGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnStudentGender.Location = new System.Drawing.Point(575, 466);
            this.radioBtnStudentGender.Name = "radioBtnStudentGender";
            this.radioBtnStudentGender.Size = new System.Drawing.Size(66, 24);
            this.radioBtnStudentGender.TabIndex = 31;
            this.radioBtnStudentGender.TabStop = true;
            this.radioBtnStudentGender.Text = "Male";
            this.radioBtnStudentGender.UseVisualStyleBackColor = true;
            // 
            // picboxStudentImage
            // 
            this.picboxStudentImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxStudentImage.Location = new System.Drawing.Point(797, 243);
            this.picboxStudentImage.Name = "picboxStudentImage";
            this.picboxStudentImage.Size = new System.Drawing.Size(313, 296);
            this.picboxStudentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxStudentImage.TabIndex = 27;
            this.picboxStudentImage.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StudentManager.Properties.Resources.LOGO_UTE;
            this.pictureBox1.Location = new System.Drawing.Point(83, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelAddStudent;
            this.ClientSize = new System.Drawing.Size(1196, 753);
            this.Controls.Add(this.radioBtnStudentGender);
            this.Controls.Add(this.btnUploadStudentPicture);
            this.Controls.Add(this.picboxStudentImage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStudentAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpStudentBirthday);
            this.Controls.Add(this.txtStudentPhoneNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStudentLastName);
            this.Controls.Add(this.lblStudentLastname);
            this.Controls.Add(this.lblNoticeLogin);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.btnCancelAddStudent);
            this.Controls.Add(this.txtStudentFirstName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddStudent";
            ((System.ComponentModel.ISupportInitialize)(this.picboxStudentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoticeLogin;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnCancelAddStudent;
        private System.Windows.Forms.TextBox txtStudentFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtStudentLastName;
        private System.Windows.Forms.Label lblStudentLastname;
        private System.Windows.Forms.TextBox txtStudentPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpStudentBirthday;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStudentAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox picboxStudentImage;
        private System.Windows.Forms.Button btnUploadStudentPicture;
        private System.Windows.Forms.RadioButton radioBtnStudentGender;
    }
}