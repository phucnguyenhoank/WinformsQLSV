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

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentList studentListForm = new frmStudentList();
            studentListForm.ShowDialog(this);
        }

        private void frmFunctionSelector_Load(object sender, EventArgs e)
        {

        }

        private void birthMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStatis frmSta = new frmStatis();
            frmSta.ShowDialog(this);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.AccountBLL accountBLL = new BLL.AccountBLL();
                frmAccountList accountList = new frmAccountList(accountBLL.GetAccountList());
                accountList.ShowDialog(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"adminToolStripMenuItem_Click:{ex.Message}");
            }
            

        }
    }
}
