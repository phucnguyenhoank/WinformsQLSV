using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManager
{
    public partial class frmWorkLoadingStudentList : Form
    {
        frmStudentList frmStudentListFather = null;
        OpenFileDialog openFileDialog = null;
        public frmWorkLoadingStudentList(frmStudentList frmStudentListFather, OpenFileDialog openFileDialog)
        {
            InitializeComponent();
            this.frmStudentListFather = frmStudentListFather;
            this.openFileDialog = openFileDialog;
        }

        private void frmWorkLoading_Load(object sender, EventArgs e)
        {
            backgroundWorkerStudentList.RunWorkerAsync();
        }

        private void backgroundWorkerStudentList_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = frmStudentListFather.importStudentListExcel(sender, e, openFileDialog);
        }

        private void backgroundWorkerStudentList_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarStudentListLoading.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerStudentList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show($"IMPORT COMPLETELY!\nInserted row: {e.Result}");
            this.Close();
        }
    }
}
