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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace StudentManager
{
    public partial class frmEditStudent : Form
    {
        public frmEditStudent()
        {
            InitializeComponent();
        }

        public TextBox TxtEditStudentID
        {
            get { return this.txtEditStudentID; }
            set { this.txtEditStudentID = value; }
        }

        public TextBox TxtEditStudentFirstName
        {
            get { return txtEditStudentFirstName; }
            set { txtEditStudentFirstName = value; }
        }

        public TextBox TxtEditStudentLastName
        {
            get { return txtEditStudentLastName; }
            set { txtEditStudentLastName = value; }
        }

        public TextBox TxtEditStudentPhoneNumber
        {
            get { return txtEditStudentPhoneNumber; }
            set { txtEditStudentPhoneNumber = value; }
        }

        public TextBox TxtEditStudentAddress
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
            get { return radioBtnEditStudentGender;}
            set { radioBtnEditStudentGender = value; }
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

        private void txtEditStudentID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnFindStudent_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = (new StudentDatabaseManager()).GetStudentDataTableByID(txtEditStudentID.Text);

                DataRow row = dataTable.Rows[0];
                TxtEditStudentID.Text = row.Field<string>("studentID");
                TxtEditStudentFirstName.Text = row.Field<string>("first_name");
                TxtEditStudentLastName.Text = row.Field<string>("last_name");
                TxtEditStudentPhoneNumber.Text = row.Field<string>("phone_number");
                DtpEditStudentBirthday.Value = row.Field<DateTime>("birth_day");
                RadioBtnEditStudentGender.Checked = (row.Field<string>("gender") == "Male") ? true : false;
                TxtEditStudentAddress.Text = row.Field<string>("std_address");

                MemoryStream ms = new MemoryStream(row.Field<byte[]>("std_image"));
                PicboxEditStudentImage.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                StudentDatabaseManager db = new StudentDatabaseManager();
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
                MessageBox.Show("Error: " + ex.Message);
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

        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                StudentDatabaseManager db = new StudentDatabaseManager();
                DialogResult dialog = MessageBox.Show("Do you really want to edit student who has student ID: " + txtEditStudentID.Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    string studentID = txtEditStudentID.Text;
                    string firstStudentName = txtEditStudentFirstName.Text;
                    string lastStudentName = txtEditStudentLastName.Text;
                    string phoneNumber = txtEditStudentPhoneNumber.Text;
                    DateTime studentBirthday = dtpEditStudentBirthday.Value.Date;
                    string gender = (radioBtnEditStudentGender.Checked) ? "Male" : "Female";
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
                MessageBox.Show("Error: " + ex.Message);
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
    }
}
