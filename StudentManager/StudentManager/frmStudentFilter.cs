using System;
using System.Collections;
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

namespace StudentManager
{
    public partial class frmStudentFilter : Form
    {
        public frmStudentFilter()
        {
            InitializeComponent();

        }

        

        private DataTable filteredData;

        public DataTable FilteredData
        {
            get { return filteredData; }
        }
        
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentIDFilter.Text;
            string firstStudentName = txtStudentFirstNameFilter.Text;
            string lastStudentName = txtStudentLastNameFilter.Text;
            string phoneNumber = txtStudentPhoneNumberFilter.Text;
            DateTime studentBirthday = dtpStudentBirthdayFilter.Value.Date;
            string gender = (radioBtnStudentGenderFilter.Checked) ? "Male" : ((radioBtnBothGender.Checked)? "":"Female");
            string address = txtStudentAddressFilter.Text;

            StudentDatabaseManager studentDatabaseManager = new StudentDatabaseManager();
            filteredData = studentDatabaseManager.GetStudentFilterResult(studentID, firstStudentName, lastStudentName, phoneNumber, studentBirthday, gender, address);

            
            DialogResult = DialogResult.OK;
            Close();

        }

        private void btnCancelStudentFilter_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
