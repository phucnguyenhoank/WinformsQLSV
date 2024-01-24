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
            opf.Filter = "Select Imagee(*.jpg;*.png)|*.jpg;*.png";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picboxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentID.Text;
            string firstStudentName = txtStudentFirstName.Text;
            string lastStudentName = txtStudentLastName.Text;
            string phoneNumber = txtStudentPhoneNumber.Text;
            DateTime studentBirthday = dtpStudentBirthday.Value;
            string gender = (radioBtnStudentGender.Checked) ? "Male" : "Female";
            string address = txtStudentAddress.Text;

            MemoryStream studentPicMemoryStream = new MemoryStream();
            picboxStudentImage.Image.Save(studentPicMemoryStream, picboxStudentImage.Image.RawFormat);
            byte[] studentImageData = studentPicMemoryStream.ToArray();

            Student addedStudent = new Student(studentID, firstStudentName, lastStudentName, phoneNumber, studentBirthday, gender, address, studentImageData);

            ManagerStudentDatabase managerStudentDatabase = new ManagerStudentDatabase();
            if (managerStudentDatabase.AddStudent(addedStudent))
            {
                MessageBox.Show("Add Student successfully");
            }
            else
            {
                MessageBox.Show("The StudentID already exists or some unexpected error occured", "Add Student failed", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }
    }
}
