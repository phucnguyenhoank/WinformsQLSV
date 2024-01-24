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
    public partial class frmFunctionSelector : Form
    {
        public frmFunctionSelector()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddStudent addStudentForm = new frmAddStudent();
            addStudentForm.ShowDialog(this);
        }
    }
}
