using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnCancelAddStudent_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUploadStudentPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png)|*.jpg;*.png";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picboxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(errorProviderUserInput.GetError(txtStudentFirstName)) || 
                !string.IsNullOrEmpty(errorProviderUserInput.GetError(txtStudentLastName)) || 
                !string.IsNullOrEmpty(errorProviderUserInput.GetError(txtStudentPhoneNumber)))
            {
                MessageBox.Show("Please enter valid information");
                return;
            }

            try
            {

                string studentID = txtStudentID.Text;
                string firstStudentName = txtStudentFirstName.Text;
                string lastStudentName = txtStudentLastName.Text;
                string phoneNumber = txtStudentPhoneNumber.Text;
                DateTime studentBirthday = dtpStudentBirthday.Value.Date;
                string gender = (rbtnAddStudentGenderMale.Checked) ? "Male" : "Female";
                string address = txtStudentAddress.Text;

                MemoryStream studentPicMemoryStream = new MemoryStream();
                picboxStudentImage.Image.Save(studentPicMemoryStream, picboxStudentImage.Image.RawFormat);
                byte[] studentImageData = studentPicMemoryStream.ToArray();

                Student addedStudent = new Student(studentID, firstStudentName, lastStudentName, phoneNumber, studentBirthday, gender, address, studentImageData);


                StudentBLL studentBLL = new StudentBLL();
                if (studentBLL.AddStudent(addedStudent))
                {
                    MessageBox.Show("Add Student successfully");
                }
                else
                {
                    MessageBox.Show("The StudentID already exists or some unexpected error occurred", "Add Student failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[btnAddStudent_Click:{ex.Message}]");
            }

        }

        private void picboxStudentImage_Click(object sender, EventArgs e)
        {

        }

        private void txtStudentFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtStudentFirstName.Text.Any(char.IsDigit))
            {
                errorProviderUserInput.SetError(txtStudentFirstName, "first name contains digits");
            }
            else
            {
                errorProviderUserInput.SetError(txtStudentFirstName, "");
            }
        }

        private void txtStudentLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtStudentLastName.Text.Any(char.IsDigit))
            {
                errorProviderUserInput.SetError(txtStudentLastName, "last name contains digits");
            }
            else
            {
                errorProviderUserInput.SetError(txtStudentLastName, "");
            }

        }

        private void txtStudentPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStudentPhoneNumber.Text, out _))
            {
                errorProviderUserInput.SetError(txtStudentPhoneNumber, "contains letters, empty, or too long");
            }
            else
            {
                errorProviderUserInput.SetError(txtStudentPhoneNumber, "");
            }
        }

        private void frmAddStudent_Load(object sender, EventArgs e)
        {
            rbtnAddStudentGenderMale.Checked = true;
        }
    }
}
