using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace StudentManager
{
    public partial class frmEditStudent : Form
    {
        public frmEditStudent()
        {
            InitializeComponent();
        }

        public System.Windows.Forms.TextBox TxtEditStudentID
        {
            get { return this.txtEditStudentID; }
            set { this.txtEditStudentID = value; }
        }

        public System.Windows.Forms.TextBox TxtEditStudentFirstName
        {
            get { return txtEditStudentFirstName; }
            set { txtEditStudentFirstName = value; }
        }

        public System.Windows.Forms.TextBox TxtEditStudentLastName
        {
            get { return txtEditStudentLastName; }
            set { txtEditStudentLastName = value; }
        }

        public System.Windows.Forms.TextBox TxtEditStudentPhoneNumber
        {
            get { return txtEditStudentPhoneNumber; }
            set { txtEditStudentPhoneNumber = value; }
        }

        public System.Windows.Forms.TextBox TxtEditStudentAddress
        {
            get { return txtEditStudentAddress; }
            set { txtEditStudentAddress = value; }
        }

        public DateTimePicker DtpEditStudentBirthday
        {
            get { return dtpEditStudentBirthday; }
            set { dtpEditStudentBirthday = value; }
        }

        public System.Windows.Forms.RadioButton RadioBtnEditStudentGender
        {
            get { return rbtnEditStudentGenderMale;}
            set { rbtnEditStudentGenderMale = value; }
        }

        public PictureBox PicboxEditStudentImage
        {
            get { return picboxEditStudentImage; }
            set { picboxEditStudentImage = value; }
        }

        private void btnCancelEditStudent_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void btnFindStudent_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = (new StudentBLL()).GetStudentDataTableByID(txtEditStudentID.Text);

                DataRow row = dataTable.Rows[0];
                TxtEditStudentID.Text = row.Field<string>("studentID");
                TxtEditStudentFirstName.Text = row.Field<string>("first_name");
                TxtEditStudentLastName.Text = row.Field<string>("last_name");
                TxtEditStudentPhoneNumber.Text = row.Field<string>("phone_number");
                DtpEditStudentBirthday.Value = row.Field<DateTime>("birth_day");
                if (row.Field<string>("gender") == "Male")
                {
                    RadioBtnEditStudentGender.Checked = true;
                }
                else
                {
                    rbtnEditStudentGenderFemale.Checked = true;
                }
                // RadioBtnEditStudentGender.Checked = (row.Field<string>("gender") == "Male") ? true : false;
                TxtEditStudentAddress.Text = row.Field<string>("std_address");

                MemoryStream ms = new MemoryStream(row.Field<byte[]>("std_image"));
                PicboxEditStudentImage.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnFindStudent_Click:{ex.Message}");
            }


        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                StudentBLL db = new StudentBLL();
                DialogResult dialog = MessageBox.Show("Do you really want to remove student who has student ID: " + txtEditStudentID.Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    if (db.RemoveStudent(txtEditStudentID.Text))
                    {
                        MessageBox.Show("Remove successfully");
                    }
                    else
                    {
                        MessageBox.Show("Remove failed");
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnRemoveStudent_Click:{ex.Message}");
            }
        }

        private void picboxEditStudentImage_Click(object sender, EventArgs e)
        {

        }

        private void radioBtnEditStudentGender_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void frmEditStudent_Load(object sender, EventArgs e)
        {
            rbtnEditStudentGenderMale.Checked = true;
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(errorProviderName.GetError(txtEditStudentFirstName)) ||
                !string.IsNullOrEmpty(errorProviderName.GetError(txtEditStudentLastName)) ||
                !string.IsNullOrEmpty(errorProviderName.GetError(txtEditStudentPhoneNumber)) ||
                !string.IsNullOrEmpty(errorProviderName.GetError(txtEditStudentID))
                )
            {
                MessageBox.Show("Please enter valid information");
                return;
            }
            try
            {
                StudentBLL db = new StudentBLL();
                DialogResult dialog = MessageBox.Show("Do you really want to edit student who has student ID: " + txtEditStudentID.Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    string studentID = txtEditStudentID.Text;
                    string firstStudentName = txtEditStudentFirstName.Text;
                    string lastStudentName = txtEditStudentLastName.Text;
                    string phoneNumber = txtEditStudentPhoneNumber.Text;
                    DateTime studentBirthday = dtpEditStudentBirthday.Value.Date;
                    string gender = (rbtnEditStudentGenderMale.Checked) ? "Male" : "Female";
                    string address = txtEditStudentAddress.Text;

                    MemoryStream studentPicMemoryStream = new MemoryStream();
                    picboxEditStudentImage.Image.Save(studentPicMemoryStream, picboxEditStudentImage.Image.RawFormat);
                    byte[] studentImageData = studentPicMemoryStream.ToArray();

                    Student newStudent = new Student(studentID, firstStudentName, lastStudentName, phoneNumber, studentBirthday, gender, address, studentImageData);

                    if (db.EditStudent(studentID, newStudent))
                    {
                        MessageBox.Show("Edit successfully");
                    }
                    else
                    {
                        MessageBox.Show("Edit failed");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[btnEditStudent_Click:{ex.Message}");
            }
        }

        private void btnUploadStudentPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Imagee(*.jpg;*.png)|*.jpg;*.png";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picboxEditStudentImage.Image = Image.FromFile(opf.FileName);
            }

        }

        private void txtEditStudentFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtEditStudentFirstName.Text.Any(char.IsDigit))
            {
                errorProviderName.SetError(txtEditStudentFirstName, "first name contains digits");
            }
            else
            {
                errorProviderName.SetError(txtEditStudentFirstName, "");
            }
        }

        private void txtEditStudentLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtEditStudentLastName.Text.Any(char.IsDigit))
            {
                errorProviderName.SetError(txtEditStudentLastName, "last name contains digits");
            }
            else
            {
                errorProviderName.SetError(txtEditStudentLastName, "");
            }
        }

        private void txtEditStudentPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEditStudentPhoneNumber.Text, out _))
            {
                errorProviderName.SetError(txtEditStudentPhoneNumber, "cannot be phone number, being empty or contains letters");
            }
            else
            {
                errorProviderName.SetError(txtEditStudentPhoneNumber, "");
            }
        }

        private void txtEditStudentID_TextChanged(object sender, EventArgs e)
        {
            // txtEditStudentID
            StudentBLL db = new StudentBLL();
            if (!db.HaveStudent(txtEditStudentID.Text))
            {
                errorProviderName.SetError(txtEditStudentID, "no exist student");
            }
            else
            {
                errorProviderName.SetError(txtEditStudentID, "");
            }
        }
    }
}
