using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Microsoft.Office.Interop.Excel;


namespace StudentManager
{
    public partial class frmStudentList : Form
    {
        frmWorkLoadingStudentList frmWorkLoading = null;
        public frmStudentList()
        {
            InitializeComponent();
        }

        private void btnResetStudentList_Click(object sender, EventArgs e)
        {
            try
            {
                StudentBLL managerStudentDatabase = new StudentBLL();
                using (SqlConnection connection = managerStudentDatabase.Connection)
                {
                    connection.Open();

                    string query = "SELECT * FROM Students";
                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, connection));
                    System.Data.DataTable dataTable = new System.Data.DataTable();
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

                    System.Data.DataTable dataTable = (new StudentBLL()).GetStudentDataTableByID(cellValue.ToString());

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


        public void ApplyNewDataTable(System.Data.DataTable dataTable)
        {
            // Chuyển đổi dữ liệu varbinary thành hình ảnh
            // thêm một cột tên là 'Ảnh', có kiểu là Image vào datatable
            dataTable.Columns.Add("Ảnh", typeof(Image));
            foreach (DataRow row in dataTable.Rows)
            {

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
            try
            {

                frmStudentFilter tempFrmStudentFilter = new frmStudentFilter();

                if (tempFrmStudentFilter.ShowDialog() == DialogResult.OK)
                {
                    ApplyNewDataTable(tempFrmStudentFilter.FilteredData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnFilter_Click:{ex.Message}");
            }
        }

        public int importStudentListExcel(object sender, EventArgs e, OpenFileDialog openFileDialog)
        {
            int insertedRowNumber = 0;

            // Initialize Excel application
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
            Worksheet worksheet = workbook.ActiveSheet;

            // Get the used range of the worksheet
            Range range = worksheet.UsedRange;

            // Set the maximum value of the ProgressBar
            frmWorkLoading.progressBarStudentListLoading.Maximum = range.Rows.Count;

            // Create DataTable to hold Excel data
            System.Data.DataTable dt = new System.Data.DataTable();

            for (int row = 1; row <= range.Rows.Count; row++)
            {
                DataRow dr = dt.NewRow();
                for (int col = 1; col <= range.Columns.Count; col++)
                {
                    Range cell = range.Cells[row, col] as Range;
                    if (cell != null && cell.Value2 != null)
                    {
                        string cellValue = cell.Value2.ToString();
                        if (row == 1)
                        {
                            // Add columns from the first row
                            dt.Columns.Add(cellValue);
                        }
                        else
                        {
                            // Add data rows
                            dr[col - 1] = cellValue;
                        }
                    }
                    else if (row == 1)
                    {
                        // Add empty column for null or empty cell in the first row
                        dt.Columns.Add("");
                    }
                }
                if (row != 1)
                {
                    // Calculate email and add to the row
                    string email = dr[1].ToString() + "@student.hcmute.edu.vn"; // Assuming the second column contains MaSV
                    dr["Email"] = email;
                    dt.Rows.Add(dr);
                }
                // REPORT
                frmWorkLoading.backgroundWorkerStudentList.ReportProgress(row);
            }

            

            StudentBLL studentBLL = new StudentBLL();

            // btnResetStudentList_Click(sender, e);
            if (dataGirdViewStudentList.DataSource != null)
            {
                System.Data.DataTable existingData = studentBLL.GetStudentList(); // (System.Data.DataTable)dataGirdViewStudentList.DataSource;

                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = existingData.NewRow();

                    newRow[0] = row["Mã SV"];
                    newRow[1] = row["Tên"];
                    newRow[2] = row["Họ"];
                    DateTime ngaySinh;
                    if (DateTime.TryParseExact(row["Ngày sinh"].ToString(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                    {
                        newRow[4] = ngaySinh;
                    }
                    else
                    {
                        // Nếu không chuyển đổi được, bạn có thể xử lý theo cách nào đó, ví dụ như gán giá trị mặc định hoặc thông báo lỗi
                        newRow[4] = DBNull.Value;
                    }

                    if (!studentBLL.HaveStudent((string)row["Mã SV"]))
                    {
                        existingData.Rows.Add(newRow);
                        insertedRowNumber += 1;
                    }

                }

                studentBLL.SaveStudentListImportedDataTable(existingData);
                

            }
            




            // Release Excel resources
            workbook.Close(false);
            excelApp.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(excelApp);

            return insertedRowNumber;
        }

        public void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    frmWorkLoading = new frmWorkLoadingStudentList(this, openFileDialog);
                    frmWorkLoading.ShowDialog();
                    // reset data grid view
                    btnResetStudentList_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnImport_Click:{ex.Message}");
            }
            

        
        }

        // Function to release COM objects
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void SaveImportedData(System.Data.DataTable dt)
        {

        }


    }
}
