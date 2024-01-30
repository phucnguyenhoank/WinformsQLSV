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

namespace StudentManager
{
    public partial class frmStudentList : Form
    {
        public frmStudentList()
        {
            InitializeComponent();
        }

        private void btnResetStudentList_Click(object sender, EventArgs e)
        {
            try
            {
                StudentDatabaseManager managerStudentDatabase = new StudentDatabaseManager();
                using (SqlConnection connection = managerStudentDatabase.Connection)
                {
                    connection.Open();

                    string query = "SELECT * FROM Students";
                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, connection));
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Chuyển đổi dữ liệu varbinary thành hình ảnh
                    // thêm một cột tên là 'Ảnh', có kiểu là Image vào datatable
                    dataTable.Columns.Add("Ảnh", typeof(Image));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // byte[] imageData = row.Field<byte[]>("std_image"); // or use this instead: byte[] imageData = (byte[])row["std_image"];
                        byte[] imageData = (byte[])row["std_image"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            // chuyển tất cả các mảng byte thành hình ảnh tại dòng tương ứng vào cột mới này
                            row["Ảnh"] = Image.FromStream(ms);
                        }
                    }

                    // Thiết lập DataGridView để hiển thị dữ liệu
                    dataGirdViewStudentList.DataSource = dataTable;

                    // Thiết lập cột DataGridView để hiển thị ảnh
                    dataGirdViewStudentList.Columns["gridColStudentImage"].Visible = false; // Ẩn cột chứa mảng byte vì không hiển thị ảnh được

                    // tên của cột 
                    // mặc định nếu như thiết kế ban đầu DataGridView không có cột nào (ban đầu hiện lên trống rỗng),
                    // thì việc truy cập vào từng cột sẽ dùng tên của cột của bảng trong datatable luôn
                    // tuy nhiên do ở đây DataGridView đã được tạo các cột và thuộc tính DataPropertyName đã được đặt để liên kết có chủ đích với
                    // datatable nên để truy cập đến các cột của DataGridView ta dùng thuộc tính Name của nó
                    dataGirdViewStudentList.Columns["gridColStudentID"].HeaderText = "MSSV";
                    dataGirdViewStudentList.Columns["gridColFirstName"].HeaderText = "Tên";
                    dataGirdViewStudentList.Columns["gridColLastName"].HeaderText = "Họ";
                    dataGirdViewStudentList.Columns["gridColPhoneNumber"].HeaderText = "Số điện thoại";
                    dataGirdViewStudentList.Columns["gridColBirthDay"].HeaderText = "Ngày sinh";
                    dataGirdViewStudentList.Columns["gridColGender"].HeaderText = "Giới tính";
                    dataGirdViewStudentList.Columns["gridColAddress"].HeaderText = "Địa chỉ";
                    dataGirdViewStudentList.Columns["gridColStudentImage"].HeaderText = "Ảnh";

                    dataGirdViewStudentList.Columns["gridColBirthDay"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    ((DataGridViewImageColumn)dataGirdViewStudentList.Columns["Ảnh"]).ImageLayout = DataGridViewImageCellLayout.Zoom; // cột này được sinh ra thêm từ datatable, không được chủ đích theo dõi, cho nên để truy cập nó ta dùng tên của cột của datatable luôn

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGirdViewStudentList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGirdViewStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải double click vào header cell hay không
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {   
                // Lấy giá trị của cell được double click
                object cellValue = dataGirdViewStudentList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // nếu nhấn vào cột id
                if (e.ColumnIndex == 0)
                {
                    frmEditStudent myFrmEditStudent = new frmEditStudent();
                    
                    DataTable dataTable = (new StudentDatabaseManager()).GetStudentDataTableByID(cellValue.ToString());

                    DataRow row = dataTable.Rows[0];
                    myFrmEditStudent.TxtEditStudentID.Text = row.Field<string>("studentID");
                    myFrmEditStudent.TxtEditStudentFirstName.Text = row.Field<string>("first_name");
                    myFrmEditStudent.TxtEditStudentLastName.Text = row.Field<string>("last_name");
                    myFrmEditStudent.TxtEditStudentPhoneNumber.Text = row.Field<string>("phone_number");
                    myFrmEditStudent.DtpEditStudentBirthday.Value = row.Field<DateTime>("birth_day");
                    myFrmEditStudent.RadioBtnEditStudentGender.Checked = (row.Field<string>("gender") == "Male")? true : false;
                    myFrmEditStudent.TxtEditStudentAddress.Text = row.Field<string>("std_address");

                    MemoryStream ms = new MemoryStream(row.Field<byte[]>("std_image"));
                    myFrmEditStudent.PicboxEditStudentImage.Image = Image.FromStream(ms);
                    myFrmEditStudent.ShowDialog();
                }
            }
        }

        private void dataGirdViewStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmStudentList_Load(object sender, EventArgs e)
        {
            btnResetStudentList_Click(sender, e);
        }


        public void ApplyNewDataTable(DataTable dataTable)
        {
            // Chuyển đổi dữ liệu varbinary thành hình ảnh
            // thêm một cột tên là 'Ảnh', có kiểu là Image vào datatable
            dataTable.Columns.Add("Ảnh", typeof(Image));
            foreach (DataRow row in dataTable.Rows)
            {
                // byte[] imageData = row.Field<byte[]>("std_image"); // or use this instead: byte[] imageData = (byte[])row["std_image"];
                byte[] imageData = (byte[])row["std_image"];
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    // chuyển tất cả các mảng byte thành hình ảnh tại dòng tương ứng vào cột mới này
                    row["Ảnh"] = Image.FromStream(ms);
                }
            }

            // Thiết lập DataGridView để hiển thị dữ liệu
            dataGirdViewStudentList.DataSource = dataTable;

            // Thiết lập cột DataGridView để hiển thị ảnh
            dataGirdViewStudentList.Columns["gridColStudentImage"].Visible = false; // Ẩn cột chứa mảng byte vì không hiển thị ảnh được

            // tên của cột 
            // mặc định nếu như thiết kế ban đầu DataGridView không có cột nào (ban đầu hiện lên trống rỗng),
            // thì việc truy cập vào từng cột sẽ dùng tên của cột của bảng trong datatable luôn
            // tuy nhiên do ở đây DataGridView đã được tạo các cột và thuộc tính DataPropertyName đã được đặt để liên kết có chủ đích với
            // datatable nên để truy cập đến các cột của DataGridView ta dùng thuộc tính Name của nó
            dataGirdViewStudentList.Columns["gridColStudentID"].HeaderText = "MSSV";
            dataGirdViewStudentList.Columns["gridColFirstName"].HeaderText = "Tên";
            dataGirdViewStudentList.Columns["gridColLastName"].HeaderText = "Họ";
            dataGirdViewStudentList.Columns["gridColPhoneNumber"].HeaderText = "Số điện thoại";
            dataGirdViewStudentList.Columns["gridColBirthDay"].HeaderText = "Ngày sinh";
            dataGirdViewStudentList.Columns["gridColGender"].HeaderText = "Giới tính";
            dataGirdViewStudentList.Columns["gridColAddress"].HeaderText = "Địa chỉ";
            dataGirdViewStudentList.Columns["gridColStudentImage"].HeaderText = "Ảnh";

            dataGirdViewStudentList.Columns["gridColBirthDay"].DefaultCellStyle.Format = "MM/dd/yyyy";
            ((DataGridViewImageColumn)dataGirdViewStudentList.Columns["Ảnh"]).ImageLayout = DataGridViewImageCellLayout.Zoom; // cột này được sinh ra thêm từ datatable, không được chủ đích theo dõi, cho nên để truy cập nó ta dùng tên của cột của datatable luôn
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmStudentFilter tempFrmStudentFilter = new frmStudentFilter();

            if (tempFrmStudentFilter.ShowDialog() == DialogResult.OK)
            {
                ApplyNewDataTable(tempFrmStudentFilter.FilteredData);
            }
            



        }
    }
}
