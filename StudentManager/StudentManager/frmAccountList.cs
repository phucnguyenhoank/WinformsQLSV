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
    public partial class frmAccountList : Form
    {
        DataTable accountTable = null;
        public frmAccountList(DataTable accountTable)
        {
            InitializeComponent();
            this.accountTable = accountTable;
        }

        private void frmAccountList_Load(object sender, EventArgs e)
        {
            
            dataGridViewAccountList.DataSource = accountTable;
            dataGridViewAccountList.Columns["username"].HeaderText = "User Name";
            dataGridViewAccountList.Columns["hashedPassword"].HeaderText = "Hashed Password";
            dataGridViewAccountList.Columns["email"].HeaderText = "Email";

            dataGridViewAccountList.Columns["username"].ReadOnly = true;
            dataGridViewAccountList.Columns["hashedPassword"].ReadOnly = true;
            dataGridViewAccountList.Columns["email"].ReadOnly = true;



        }

        private void btnSaveAdminPermission_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewAccountList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewAccountList.Columns["IsAdmin"].Index)
            {
                bool isAdmin = (bool)dataGridViewAccountList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                string username = (string)dataGridViewAccountList.Rows[e.RowIndex].Cells["username"].Value;

                MessageBox.Show($"Giá trị IsAdmin của người dùng {username} đã thay đổi thành: {isAdmin}");
            }
        }
    }
}
