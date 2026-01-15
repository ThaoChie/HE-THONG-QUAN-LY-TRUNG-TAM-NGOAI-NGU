namespace LCenter.UI
{
    partial class ManageClasses
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            grpInfo = new GroupBox();
            btnViewStudents = new Button();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            cboTeacher = new ComboBox();
            cboCourse = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtClassName = new TextBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvClasses = new DataGridView();
            btnBack = new Button();
            label7 = new Label();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpInfo.Controls.Add(btnViewStudents);
            grpInfo.Controls.Add(dtpEndDate);
            grpInfo.Controls.Add(dtpStartDate);
            grpInfo.Controls.Add(cboTeacher);
            grpInfo.Controls.Add(cboCourse);
            grpInfo.Controls.Add(label6);
            grpInfo.Controls.Add(label5);
            grpInfo.Controls.Add(label4);
            grpInfo.Controls.Add(label3);
            grpInfo.Controls.Add(txtClassName);
            grpInfo.Controls.Add(label2);
            grpInfo.Controls.Add(txtID);
            grpInfo.Controls.Add(label1);
            grpInfo.Controls.Add(btnRefresh);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpInfo.Location = new Point(12, 134);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(574, 960);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin Lớp học";
            // 
            // btnViewStudents
            // 
            btnViewStudents.BackColor = Color.Linen;
            btnViewStudents.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewStudents.ForeColor = Color.Black;
            btnViewStudents.Location = new Point(340, 769);
            btnViewStudents.Name = "btnViewStudents";
            btnViewStudents.Size = new Size(208, 40);
            btnViewStudents.TabIndex = 10;
            btnViewStudents.Text = "Xem chi tiết lớp";
            btnViewStudents.UseVisualStyleBackColor = false;
            btnViewStudents.Click += btnViewStudents_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(159, 705);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(379, 39);
            dtpEndDate.TabIndex = 5;
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(159, 583);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(379, 39);
            dtpStartDate.TabIndex = 4;
            // 
            // cboTeacher
            // 
            cboTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTeacher.FormattingEnabled = true;
            cboTeacher.Location = new Point(159, 463);
            cboTeacher.Name = "cboTeacher";
            cboTeacher.Size = new Size(379, 40);
            cboTeacher.TabIndex = 3;
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(159, 342);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(379, 40);
            cboCourse.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 710);
            label6.Name = "label6";
            label6.Size = new Size(108, 32);
            label6.TabIndex = 11;
            label6.Text = "Kết thúc:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 590);
            label5.Name = "label5";
            label5.Size = new Size(100, 32);
            label5.TabIndex = 9;
            label5.Text = "Bắt đầu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 471);
            label4.Name = "label4";
            label4.Size = new Size(133, 32);
            label4.TabIndex = 7;
            label4.Text = "Giảng viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 350);
            label3.Name = "label3";
            label3.Size = new Size(119, 32);
            label3.TabIndex = 5;
            label3.Text = "Khóa học:";
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(159, 229);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(379, 39);
            txtClassName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 236);
            label2.Name = "label2";
            label2.Size = new Size(98, 32);
            label2.TabIndex = 3;
            label2.Text = "Tên lớp:";
            // 
            // txtID
            // 
            txtID.BackColor = Color.WhiteSmoke;
            txtID.Location = new Point(159, 111);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(379, 39);
            txtID.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 118);
            label1.Name = "label1";
            label1.Size = new Size(94, 32);
            label1.TabIndex = 1;
            label1.Text = "Mã lớp:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(412, 864);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(126, 39);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(142, 861);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 42);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.GradientInactiveCaption;
            btnEdit.Location = new Point(0, 861);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(109, 36);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(288, 861);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(101, 42);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvClasses
            // 
            dgvClasses.AllowUserToAddRows = false;
            dgvClasses.AllowUserToDeleteRows = false;
            dgvClasses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClasses.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Navy;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClasses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClasses.ColumnHeadersHeight = 35;
            dgvClasses.EnableHeadersVisualStyles = false;
            dgvClasses.Location = new Point(592, 142);
            dgvClasses.MultiSelect = false;
            dgvClasses.Name = "dgvClasses";
            dgvClasses.ReadOnly = true;
            dgvClasses.RowHeadersVisible = false;
            dgvClasses.RowHeadersWidth = 82;
            dgvClasses.RowTemplate.Height = 25;
            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.Size = new Size(1175, 952);
            dgvClasses.TabIndex = 2;
            dgvClasses.CellClick += dgvClasses_CellClick;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.BackColor = Color.Gray;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1499, 9);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(268, 48);
            btnBack.TabIndex = 3;
            btnBack.Text = "Quay lại Dashboard";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.SteelBlue;
            label7.Location = new Point(300, 39);
            label7.Name = "label7";
            label7.Size = new Size(990, 59);
            label7.TabIndex = 7;
            label7.Text = "HỆ THỐNG QUẢN LÝ TRUNG TÂM NGOẠI NGỮ ";
            // 
            // ManageClasses
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1781, 1106);
            Controls.Add(label7);
            Controls.Add(btnBack);
            Controls.Add(dgvClasses);
            Controls.Add(grpInfo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ManageClasses";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Lớp Học";
            Load += ManageClasses_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.ComboBox cboTeacher;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnViewStudents;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.Button btnBack;
        private Label label7;
    }
}