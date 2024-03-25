namespace StudentManager
{
    partial class frmStudentList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGirdViewStudentList = new System.Windows.Forms.DataGridView();
            this.gridColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColStudentImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnResetStudentList = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGirdViewStudentList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGirdViewStudentList
            // 
            this.dataGirdViewStudentList.AllowUserToAddRows = false;
            this.dataGirdViewStudentList.AllowUserToResizeRows = false;
            this.dataGirdViewStudentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGirdViewStudentList.ColumnHeadersHeight = 25;
            this.dataGirdViewStudentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridColStudentID,
            this.gridColFirstName,
            this.gridColLastName,
            this.gridColPhoneNumber,
            this.gridColBirthday,
            this.gridColGender,
            this.gridColAddress,
            this.gridColStudentImage});
            this.dataGirdViewStudentList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGirdViewStudentList.Location = new System.Drawing.Point(0, 0);
            this.dataGirdViewStudentList.Name = "dataGirdViewStudentList";
            this.dataGirdViewStudentList.ReadOnly = true;
            this.dataGirdViewStudentList.RowHeadersVisible = false;
            this.dataGirdViewStudentList.RowHeadersWidth = 51;
            this.dataGirdViewStudentList.RowTemplate.Height = 50;
            this.dataGirdViewStudentList.RowTemplate.ReadOnly = true;
            this.dataGirdViewStudentList.Size = new System.Drawing.Size(853, 566);
            this.dataGirdViewStudentList.TabIndex = 0;
            this.dataGirdViewStudentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGirdViewStudentList_CellContentClick);
            this.dataGirdViewStudentList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGirdViewStudentList_CellContentDoubleClick);
            this.dataGirdViewStudentList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGirdViewStudentList_CellDoubleClick);
            // 
            // gridColStudentID
            // 
            this.gridColStudentID.DataPropertyName = "studentID";
            this.gridColStudentID.HeaderText = "MSSV";
            this.gridColStudentID.MinimumWidth = 6;
            this.gridColStudentID.Name = "gridColStudentID";
            this.gridColStudentID.ReadOnly = true;
            this.gridColStudentID.Width = 74;
            // 
            // gridColFirstName
            // 
            this.gridColFirstName.DataPropertyName = "first_name";
            this.gridColFirstName.HeaderText = "Tên";
            this.gridColFirstName.MinimumWidth = 6;
            this.gridColFirstName.Name = "gridColFirstName";
            this.gridColFirstName.ReadOnly = true;
            this.gridColFirstName.Width = 60;
            // 
            // gridColLastName
            // 
            this.gridColLastName.DataPropertyName = "last_name";
            this.gridColLastName.HeaderText = "Họ";
            this.gridColLastName.MinimumWidth = 6;
            this.gridColLastName.Name = "gridColLastName";
            this.gridColLastName.ReadOnly = true;
            this.gridColLastName.Width = 54;
            // 
            // gridColPhoneNumber
            // 
            this.gridColPhoneNumber.DataPropertyName = "phone_number";
            this.gridColPhoneNumber.HeaderText = "Số điện thoại";
            this.gridColPhoneNumber.MinimumWidth = 6;
            this.gridColPhoneNumber.Name = "gridColPhoneNumber";
            this.gridColPhoneNumber.ReadOnly = true;
            this.gridColPhoneNumber.Width = 114;
            // 
            // gridColBirthday
            // 
            this.gridColBirthday.DataPropertyName = "birth_day";
            this.gridColBirthday.HeaderText = "Ngày sinh";
            this.gridColBirthday.MinimumWidth = 6;
            this.gridColBirthday.Name = "gridColBirthday";
            this.gridColBirthday.ReadOnly = true;
            this.gridColBirthday.Width = 96;
            // 
            // gridColGender
            // 
            this.gridColGender.DataPropertyName = "gender";
            this.gridColGender.HeaderText = "Giới tính";
            this.gridColGender.MinimumWidth = 6;
            this.gridColGender.Name = "gridColGender";
            this.gridColGender.ReadOnly = true;
            this.gridColGender.Width = 83;
            // 
            // gridColAddress
            // 
            this.gridColAddress.DataPropertyName = "std_address";
            this.gridColAddress.HeaderText = "Địa chỉ";
            this.gridColAddress.MinimumWidth = 6;
            this.gridColAddress.Name = "gridColAddress";
            this.gridColAddress.ReadOnly = true;
            this.gridColAddress.Width = 76;
            // 
            // gridColStudentImage
            // 
            this.gridColStudentImage.DataPropertyName = "std_image";
            this.gridColStudentImage.HeaderText = "Ảnh";
            this.gridColStudentImage.MinimumWidth = 6;
            this.gridColStudentImage.Name = "gridColStudentImage";
            this.gridColStudentImage.ReadOnly = true;
            this.gridColStudentImage.Width = 59;
            // 
            // btnResetStudentList
            // 
            this.btnResetStudentList.BackColor = System.Drawing.Color.Green;
            this.btnResetStudentList.FlatAppearance.BorderSize = 0;
            this.btnResetStudentList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetStudentList.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetStudentList.ForeColor = System.Drawing.Color.White;
            this.btnResetStudentList.Location = new System.Drawing.Point(550, 572);
            this.btnResetStudentList.Name = "btnResetStudentList";
            this.btnResetStudentList.Size = new System.Drawing.Size(93, 39);
            this.btnResetStudentList.TabIndex = 7;
            this.btnResetStudentList.Text = "Reset";
            this.btnResetStudentList.UseVisualStyleBackColor = false;
            this.btnResetStudentList.Click += new System.EventHandler(this.btnResetStudentList_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(649, 572);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(93, 39);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(748, 572);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(93, 39);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // frmStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 629);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnResetStudentList);
            this.Controls.Add(this.dataGirdViewStudentList);
            this.MaximizeBox = false;
            this.Name = "frmStudentList";
            this.Text = "Student List";
            this.Load += new System.EventHandler(this.frmStudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGirdViewStudentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGirdViewStudentList;
        private System.Windows.Forms.Button btnResetStudentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColStudentImage;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnImport;
    }
}