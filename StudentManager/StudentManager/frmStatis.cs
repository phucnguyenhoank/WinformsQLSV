using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StudentManager
{
    public partial class frmStatis : Form
    {
        public frmStatis()
        {
            InitializeComponent();
        }

        private void frmStatis_Load(object sender, EventArgs e)
        {
            BLL.StudentBLL studentBLL = new BLL.StudentBLL();
            // Tạo một đối tượng Series mới
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series("Number of students");

            // Thêm dữ liệu vào Series
            for (int i = 1; i <= 12; i++)
            {
                series.Points.AddXY(i, studentBLL.CountStudentsByMonth(i));
            }

            // Thêm Series vào Chart
            chartStatis.Series.Add(series);

            // Đặt tên cho trục X và Y
            chartStatis.ChartAreas[0].AxisX.Title = "Tháng";
            chartStatis.ChartAreas[0].AxisY.Title = "Số lượng sinh viên";
        }

    }
}
